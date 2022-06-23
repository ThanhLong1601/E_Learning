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
    public class LearningResultController : ControllerBase
    {
        private IELearningResultRespository _result;
        private IMapper map;

        public LearningResultController(IELearningResultRespository result, IMapper mapper)
        {
            map = mapper;
            _result = result;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<List<LearningResultDTO>>> getsub()
        {
            var model = _result.GetAll();
            if (model == null)
            {
                return new List<LearningResultDTO>();
            }
            return model.ToList();
        }


        //POST
        [HttpPost]
        public ActionResult<bool> AddSub(LearningResultDTO model)
        {
            var check = _result.Insert(model);
            _result.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateTest(LearningResultDTO model)
        {
            var check = _result.Update(model);
            _result.Save();
            return check;

        }


        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTest(int id)
        {
            var check = _result.Delete(id);

            _result.Save();
            return check;

        }
    }
}
