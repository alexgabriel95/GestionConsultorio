
namespace GestionConsultorio.Models.LS.Comp.Encriptador

{
    public static class ExtMethods
    {
        public static string Desencriptar(this byte[] byteEnc)
        {
            return Encriptador.Desencriptar<string>(byteEnc);
        }
    }
}
