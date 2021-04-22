using azure_function_refactor.dominio.ContentModel;
using Microsoft.EntityFrameworkCore;

namespace azure_function_refactor.dados.Contextos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<ContentModelDto> Content { get; set; }
        public DbSet<MetadataDto> Metadata { get; set; }
    }
}