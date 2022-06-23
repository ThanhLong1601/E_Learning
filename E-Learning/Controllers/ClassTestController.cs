﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
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
    public class ClassTestController : ControllerBase
    {
        private IEClassTestRespository _cltest;
        private IMapper cltestmap;

        public ClassTestController(IEClassTestRespository cltest, IMapper mapper)
        {
            cltestmap = mapper;
            _cltest = cltest;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<List<ClassTestDTO>>> getClasstest()
        {
            var model = _cltest.GetAll();
            if (model == null)
            {
                return new List<ClassTestDTO>();
            }
            return model.ToList();
        }


        //POST
        [HttpPost]
        public ActionResult<bool> AddCLTest(ClassTestDTO model)
        {
            var check = _cltest.Insert(model);
            _cltest.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateCLTest(ClassTestDTO model)
        {
            var check = _cltest.Update(model);
            _cltest.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCLTest(int id)
        {
            var check = _cltest.Delete(id);

            _cltest.Save();
            return check;

        }
    }
}
