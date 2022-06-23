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
    public interface IEStudentTestRespository
    {
        List<StudentTestDTO> GetAll();
        StudentTestDTO GetById(int studentTestId);
        bool Insert(StudentTestDTO studentTest);
        bool Update(StudentTestDTO studentTest);
        bool Delete(int studentTestId);
        void Save();
    }
}
