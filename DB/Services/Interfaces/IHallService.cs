using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Dto;

namespace DB.Services.Interfaces
{
    public interface IHallService
    {
        public List<HallDto> GetList();
        public HallDto GetById(int id);
    }
}
