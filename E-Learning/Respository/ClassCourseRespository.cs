using System;
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
    public class ClassCourseRespository : IEClassCourseRespository
    {
        private readonly IMapper ccmap;
        private readonly Context con;

        public ClassCourseRespository(Context context, IMapper mapper)
        {
            con = context;
            ccmap = mapper;
        }

        public bool Delete(int lassCourseId)
        {
            var DeleteClassCourse = con.Class_Course.Find(lassCourseId);
            if (DeleteClassCourse == null)
            {
                return false;
            }
            con.Remove(DeleteClassCourse);
            return true;
        }

        public List<ClassCourseDTO> GetAll()
        {
            var allCourse = con.Class_Course.ToList();
            return ccmap.Map<List<ClassCourseDTO>>(allCourse);
        }

        public ClassCourseDTO GetById(int lassCourseId)
        {
            var byid = con.Class_Course.Find(lassCourseId);
            if (byid == null)
            {
                return null;
            }

            return ccmap.Map<ClassCourseDTO>(byid);
        }

        public bool Insert(ClassCourseDTO cc)
        {
            var insertCourse = con.Class_Course.Find(cc.lassCourseId);
            if (insertCourse == null)
            {
                con.Class_Course.Add(ccmap.Map<Class_Course>(cc));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(ClassCourseDTO cc)
        {
            var UpdateCourse = con.Class_Course.Find(cc.lassCourseId);
            if (UpdateCourse != null)
            {
                con.Class_Course.Update(ccmap.Map(cc, UpdateCourse));
                return true;
            }
            return false;
        }
    }
}
