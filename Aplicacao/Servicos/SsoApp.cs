using SsoBarbearia.Aplicacao.Interfaces;
using SsoBarbearia.Infraestrutura.Contexto;

namespace SsoBarbearia.Aplicacao.Servicos;

public class SsoApp(Contexto contexto) : ISsoApp
{
    private readonly Contexto _contexto = contexto;

    public bool VerificarDominio(string dominio)
    {
        if (string.IsNullOrWhiteSpace(dominio))
            throw new ArgumentException("Domínio não informado.");

        return _contexto.DominioAutorizado
            .Any(d => d.Dominio == dominio && d.Ativo);
    }
}


