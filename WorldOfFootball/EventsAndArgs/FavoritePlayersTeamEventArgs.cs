﻿using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfFootball.EventsAndArgs
{
    public class FavoritePlayersTeamEventArgs: EventArgs
    {
        public List<Player> FavoritePlayersList { get; set; }
        public List<Player> NotFavoritePlayersList { get; set; }

        public List<Player> AllPlayers { get; set; }
        public string FifaCodeFavCountry { get; set; }
    }
}
