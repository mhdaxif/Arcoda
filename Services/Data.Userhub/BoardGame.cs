﻿using System;
using System.ComponentModel;

namespace Data.Userhub
{
    public class BoardGame
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DisplayName("Publishing Company")]
        public string PublishingCompany { get; set; }

        [DisplayName("Min Players")]
        public int MinPlayers { get; set; }

        [DisplayName("Max Players")]
        public int MaxPlayers { get; set; }
    }
}
