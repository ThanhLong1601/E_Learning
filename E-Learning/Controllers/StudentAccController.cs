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
    public class StudentAccController : ControllerBase
    {
        private IEStudentAccRespository _StuaccRespo;
        private IMapper stumap;

        public StudentAccController(IEStudentAccRespository stuaccrespo, IMapper mapper)
        {
            stumap = mapper;
            _StuaccRespo = stuaccrespo;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<StudentAccountDTO>>> getStuAcc()
        {
            var model = _StuaccRespo.GetAll();
            if (model == null)
            {
                return new List<StudentAccountDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddAdmin(StudentAccountDTO model)
        {
            var check = _StuaccRespo.Insert(model);
            _StuaccRespo.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateAdmin(StudentAccountDTO model)
        {
            var check = _StuaccRespo.Update(model);
            _StuaccRespo.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{username}")]
        public ActionResult<bool> DeleteAdmin(string username)
        {
            var check = _StuaccRespo.Delete(username);

            _StuaccRespo.Save();
            return check;

        }
    }
}
