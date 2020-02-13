using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.BookMark;
using Data.BookMark;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.BookMark.Controllers
{
    public class AlbumsController : BaseController<AppDbContext, Album>
    {
        public AlbumsController(AppDbContext dbContext, ILogger<AlbumsController> logger) : base(dbContext, dbContext.Albums) { }
    }
}
