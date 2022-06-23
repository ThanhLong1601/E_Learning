﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Learning.DBContext;
using E_Learning.Entity;
using E_Learning.Respository;
using AutoMapper;
using E_Learning.DTO;
using E_Learning.Interface_Respo;

namespace E_Learning.Respository
{
    public class TestCateRespository : IETestCateRespository
    {
        private readonly IMapper testcatemap;
        private readonly Context con;
        public TestCateRespository(Context context, IMapper mapper)
        {
            con = context;
            testcatemap = mapper;
        }


        public bool Delete(int testCateId)
        {
            var DeleteTestcate = con.TestCategories.Find(testCateId);
            if (DeleteTestcate == null)
            {
                return false;
            }
            con.Remove(DeleteTestcate);
            return true;
        }

        public List<TestCateDTO> GetAll()
        {
            var alltest = con.TestCategories.ToList();
            return testcatemap.Map<List<TestCateDTO>>(alltest);

        }

        public TestCateDTO GetById(int testCateId)
        {
            var byid = con.TestCategories.Find(testCateId);
            if (byid == null)
            {
                return null;
            }

            return testcatemap.Map<TestCateDTO>(byid);
        }

        public bool Insert(TestCateDTO testCate)
        {
            var insertStu = con.TestCategories.Find(testCate.testCateId);
            if (insertStu == null)
            {
                con.TestCategories.Add(testcatemap.Map<TestCategory>(testCate));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(TestCateDTO testCate)
        {
            var UpdateStu = con.TestCategories.Find(testCate.testCateId);
            if (UpdateStu != null)
            {
                con.TestCategories.Update(testcatemap.Map(testCate, UpdateStu));
                return true;
            }
            return false;
        }
    }
}
