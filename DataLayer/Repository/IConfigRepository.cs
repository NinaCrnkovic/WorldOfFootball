﻿using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IConfigRepository
    {
        Task<Configuration> GetConfigurationFile();
        Task SaveInitialSettings(InitialWoFSettings settings);
        Task<InitialWoFSettings> GetInitialSettings();
        Task SaveFavoritePlayersSettings(FavoriteCountryandPlayersSetup favoriteCountryandPlayersSetup);

        Task<FavoriteCountryandPlayersSetup> GetFavoritePlayersSettings();



    }
}
