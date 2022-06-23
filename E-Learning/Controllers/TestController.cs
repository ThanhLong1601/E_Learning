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
    public class TestController : ControllerBase
    {
        private IETestRespository _test;
        private IMapper testmap;

        public TestController(IETestRespository test, IMapper mapper)
        {
            testmap = mapper;
            _test = test;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<TestDTO>>> gettestcate()
        {
            var model = _test.GetAll();
            if (model == null)
            {
                return new List<TestDTO>();
            }
            return model.ToList();
        } 

        //POST
        [HttpPost]
        public ActionResult<bool> AddTest(TestDTO model)
        {
            var check = _test.Insert(model);
            _test.Save();
            return check;
        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateTest(TestDTO model)
        {
            var check = _test.Update(model);
            _test.Save();
            return check;
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTest(int id)
        {
            var check = _test.Delete(id);

            _test.Save();
            return check;
        }
    }
}
