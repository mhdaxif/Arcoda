using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.MusicStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.MusicStore.Controllers
{
    public class SongsController : BaseController<AppDbContext, Song>
    {
        public SongsController(AppDbContext dbContext) : base(dbContext, dbContext.Songs) { }
    }
}
