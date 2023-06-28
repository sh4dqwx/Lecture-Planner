using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories.Interfaces
{
	public interface IHallRepository
	{
		public List<Hall> GetList();
		public Hall GetById(int id);
	}
}
