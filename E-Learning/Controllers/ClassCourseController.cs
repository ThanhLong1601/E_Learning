using Microsoft.AspNetCore.Http;
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
    public class ClassCourseController : ControllerBase
    {
        private IEClassCourseRespository _CCRespo;
        private IMapper ccmap;

        public ClassCourseController(IEClassCourseRespository ccrespo, IMapper mapper)
        {
            ccmap = mapper;
            _CCRespo = ccrespo;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<List<ClassCourseDTO>>> getAllCourse()
        {
            var model = _CCRespo.GetAll();
            if (model == null)
            {
                return new List<ClassCourseDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddCourse(ClassCourseDTO model)
        {
            var check = _CCRespo.Insert(model);
            _CCRespo.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateCourse(ClassCourseDTO model)
        {
            var check = _CCRespo.Update(model);
            _CCRespo.Save();
            return check;

        }


        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCourse(int id)
        {
            var check = _CCRespo.Delete(id);

            _CCRespo.Save();
            return check;

        }
    }
}
