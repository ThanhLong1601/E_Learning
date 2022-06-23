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
    public interface IEClassCourseRespository
    {
        List<ClassCourseDTO> GetAll();
        ClassCourseDTO GetById(int lassCourseId);
        bool Insert(ClassCourseDTO class_Course);
        bool Update(ClassCourseDTO class_Course);
        bool Delete(int lassCourseId);
        void Save();
    }
}
