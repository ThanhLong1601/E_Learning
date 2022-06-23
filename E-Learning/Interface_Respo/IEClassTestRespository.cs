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
    public interface IEClassTestRespository
    {
        List<ClassTestDTO> GetAll();
        ClassTestDTO GetById(int classTestId);
        bool Insert(ClassTestDTO classTest);
        bool Update(ClassTestDTO classTest);
        bool Delete(int classTestId);
        void Save();
    }
}
