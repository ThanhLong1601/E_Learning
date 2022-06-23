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
    public interface IESubjectRespository
    {
        List<SubjectDTO> GetAll();
        SubjectDTO GetById(int subjectId);
        bool Insert(SubjectDTO subject);
        bool Update(SubjectDTO subject);
        bool Delete(int subjectId);
        void Save();
    }
}
