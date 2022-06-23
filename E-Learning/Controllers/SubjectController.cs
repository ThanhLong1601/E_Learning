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
    public class SubjectController : ControllerBase
    {
        private IESubjectRespository _subject;
        private IMapper map;

        public SubjectController(IESubjectRespository subject, IMapper mapper)
        {
            map = mapper;
            _subject = subject;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<SubjectDTO>>> getsub()
        {
            var model = _subject.GetAll();
            if (model == null)
            {
                return new List<SubjectDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddSub(SubjectDTO model)
        {
            var check = _subject.Insert(model);
            _subject.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateTest(SubjectDTO model)
        {
            var check = _subject.Update(model);
            _subject.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTest(int id)
        {
            var check = _subject.Delete(id);

            _subject.Save();
            return check;
        }
    }
}
