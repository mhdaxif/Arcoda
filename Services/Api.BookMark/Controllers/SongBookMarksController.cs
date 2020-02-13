using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.BookMark;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.BookMark.Controllers
{
    public class SongBookMarksController : BaseController<AppDbContext, SongBookMark>
    {
        public SongBookMarksController(AppDbContext dbContext, ILogger<SongBookMarksController> logger) : base(dbContext, dbContext.SongBookMarks) { }
    }
}
