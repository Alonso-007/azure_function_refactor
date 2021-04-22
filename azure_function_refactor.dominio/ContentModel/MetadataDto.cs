namespace azure_function_refactor.dominio.ContentModel
{
    public class MetadataDto
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public ContentModelDto Content { get; set; }
        public int ContentModelDtoId { get; set; }
    }
}