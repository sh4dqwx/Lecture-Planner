using DB.Services.Interfaces;
using DB.Dto;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DB.Repositories.Interfaces;

namespace DB.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _hallRepository;

        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public List<HallDto> GetList()
        {
            List<Hall> hallList = _hallRepository.GetList();
            List<HallDto> result = new List<HallDto>();
            foreach(Hall hall in hallList)
            {
                result.Add(new HallDto
                {
                    Id = hall.Id,
                    Name = hall.Name
                });
            }
            return result;
        }

        public HallDto GetById(int id)
        {
            Hall hall = _hallRepository.GetById(id);
            HallDto result = new HallDto
            {
                Id = hall.Id,
                Name = hall.Name
            };
            return result;
        }
    }
}
