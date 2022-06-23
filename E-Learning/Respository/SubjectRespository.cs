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
    public class SubjectRespository : IESubjectRespository
    {
        private readonly IMapper map;
        private readonly Context con;
        public SubjectRespository(Context context, IMapper mapper)
        {
            con = context;
            map = mapper;
        }

        public bool Delete(int subjectId)
        {
            var Delete = con.Subjects.Find(subjectId);
            if (Delete == null)
            {
                return false;
            }
            con.Remove(Delete);
            return true;
        }

        public List<SubjectDTO> GetAll()
        {
            var all = con.Subjects.ToList();
            return map.Map<List<SubjectDTO>>(all);

        }

        public SubjectDTO GetById(int subjectId)
        {
            var byid = con.Subjects.Find(subjectId);
            if (byid == null)
            {
                return null;
            }

            return map.Map<SubjectDTO>(byid);
        }

        public bool Insert(SubjectDTO subject)
        {
            var insert = con.Subjects.Find(subject.subjectId);
            if (insert == null)
            {
                con.Subjects.Add(map.Map<Subject>(subject));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(SubjectDTO subject)
        {
            var Update = con.Subjects.Find(subject.subjectId);
            if (Update != null)
            {
                con.Subjects.Update(map.Map(subject, Update));
                return true;
            }
            return false;
        }
    }
}
