using SsoBarbearia.Modelos.Response;

namespace SsoBarbearia.Aplicacao.Interfaces
{
    public interface ISsoApp
    {
        ConfiguracaoSiteResponse ObterConfiguracao(string dominio);
        bool VerificarDominio(string dominio);
    }
}
