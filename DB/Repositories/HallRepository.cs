using DB.Repositories.Interfaces;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB.Repositories
{
	public class HallRepository : IHallRepository
	{
		private readonly MyDbContext _dbContext;

		public HallRepository(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Hall> GetList()
		{
			return _dbContext.Halls.FromSqlRaw("GetHalls").ToList();
		}

		public Hall GetById(int id)
		{
			return _dbContext.Halls.FromSql($"GetHallById {id}").ToList()[0];
		}
	}
}
