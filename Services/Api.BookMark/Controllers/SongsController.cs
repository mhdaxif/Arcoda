using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.BookMark;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.BookMark.Controllers
{
    public class SongsController : BaseController<AppDbContext, Song>
    {
        public SongsController(AppDbContext dbContext, ILogger<SongsController> logger) : base(dbContext, dbContext.Songs) { }
    }
}
