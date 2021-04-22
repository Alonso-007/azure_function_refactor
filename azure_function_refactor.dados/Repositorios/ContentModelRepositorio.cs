using azure_function_refactor.dados.Contextos;
using azure_function_refactor.dominio.ContentModel;

namespace azure_function_refactor.dados.Repositorios
{
    public class ContentModelRepositorio : BaseRepositorio<ContentModelDto>
    {
        public ContentModelRepositorio(ApplicationDbContext contexto) : base(contexto) { }
    }
}