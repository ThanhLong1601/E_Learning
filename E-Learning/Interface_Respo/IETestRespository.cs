﻿using System;
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
    public interface IETestRespository
    {
        List<TestDTO> GetAll();
        TestDTO GetById(int testId);
        bool Insert(TestDTO test);
        bool Update(TestDTO test);
        bool Delete(int testId);
        void Save();
    }
}
