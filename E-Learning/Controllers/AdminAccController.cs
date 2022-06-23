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
    public class AdminAccController : ControllerBase
    {
        private IEAdminAccRespository _AdaccRespo;
        private IMapper admap;

        public AdminAccController(IEAdminAccRespository adaccrespo, IMapper mapper)
        {
            admap = mapper;
            _AdaccRespo = adaccrespo;
        }
        //GET
        [HttpGet]
        public async Task<ActionResult<List<AdminAccountDTO>>> getAdminAcc()
        {
            var model = _AdaccRespo.GetAll();
            if (model == null)
            {
                return new List<AdminAccountDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddAdmin(AdminAccountDTO model)
        {
            var check = _AdaccRespo.Insert(model);
            _AdaccRespo.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateAdmin(AdminAccountDTO model)
        {
            var check = _AdaccRespo.Update(model);
            _AdaccRespo.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{username}")]
        public ActionResult<bool> DeleteAdmin(string username)
        {
            var check = _AdaccRespo.Delete(username);

            _AdaccRespo.Save();
            return check;

        }
    }
}
