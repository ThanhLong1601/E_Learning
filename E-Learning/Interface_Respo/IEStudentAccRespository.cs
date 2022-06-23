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
    public interface IEStudentAccRespository
    {
        List<StudentAccountDTO> GetAll();
        StudentAccountDTO GetById(string userName);
        bool Insert(StudentAccountDTO student);
        bool Update(StudentAccountDTO student);
        bool Delete(string userName);
        void Save();
    }
}
