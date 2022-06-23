using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using E_Learning.DBContext;
using E_Learning.Entity;
using E_Learning.Respository;
using AutoMapper;
using E_Learning.DTO;
using E_Learning.Interface_Respo;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IEDocumentRespository _DocRespo;
        private IMapper docmap;
        public DocumentController(IEDocumentRespository docrespo, IMapper mapper)
        {
            docmap = mapper;
            _DocRespo = docrespo;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<DocumentDTO>>> getAllCourse()
        {
            var model = _DocRespo.GetAll();
            if (model == null)
            {
                return new List<DocumentDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddDoc(DocumentDTO model)
        {
            var check = _DocRespo.Insert(model);
            _DocRespo.Save();
            return check;

        }


        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateDoc(DocumentDTO model)
        {
            var check = _DocRespo.Update(model);
            _DocRespo.Save();
            return check;

        }



        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteDoc(int id)
        {
            var check = _DocRespo.Delete(id);

            _DocRespo.Save();
            return check;

        }
    }
}
