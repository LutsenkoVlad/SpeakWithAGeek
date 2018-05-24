using Geek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geek.Infrastructure.Repository
{
    public class CalcResultRepository : BaseRepository<CalcResult>, ICalcResultRepository
    {
        public CalcResultRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public interface ICalcResultRepository : IRepository<CalcResult>
    {

    }
}
