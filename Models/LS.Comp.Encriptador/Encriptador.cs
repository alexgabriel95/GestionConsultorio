using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace GestionConsultorio.Models.LS.Comp.Encriptador
{
    public class Encriptador
    {
        public static byte[] Encriptar<T>(T objetoSerializable)
        {
            byte[] encriptacion;
            if (!typeof(T).IsSerializable)
            {
                throw new Exception($"El objeto del tipo {typeof(T).Name} no es serializable!");
            }
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, objetoSerializable);
                using (var rijndael = Rijndael.Create())
                {
                    var info = InformacionDeSeguridad.GetDatos();
                    rijndael.Key = info.Key;
                    rijndael.IV = info.Iv;
                    rijndael.Padding = PaddingMode.ISO10126;
                    var encriptador = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
                    var texto = ms.ToArray();
                    using (var ms2 = new MemoryStream())
                    {
                        using (var cryptoSteam = new CryptoStream(ms2, encriptador, CryptoStreamMode.Write))
                        {
                            cryptoSteam.Write(texto, 0, texto.Length);
                        }
                        encriptacion = ms2.ToArray();
                    }
                }
            }
            return encriptacion;
        }
        public static T Desencriptar<T>(byte[] bytesEncriptados)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new Exception($"El objeto del tipo {typeof(T).Name} no es serializable!");
            }
            try
            {
                byte[] decodificacion;
                using (var rijndael = Rijndael.Create())
                {
                    var info = InformacionDeSeguridad.GetDatos();
                    rijndael.Key = info.Key;
                    rijndael.IV = info.Iv;
                    rijndael.Padding = PaddingMode.ISO10126;
                    var encriptador = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
                    using (var ms2 = new MemoryStream())
                    {
                        using (var cryptoSteam = new CryptoStream(ms2, encriptador, CryptoStreamMode.Write))
                        {
                            cryptoSteam.Write(bytesEncriptados, 0, bytesEncriptados.Length);
                            cryptoSteam.FlushFinalBlock();
                        }
                        decodificacion = ms2.ToArray();
                    }
                }
                return (T)new BinaryFormatter().Deserialize(new MemoryStream(decodificacion));
            }
            catch (Exception)
            {
                return default(T);
            }

        }

        public sealed class InformacionDeSeguridad
        {
            public byte[] Key { get; set; }
            public byte[] Iv { get; set; }
            public string KeyString { get; set; }
            public string IvString { get; set; }

            private static readonly InformacionDeSeguridad Instancia = new InformacionDeSeguridad();

            public static InformacionDeSeguridad GetDatos()
            {
                return Instancia;
            }

            private InformacionDeSeguridad()
            {
                try
                {
                    KeyString = "AAECAwQFBgcICQoLDA0ODw ==";
                    IvString = "AAECAwQFBgcICQoLDA0ODw==";
                    Key = Convert.FromBase64String(KeyString);
                    Iv = Convert.FromBase64String(IvString);
                    if (Key == null || Key.Length <= 0)
                        throw new ArgumentNullException($"key vacia");
                    if (Iv == null || Iv.Length <= 0)
                        throw new ArgumentNullException($"iv vacio");
                }
                catch
                {
                    throw new Exception("No se encontro alguna clave en la configuracion");
                }
            }
        }

    }
}
