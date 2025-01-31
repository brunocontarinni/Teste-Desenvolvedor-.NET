public class GeradorCompletoDeDados
{
    private readonly VestTestDbContext _context;
    private readonly GeradorDeDadosOfertaCursos _ofertaCursoGenerator;
    private readonly GeradorDeDadosInscricoes _inscricaoGenerator;
    private readonly GeradorDeDadosCandidatos _candidatoGenerator;
    private readonly GeradorDeDadosProcessoSeletivo _processoSeletivoGenerator;

    public GeradorCompletoDeDados(VestTestDbContext context)
    {
        _context = context;
        _ofertaCursoGenerator = new GeradorDeDadosOfertaCursos(_context);
        _candidatoGenerator = new GeradorDeDadosCandidatos(_context);
        _processoSeletivoGenerator = new GeradorDeDadosProcessoSeletivo(_context);
        _inscricaoGenerator = new GeradorDeDadosInscricoes(_context);
    }

    public void GerarDados()
    {
        _ofertaCursoGenerator.GerarDados();
        _candidatoGenerator.GerarDados();
        _processoSeletivoGenerator.GerarDados();
        _inscricaoGenerator.GerarDados();
    }
}
