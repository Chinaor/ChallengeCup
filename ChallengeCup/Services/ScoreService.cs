using ChallengeCup.Data;
using ChallengeCup.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Services
{
    public class ScoreService
    {
        private readonly ILogger<ScoreService> logger;

        private readonly ChallengeCupDbContext context;

        public ScoreService(ILogger<ScoreService> logger,
            ChallengeCupDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public void Add(Score score)
        {
            context.Add(score);
            context.SaveChanges();
        }
    }
}
