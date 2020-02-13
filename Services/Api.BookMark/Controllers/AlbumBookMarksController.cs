using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.BookMark;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.BookMark.Controllers
{
    public class AlbumBookMarksController : BaseController<AppDbContext, AlbumBookMark>
    {
        public AlbumBookMarksController(AppDbContext dbContext, ILogger<AlbumBookMarksController> logger) : base(dbContext, dbContext.AlbumBookMarks) { }
    }
}
