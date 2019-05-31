using System.Collections.Generic;
using DocumentsApi.Models;
using DocumentsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentsApi.Controllers
{
    [Route("ic/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentsController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public ActionResult<List<Document>> Get()
        {
            return _documentService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetDocument")]
        public ActionResult<Document> Get(string id)
        {
            var document = _documentService.Get(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        [HttpPost]
        public ActionResult<Document> Create(Document document)
        {
            _documentService.Create(document);

            return CreatedAtRoute("GetDocument", new { id = document.Id.ToString() }, document);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Document documentIn)
        {
            var document = _documentService.Get(id);

            if (document == null)
            {
                return NotFound();
            }

            _documentService.Update(id, documentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var document = _documentService.Get(id);

            if (document == null)
            {
                return NotFound();
            }

            _documentService.Remove(document.Id);

            return NoContent();
        }
    }
}