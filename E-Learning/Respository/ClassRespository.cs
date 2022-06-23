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
    public class ClassRespository : IEClassRespository
    {
        private readonly IMapper classmap;
        private readonly Context con;
        public ClassRespository(Context context, IMapper mapper)
        {
            con = context;
            classmap = mapper;
        }
        public bool Delete(string classId)
        {
            var DeleteClass = con.Admins.Find(classId);
            if (DeleteClass == null)
            {
                return false;
            }
            con.Remove(DeleteClass);
            return true;
        }

        public List<ClassDTO> GetAll()
        {
            var allClass = con.Classes.ToList();
            return classmap.Map<List<ClassDTO>>(allClass);

        }

        public ClassDTO GetById(string classId)
        {
            var byid = con.Classes.Find(classId);
            if (byid == null)
            {
                return null;
            }

            return classmap.Map<ClassDTO>(byid);
        }

        public bool Insert(ClassDTO cladmin)
        {
            var insertAd = con.Classes.Find(cladmin.classId);
            if (insertAd == null)
            {
                con.Classes.Add(classmap.Map<Class>(cladmin));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(ClassDTO admin)
        {
            var UpdateAd = con.Classes.Find(admin.classId);
            if (UpdateAd != null)
            {
                con.Classes.Update(classmap.Map(admin, UpdateAd));
                return true;
            }
            return false;
        }
    }
}
