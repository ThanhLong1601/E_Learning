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
    public interface IEPositionRespository
    {
        List<PositionDTO> GetAll();
        PositionDTO GetById(int positionId);
        bool Insert(PositionDTO position);
        bool Update(PositionDTO position);
        bool Delete(int positionId);
        void Save();
    }
}
