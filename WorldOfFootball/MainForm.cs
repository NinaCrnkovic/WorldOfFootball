using DataLayer.Model;
using Newtonsoft.Json;
using System.Globalization;
using WorldOfFootball.EventsAndArgs;
using WorldOfFootball.UserControls;

namespace WorldOfFootball
{
    public partial class MainForm : Form
    {
        
        private DataManager _dataManager = new DataManager();
        private TitleForm _titleForm;
        private LanguageAndChampionship _languageAndChampionshipForm;
        private FavoriteTeam _favoriteTeamForm;
        private FavoritePlayers _favoritePlayersForm;
        private RankingLists _rankingListsForm;
        private bool _isWomens;
        private string _language;
        private string _fifaCode;
   
        public MainForm()
        {

            CallTitleForm();
            InitializeComponent();
            
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {

            await _dataManager.LoadTeams(false);

            CallLanguageAndChampionshipForm();
      


        }

        #region Call Forms
        private void CallTitleForm()
        {
            _titleForm = new TitleForm();
            this.Controls.Add(_titleForm);
            _titleForm.BringToFront();

            // Stvori novi timer sa vremenom ka�njenja od 15 sekundi
            System.Windows.Forms.Timer timer = new ();
            timer.Interval = 1500;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void CallLanguageAndChampionshipForm()
        {
            _languageAndChampionshipForm = new LanguageAndChampionship();
            _languageAndChampionshipForm.LangAndChamp += BtnNextLangAndChamp_Click;
            _languageAndChampionshipForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(_languageAndChampionshipForm);
        }
        private async void CallFavoriteTeamForm(bool isWomens)
        {
            await _dataManager.LoadTeams(isWomens);
            var teams = _dataManager.GetTeamsList();
            _favoriteTeamForm = new FavoriteTeam(teams);
            _favoriteTeamForm.Dock = DockStyle.Fill;
            _favoriteTeamForm.FavoriteTeamSelected += BtnNextFavoiriteTeam_Click;
            pnlContainer.Controls.Add(_favoriteTeamForm);

        }

        private async void CallFavoritePlayersForm(bool isWomens)
        {
            await _dataManager.LoadMaches(isWomens);
            var matches = _dataManager.GetMatchesList();
            _favoritePlayersForm = new FavoritePlayers(matches, _fifaCode);
            _favoritePlayersForm.Dock = DockStyle.Fill;
            _favoritePlayersForm.FavoritePlayersList += BtnNextFavoritePlayers_Click;
            pnlContainer.Controls.Add(_favoritePlayersForm);
        }
        private void CallRankingListForm(List<Player> allPlayersForCountry, string fifaCode)
        {
            var matches = _dataManager.GetMatchesList();
            _rankingListsForm = new RankingLists(matches, allPlayersForCountry, fifaCode);
            _rankingListsForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(_rankingListsForm);

        }


        #endregion



        #region Events on Buttons in Forms
        private void BtnNextLangAndChamp_Click(object sender, LanguageAndChampionshipEventArgs e)
        {
            // Spremi odabrani jezik i prvenstvo u RepositoryConfig objekt
            var settings = new InitialWoFSettings
            {
                Language = e.Language,
                Championship = e.Championship
            };
            _dataManager.SaveInitialSettingsToRepo(settings);
            _language = settings.Language;
            if (settings.Championship == "Mens")
            {
                _isWomens = false;
            }
            else
            {
                _isWomens = true;
            }
            SetLanguage();
            CallFavoriteTeamForm(_isWomens);
            _languageAndChampionshipForm.Dispose();

        }
        private void BtnNextFavoiriteTeam_Click(object sender, FavoriteTeamEventArgs e)
        {
            var favoriteTeam = e.favoriteTeam;
            _fifaCode = favoriteTeam.FifaCode;
      
            CallFavoritePlayersForm(_isWomens);
            _favoriteTeamForm.Dispose();

        }

        private void BtnNextFavoritePlayers_Click(object sender, FavoritePlayersTeamEventArgs e)
        {
            var favoritePlayers = e.FavoritePlayersList;
            var allNotFavoritePlayers = e.NotFavoritePlayersList;
            var allPlayersForCountry = e.AllPlayers;
            string fifaCode = e.FifaCodeFavCountry;

            _dataManager.SaveFavoritePlayersToRepo(favoritePlayers, allNotFavoritePlayers, fifaCode);
            CallRankingListForm(allPlayersForCountry, fifaCode);
            _favoritePlayersForm.Dispose();
        }

       


        #endregion

        #region Methods
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Zaustavi timer
            ((System.Windows.Forms.Timer)sender).Stop();

            // Ukloni TitleForm iz glavne forme
            this.Controls.Remove(_titleForm);

            // Oslobodi resurse
            _titleForm.Dispose();
        }

        private void SetLanguage()
        {
            if (_language == null)
            {
                MessageBox.Show("Nije izabran jezik");
            }
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo(_language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_language);
            
          
          
        }


        #endregion

        private void PnlContainer_Click(object sender, EventArgs e)
        {
            CallLanguageAndChampionshipForm();
        }
    }
}