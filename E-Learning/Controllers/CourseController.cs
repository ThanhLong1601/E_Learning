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
    public class CourseController : ControllerBase
    {
        private IECourseRespository _CourseRespo;
        private IMapper coursemap;
        public CourseController(IECourseRespository courserespo, IMapper mapper)
        {
            coursemap = mapper;
            _CourseRespo = courserespo;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> getAllCourse()
        {
            var model = _CourseRespo.GetAll();
            if (model == null)
            {
                return new List<CourseDTO>();
            }
            return model.ToList();
        }


        //POST
        [HttpPost]
        public ActionResult<bool> AddCourse(CourseDTO model)
        {
            var check = _CourseRespo.Insert(model);
            _CourseRespo.Save();
            return check;

        }


        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateCourse(CourseDTO model)
        {
            var check = _CourseRespo.Update(model);
            _CourseRespo.Save();
            return check;

        }


        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCourse(int id)
        {
            var check = _CourseRespo.Delete(id);

            _CourseRespo.Save();
            return check;

        }
    }
}
