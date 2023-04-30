﻿using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamTracker.EventsArgsTT;

namespace TeamTracker.UserControls
{
    
    public partial class OverviewOfTheTeam : UserControl
    {
        private string _championshpip;
        private DataManager _dataManager = new();
    
        private List<FootballMatch> _matches;
        private List<Result> _results;
    
        private bool _isWomens;
        private string _favoriteFifaCode;
        private string _oppositeFifaCode;

        public OverviewOfTheTeam(string championship)
        {
            InitializeComponent();
            _championshpip = championship;
            _isWomens = _championshpip == "Mens" ? false : true;
            GetMatches();
            GetTeams();
            FillFavoriteComboBox();
            FillResultLabel();
            GetResults();
      
        }

        private void GetResults()
        {
            _dataManager.LoadResults(_isWomens);
            _results = _dataManager.GetResutlsList();
        }

        private void FillResultLabel()
        {
         
            var favoriteFifaCode = cbFavoriteTeam.SelectedItem.ToString().Substring(cbFavoriteTeam.SelectedItem.ToString().IndexOf("(") + 1, 3);
            var oppositeFifaCode = cbOppositeTeam.SelectedItem.ToString().Substring(cbOppositeTeam.SelectedItem.ToString().IndexOf("(") + 1, 3);
            long goalsFavoriteTeam = 0;
            long goalsOppostieTeam = 0;
            List<FootballMatch> matchesOppositeTeam = GetMatchesOppositeTeam();
            foreach (FootballMatch match in matchesOppositeTeam)
            {
                if (match.HomeTeam.Code == favoriteFifaCode && match.AwayTeam.Code == oppositeFifaCode)
                {
                    goalsFavoriteTeam = match.HomeTeam.Goals;
                    goalsOppostieTeam = match.AwayTeam.Goals;
                }
                else if (match.AwayTeam.Code == favoriteFifaCode && match.HomeTeam.Code == oppositeFifaCode)
                {
                    goalsFavoriteTeam = match.AwayTeam.Goals;
                    goalsOppostieTeam = match.HomeTeam.Goals;
                }
     
            }
            lblResult.Content = $"{goalsFavoriteTeam} : {goalsOppostieTeam}";

        }
        #region Get methods
        private void GetMatches()
        {
            _dataManager.LoadMaches(_isWomens);
            _matches = _dataManager.GetMatchesList();
        }
        private List<FootballMatch> GetMatchesOppositeTeam()
        {

            _dataManager.LoadMachesByFifaCode(_isWomens, _favoriteFifaCode);
            var matchesOppositeTeam = _dataManager.GetMatchesOppositeTeamList();
            return matchesOppositeTeam;
        }

        private List<Team> GetTeams()
        {

            _dataManager.LoadTeams(_isWomens);
            var teams = _dataManager.GetTeamsList();
            return teams;
        }

        private List<Team> GetOppositeTeams()
        {
            List<Team> oppositeTeams = new();
            List<Team> teams = GetTeams();
            List<FootballMatch> matchesOppositeTeam = GetMatchesOppositeTeam();
            foreach (var item in matchesOppositeTeam)
            {
                if (item.HomeTeam.Code != _favoriteFifaCode)
                {
                    var team = teams.Where(t => t.FifaCode == item.HomeTeam.Code).FirstOrDefault();
                    if (team != null)
                    {
                        oppositeTeams.Add(new Team { Id = team.Id, FifaCode = team.FifaCode, AlternateName = team.AlternateName, Country = team.Country, GroupId = team.GroupId, GroupLetter = team.GroupLetter });
                    }
                }
                if (item.AwayTeam.Code != _favoriteFifaCode && item.AwayTeam.Code != null)
                {
                    var team = teams.Where(t => t.FifaCode == item.AwayTeam.Code).FirstOrDefault();
                    if (team != null)
                    {
                        oppositeTeams.Add(new Team { Id = team.Id, FifaCode = team.FifaCode, AlternateName = team.AlternateName, Country = team.Country, GroupId = team.GroupId, GroupLetter = team.GroupLetter });
                    }
                }
            }
            return oppositeTeams;
        }

        #endregion

        #region Fill methods
        private void FillFavoriteTeamList()
        {
         
            string selectedCountry = cbFavoriteTeam.SelectedItem.ToString();
            _favoriteFifaCode = selectedCountry.Substring(selectedCountry.IndexOf("(") + 1, 3);
         

            FootballMatch matchWithCode = null;
            foreach (var item in _matches)
            {
                if (item.AwayTeam.Code == _favoriteFifaCode)
                {
                    matchWithCode = item;
                    break;
                }
            }
           
            List<Player> players = new List<Player>();
            if (matchWithCode != null)
            {

                foreach (var startingPlayer in matchWithCode.AwayTeamStatistics.StartingEleven)
                {
                    players.Add(startingPlayer);
                }
                foreach (var substiturePlayer in matchWithCode.AwayTeamStatistics.Substitutes)
                {
                    players.Add(substiturePlayer);
                }
            }
            else
            {
                Console.WriteLine($"No matches found with FIFA code {_favoriteFifaCode}");
            }
            lbFavoriteTeam.ItemsSource = players;
          

        }

        private void FillOppositeTeamList()
        {

            string selectedCountry = cbOppositeTeam.SelectedItem.ToString();
            _oppositeFifaCode = selectedCountry.Substring(selectedCountry.IndexOf("(") + 1, 3);


            FootballMatch matchWithCode = null;
            foreach (var item in _matches)
            {
                if (item.AwayTeam.Code == _oppositeFifaCode)
                {
                    matchWithCode = item;
                    break;
                }
                else if (item.HomeTeam.Code == _oppositeFifaCode)
                {
                    matchWithCode = item;
                    break;
                }
            }
            List<Player> players = new List<Player>();
            if (matchWithCode != null)
            {

                foreach (var startingPlayer in matchWithCode.AwayTeamStatistics.StartingEleven)
                {
                    players.Add(startingPlayer);
                }
                foreach (var substiturePlayer in matchWithCode.AwayTeamStatistics.Substitutes)
                {
                    players.Add(substiturePlayer);
                }
            }
            else
            {
                Console.WriteLine($"No matches found with FIFA code {_oppositeFifaCode}");
            }
            lbOppositeTeam.ItemsSource = players;
   


        }

        private void FillFavoriteComboBox()
        {
            cbFavoriteTeam.Items.Clear();
            var teams = GetTeams();
            var sortedTeams = teams.OrderBy(t => t.Country).ToList();
            if (cbFavoriteTeam != null)
            {
                foreach (var item in sortedTeams)
                {
                    
                    cbFavoriteTeam.Items.Add(item);
                }
                cbFavoriteTeam.SelectedIndex = 0;
            }
           
        }

        private void FillOppositeComboBox()
        {

            cbOppositeTeam.Items.Clear();
         
            var team = GetOppositeTeams();
            var sortedTeams = team.OrderBy(t => t.Country).ToList();
            if (cbOppositeTeam != null)
            {
                foreach (var item in sortedTeams)
                {

                    cbOppositeTeam.Items.Add(item);
                }
                cbOppositeTeam.SelectedIndex = 0;
            }

           
        }


        #endregion


        public event EventHandler<OverviewEventArgs> TeamOverview;
        private void Btn_Next_Click(object sender, RoutedEventArgs e)
        {
            string favoriteTeam = cbFavoriteTeam.SelectedItem.ToString().Substring(cbFavoriteTeam.SelectedItem.ToString().IndexOf("(") + 1, 3);
            string oppositeTeam = cbOppositeTeam.SelectedItem.ToString().Substring(cbOppositeTeam.SelectedItem.ToString().IndexOf("(") + 1, 3);
            string result = lblResult.Content.ToString();
            TeamOverview?.Invoke(this, new OverviewEventArgs { FavoriteTeam= favoriteTeam, OppositeTeam= oppositeTeam, Result =result, FootballMatches = _matches});
        }

        private void cbFavoriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FillFavoriteTeamList();
            GetOppositeTeams();
            FillOppositeComboBox();
            FillResultLabel();

        }

        private void cbOppositeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbOppositeTeam.SelectedItem != null)
            {
                FillOppositeTeamList();
                FillResultLabel();
            }


        }
        private void Btn_FavoriteTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            var fifaCode = cbFavoriteTeam.SelectedItem.ToString().Substring(cbFavoriteTeam.SelectedItem.ToString().IndexOf("(") + 1, 3);
       
            Result teamResult = _results.FirstOrDefault(r => r.FifaCode == fifaCode);
            if (teamResult != null)
            {
                OpenCountryInfoWindow(teamResult);
            }
            else
            {
                // Result objekt s FIFA kodom nije pronađen
            }



        }

        private void Btn_OppositeTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            var fifaCode = cbOppositeTeam.SelectedItem.ToString().Substring(cbOppositeTeam.SelectedItem.ToString().IndexOf("(") + 1, 3);
     

            Result teamResult = _results.FirstOrDefault(r => r.FifaCode == fifaCode);
            if (teamResult != null)
            {
                OpenCountryInfoWindow(teamResult);
            }
            else
            {
                // Result objekt s FIFA kodom nije pronađen
            }
        }


        private static void OpenCountryInfoWindow(Result result)
        {
            CountryInfo country = new();
            country.lblName.Content = result.Country;
            country.lblFifaCode.Content = result.FifaCode;
            country.lblGamesPlayed.Content = result.GamesPlayed;
            country.lblWins.Content = result.Wins;
            country.lblLoses.Content = result.Losses;
            country.lblDraws.Content = result.Draws;
            country.lblGoalsFor.Content = result.GoalsFor;
            country.lblGoalsAgainst.Content = result.GoalsAgainst;
            country.lblGoalDifferential.Content = result.GoalDifferential;

            //// Postavi početne vrijednosti za animaciju
            //country.Opacity = 0;
            //country.RenderTransform = new ScaleTransform(0.5, 0.5);

            //// Stvaranje animacije za pomicanje dijaloga s lijeve strane na sredinu
            //ThicknessAnimation moveAnimation = new ThicknessAnimation();
            //moveAnimation.From = new Thickness(-500, 0, 0, 0);
            //moveAnimation.To = new Thickness(0, 0, 0, 0);
            //moveAnimation.Duration = TimeSpan.FromSeconds(2);

            //// Stvaranje animacije za postupno povećavanje prozirnosti dijaloga
            //DoubleAnimation opacityAnimation = new DoubleAnimation();
            //opacityAnimation.From = 0;
            //opacityAnimation.To = 1;
            //opacityAnimation.Duration = TimeSpan.FromSeconds(3);

            //// Pokretanje animacija
            //country.BeginAnimation(FrameworkElement.MarginProperty, moveAnimation);
            //country.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
            //Storyboard.SetTargetProperty(moveAnimation, new PropertyPath(FrameworkElement.MarginProperty));
            //Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            //// Stvaranje storyboarda i dodavanje animacija
            //Storyboard storyboard = new Storyboard();
            //storyboard.Children.Add(moveAnimation);
            //storyboard.Children.Add(opacityAnimation);
            //storyboard.Begin(country);




            country.ShowDialog();
        }



      
    }
}
