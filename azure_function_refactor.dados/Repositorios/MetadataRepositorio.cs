using azure_function_refactor.dados.Contextos;
using azure_function_refactor.dominio.ContentModel;

namespace azure_function_refactor.dados.Repositorios
{
    public class MetadataRepositorio : BaseRepositorio<MetadataDto>
    {
        public MetadataRepositorio(ApplicationDbContext contexto) : base(contexto) { }
    }
}