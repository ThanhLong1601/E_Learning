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
    public class PositionController : ControllerBase
    {
        private IEPositionRespository _PosRespo;
        private IMapper admap;
        public PositionController(IEPositionRespository posrespo, IMapper mapper)
        {
            admap = mapper;
            _PosRespo = posrespo;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<PositionDTO>>> getPos()
        {
            var model = _PosRespo.GetAll();
            if (model == null)
            {
                return new List<PositionDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddPos(PositionDTO model)
        {
            var check = _PosRespo.Insert(model);
            _PosRespo.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdatePos(PositionDTO model)
        {
            var check = _PosRespo.Update(model);
            _PosRespo.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteGra(int id)
        {
            var check = _PosRespo.Delete(id);

            _PosRespo.Save();
            return check;

        }
    }
}
