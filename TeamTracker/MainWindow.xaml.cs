﻿using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using TeamTracker.EventsArgsTT;
using TeamTracker.UserControls;
using System.Linq;


namespace TeamTracker
{

    public partial class MainWindow : Window
    {
        private DataManager _dataManager = new();
        private bool _isWomens;
        private string _language;
        private string _championship;
        private string _screenSize;
        private string _favTeamCode;
        private string _oppTeamCode;
        private string _result;
        private List<Player> _favPlayers = new();
        private List<Player> _notfavPlayers = new();
        private List<Player> _allPlayers = new();
        private List<FootballMatch> _footballMatchList;
        private InitialWoFSettings _initialSettings = new();
        private FavoriteCountryandPlayersSetup _favoriteSettings = new();
     


        public MainWindow()
        {
            LoadInitialSettings();
            InitializeComponent();
     
            SetLanguage();
            SetScreenSize();
            LoadFirstScreen();

        }

        #region Load methods
        private void LoadFirstScreen()
        {
            if (_language != null || _screenSize != null || _championship != null)
            {

                CallOverviewOfTheTeam();

            }
            else
            {

                CallInitialSettings();
            }

        }

        private async void LoadInitialSettings()
        {
            try
            {
                await _dataManager.LoadSavedSettings();
                _language = _dataManager.GetLanguage();
                _championship = _dataManager.GetChampionshipString();
                if (_championship == "Mens")
                {
                    _isWomens = false;
                }else if(_championship == "Womens"){
                    _isWomens=true;
                }
     
                _screenSize = _dataManager.GetScreenSize();
                _favTeamCode = _dataManager.GetFavFifaCode();
                _oppTeamCode = _dataManager.GetOppositeFifaCode();
                _favPlayers = _dataManager.GetFavoritePlayers();
                _notfavPlayers = _dataManager.GetNotFavoritePlayers();
                if (_favPlayers != null)
                {
                    _allPlayers = _favPlayers.Concat(_notfavPlayers).ToList();
                }
            

            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.messageCantGetData, Properties.Resources.warning, MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
       
                 
         
          
        }

        #endregion

        #region Set methods
        private void SetLanguage()
        {
            if (_language != null)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(_language);
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }

        }
        private void SetScreenSize()
        {
            if (_screenSize is null || _screenSize == "Original")
            {
                // Get reference to the window
                Window window = System.Windows.Application.Current.MainWindow;

                // Exit fullscreen mode
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }

                // Set window size and position
                window.Width = 1500;
                window.Height = 800;
                window.Left = (SystemParameters.PrimaryScreenWidth / 2) - (window.Width / 2);
                window.Top = (SystemParameters.PrimaryScreenHeight / 2) - (window.Height / 2);

             
            }
            else if (_screenSize == "Fullscreen")
            {
                // Dobivanje referene na prozor
                Window window = System.Windows.Application.Current.MainWindow;

                // Postavljanje prozora u puni zaslon
                window.WindowState = WindowState.Maximized;
            }
            else if (_screenSize == "Small")
            {
                // Get reference to the window
                Window window = System.Windows.Application.Current.MainWindow;

                // Exit fullscreen mode
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }

                window.Width = 800;
                window.Height = 800;
                window.Left = (SystemParameters.PrimaryScreenWidth / 2) - (window.Width / 2);
                window.Top = (SystemParameters.PrimaryScreenHeight / 2) - (window.Height / 2);

            }
        }

        #endregion

        #region Call user forms
        private void CallInitialSettings()
        {
            TTSettings initSettings = new(_language, _isWomens, _screenSize);
            initSettings.InitSett += InitialSettingsFormBtn_Click;
            Container.Content = initSettings;
        }

        private void CallOverviewOfTheTeam()
        {

            OverviewOfTheTeam overview = new(_isWomens, _favTeamCode, _oppTeamCode, _language);
            overview.TeamOverview += OverviewBtn_Click;
            overview.BackClick += OverwievBack_Click;
            Container.Content = overview;
        }

        private void CallFirstEleven()
        {
            FirstEleven firstEleven = new(_favTeamCode, _oppTeamCode, _result, _footballMatchList, _allPlayers);
            Container.Content = firstEleven;
        }
        #endregion

        #region Events on buttons
        private void OverwievBack_Click(object sender, EventArgs e)
        {
            CallInitialSettings();
        }



        private async void OverviewBtn_Click(object sender, OverviewEventArgs e)
        {

            _result = e.Result;
            _footballMatchList = e.FootballMatches;
            string teamCode = e.FavoriteTeam;
            _oppTeamCode = e.OppositeTeam;

            if (_favTeamCode != teamCode)
            {
                _favoriteSettings.FifaCodeFavCountry = teamCode;
                _favoriteSettings.OppositeTeam = _oppTeamCode;
                _favoriteSettings.FavoritePlayersList = null;
                _favoriteSettings.NotFavoritePlayersList = null;
                _favTeamCode = teamCode;
            }
            else
            {
                _favoriteSettings.FifaCodeFavCountry = _favTeamCode;
                _favoriteSettings.OppositeTeam = _oppTeamCode;
                _favoriteSettings.FavoritePlayersList = _favPlayers;
                _favoriteSettings.NotFavoritePlayersList = _notfavPlayers;
            }
            _initialSettings.Language = _language;
            _initialSettings.Championship = _championship;

            await _dataManager.SaveFavoritePlayersToRepo(_favoriteSettings);
            await _dataManager.SaveInitialSettingsToRepo(_initialSettings);
            SetScreenSize();
            LoadInitialSettings();
            CallFirstEleven();
        }



        private async void InitialSettingsFormBtn_Click(object sender, InitialSettingsEventArgs e)
        {
            _language = e.Language;
            _championship = e.Championship;
            _screenSize = e.ScreenSize;
            _isWomens = _championship == "Mens" ? false : true;

            _initialSettings.Language = _language;
            _initialSettings.Championship = _championship;
            _initialSettings.ScreenSize = _screenSize;
            await _dataManager.SaveInitialSettingsToRepo(_initialSettings);



            SetLanguage();
            SetScreenSize();
            CallOverviewOfTheTeam();
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var result = MessageBox.Show(Properties.Resources.messageClosingApp, Properties.Resources.warning, MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            _initialSettings.Language = _language;
            _initialSettings.Championship = _championship;
            _initialSettings.ScreenSize = _screenSize;
            _favoriteSettings.FifaCodeFavCountry = _favTeamCode;
            _favoriteSettings.OppositeTeam = _oppTeamCode;
            _favoriteSettings.FavoritePlayersList = _favPlayers;
            _favoriteSettings.NotFavoritePlayersList = _notfavPlayers;
            await _dataManager.SaveFavoritePlayersToRepo(_favoriteSettings);
            await _dataManager.SaveInitialSettingsToRepo(_initialSettings);

        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            SetScreenSize();
            CallInitialSettings();

        }

        #endregion 
        




    }
}

