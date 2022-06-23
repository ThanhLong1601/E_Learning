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
    public interface IECourseRespository
    {
        List<CourseDTO> GetAll();
        CourseDTO GetById(int courseId);
        bool Insert(CourseDTO course);
        bool Update(CourseDTO course);
        bool Delete(int courseId);
        void Save();
    }
}
