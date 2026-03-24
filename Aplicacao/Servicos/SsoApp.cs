using Microsoft.EntityFrameworkCore;
using SsoBarbearia.Aplicacao.Interfaces;
using SsoBarbearia.Infraestrutura.Contexto;
using SsoBarbearia.Modelos.Response;

namespace SsoBarbearia.Aplicacao.Servicos;

public class SsoApp(Contexto contexto) : ISsoApp
{
    private readonly Contexto _contexto = contexto;
    public ConfiguracaoSiteResponse ObterConfiguracao(string dominio)
    {
        if (string.IsNullOrWhiteSpace(dominio))
            throw new ArgumentException("Domínio não informado.");

        var config = _contexto.ConfiguracaoSite
            .Include(c => c.Dominio)
            .FirstOrDefault(c => c.Dominio != null && c.Dominio.Dominio == dominio && c.Dominio.Ativo)
            ?? throw new Exception("Configuração não encontrada para o domínio informado.");

        return new ConfiguracaoSiteResponse
        {
            NomeSite = config.NomeSite,
            LogoBase64 = config.Logo != null ? Convert.ToBase64String(config.Logo) : null,
            CorPrimaria = config.CorPrimaria,
            CorSecundaria = config.CorSecundaria,
            CorFundo = config.CorFundo,
            CorTexto = config.CorTexto,
            CorAcento = config.CorAcento
        };
    }

    public bool VerificarDominio(string dominio)
    {
        if (string.IsNullOrWhiteSpace(dominio))
            throw new ArgumentException("Domínio não informado.");

        return _contexto.DominioAutorizado
            .Any(d => d.Dominio == dominio && d.Ativo);
    }
}


