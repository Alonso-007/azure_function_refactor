using azure_function_refactor.dados.Contextos;
using azure_function_refactor.dados.Repositorios;
using azure_function_refactor.dominio.ContentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azure_function_refactor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ContentModelRepositorio _contentModelRepositorio;
        private readonly MetadataRepositorio _metadataRepositorio;

        public ContentController(ApplicationDbContext dbContext, 
                                 ContentModelRepositorio contentModelRepositorio,
                                 MetadataRepositorio metadataRepositorio)
        {
            _context = dbContext;
            _contentModelRepositorio = contentModelRepositorio;
            _metadataRepositorio = metadataRepositorio;
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var lista = from c in _contentModelRepositorio.List()
                            join m in _metadataRepositorio.List()
                            on c.Id equals m.ContentModelDtoId
                            select new { c.Name, m.Valor };

                if (lista == null || lista.Count() == 0) return NotFound("Registros nao encontrados");

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            try
            {
                var total = 100;

                for (int i = 0; i < total; i++)
                {
                    ContentModelDto content = new ContentModelDto();
                    content.Name = $"Index:{i}";
                    _contentModelRepositorio.Add(content);
                    await _contentModelRepositorio.Commit();
                    var id = content.Id;

                    MetadataDto metadata = new MetadataDto();
                    metadata.ContentModelDtoId = id;
                    metadata.Valor = DateTime.Now.ToString();
                    _metadataRepositorio.Add(metadata);
                    await _metadataRepositorio.Commit();
                }

                return Ok("Registros criados");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(ContentModelDto contentModel)
        {
            try
            {
                var metadado = await _metadataRepositorio.Find(f => f.ContentModelDtoId == contentModel.Id);
                _metadataRepositorio.Delete(metadado);
                await _metadataRepositorio.Commit();
                _contentModelRepositorio.Delete(contentModel);
                await _contentModelRepositorio.Commit();

                return Ok("Registro apagado");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}