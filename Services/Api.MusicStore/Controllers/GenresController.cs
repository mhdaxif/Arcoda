using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.MusicStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.MusicStore.Controllers
{
    public class GenresController : BaseController<AppDbContext, Genre>
    {
        public GenresController(AppDbContext dbContext, ILogger<GenresController> logger) : base(dbContext, dbContext.Genres) { }
    }
}
