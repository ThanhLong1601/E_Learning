using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Learning.DTO;
using E_Learning.Entity;

namespace E_Learning.Interface_Respo
{
    public interface IETestCateRespository
    {
        List<TestCateDTO> GetAll();
        TestCateDTO GetById(int testCateId);
        bool Insert(TestCateDTO testCate);
        bool Update(TestCateDTO testCate);
        bool Delete(int testCateId);
        void Save();
    }
}
