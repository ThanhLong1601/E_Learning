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
    public interface IELearningResultRespository
    {
        List<LearningResultDTO> GetAll();
        LearningResultDTO GetById(int Id);
        bool Insert(LearningResultDTO learningResult);
        bool Update(LearningResultDTO learningResult);
        bool Delete(int Id);
        void Save();
    }
}
