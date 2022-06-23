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
    public class LearningResultRespository : IELearningResultRespository
    {
        private readonly IMapper map;
        private readonly Context con;
        public LearningResultRespository(Context context, IMapper mapper)
        {
            con = context;
            map = mapper;
        }

        public bool Delete(int Id)
        {
            var Delete = con.Learning_Results.Find(Id);
            if (Delete == null)
            {
                return false;
            }
            con.Remove(Delete);
            return true;
        }

        public List<LearningResultDTO> GetAll()
        {
            var all = con.Learning_Results.ToList();
            return map.Map<List<LearningResultDTO>>(all);

        }

        public LearningResultDTO GetById(int Id)
        {
            var byid = con.Learning_Results.Find(Id);
            if (byid == null)
            {
                return null;
            }

            return map.Map<LearningResultDTO>(byid);
        }

        public bool Insert(LearningResultDTO learningResult)
        {
            var insert = con.Learning_Results.Find(learningResult.Id);
            if (insert == null)
            {
                con.Learning_Results.Add(map.Map<Learning_Result>(learningResult));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(LearningResultDTO learningResult)
        {
            var Update = con.Learning_Results.Find(learningResult.Id);
            if (Update != null)
            {
                con.Learning_Results.Update(map.Map(learningResult, Update));
                return true;
            }
            return false;
        }
    }
}
