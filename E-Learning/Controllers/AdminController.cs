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
    public class AdminController : ControllerBase
    {
        private IEAdminRespository _AdRespo;
        private IMapper admap;
        public AdminController(IEAdminRespository adrespo, IMapper mapper)
        {
            admap = mapper;
            _AdRespo = adrespo;

        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<AdminDTO>>> getAdmin()
        {
            var model = _AdRespo.GetAll();
            if (model == null)
            {
                return new List<AdminDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddAdmin(AdminDTO model)
        {
            var check = _AdRespo.Insert(model);
            _AdRespo.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateAdmin(AdminDTO model)
        {
            var check = _AdRespo.Update(model);
            _AdRespo.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteAdmin(string id)
        {
            var check = _AdRespo.Delete(id);

            _AdRespo.Save();
            return check;

        }
    }
}