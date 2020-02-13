using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.MusicStore;
using Data.MusicStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.MusicStore.Controllers
{
    public class ArtistsController : BaseController<AppDbContext, Artist>
    {
        public ArtistsController(AppDbContext dbContext, ILogger<ArtistsController> logger) : base(dbContext, dbContext.Artists) { }
    }
}
