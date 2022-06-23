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
    public interface IEStudentRespository
    {
        List<StudentDTO> GetAll();
        StudentDTO GetById(string studentId);
        bool Insert(StudentDTO student);
        bool Update(StudentDTO student);
        bool Delete(string studentId);
        void Save();
    }
}
