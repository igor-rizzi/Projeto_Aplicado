namespace ProjAplicado.Api.Extensions
{
    public class AppSettingsJWT
    {
        public string Secret { get; set; }

        public int ExpiracaoHora { get; set; }

        public string Emissor { get; set; }

        public string ValidoEm { get; set; }
    }
}
