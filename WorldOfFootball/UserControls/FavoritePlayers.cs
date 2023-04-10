﻿using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldOfFootball.CustomDesign;
using WorldOfFootball.EventsAndArgs;

namespace WorldOfFootball.UserControls
{
    public partial class FavoritePlayers : UserControl
    {
       
        private List<FootballMatch> _matches;
        private string _fifaCode;
        private PlayerForm _playerForm;
        private List<Player> _players;
        public FavoritePlayers(List<FootballMatch> matches, string fifaCode)
        {
            InitializeComponent();
            _matches = matches;
            _fifaCode = fifaCode;   
            FillAllPlayersPanel();
          
          
        }

        private void FillAllPlayersPanel()
        {

            FootballMatch matchWithCode = null;
            foreach (var item in _matches)
            {
                if (item.AwayTeam.Code == _fifaCode)
                {
                    matchWithCode = item;
                    break;
                }
            }
            _players = new List<Player>();
            if (matchWithCode != null)
            {

                foreach (var startingPlayer in matchWithCode.AwayTeamStatistics.StartingEleven)
                {
                    _players.Add(startingPlayer);
                }
                foreach (var substiturePlayer in matchWithCode.AwayTeamStatistics.Substitutes)
                {
                    _players.Add(substiturePlayer);
                }
            }
            else
            {
                Console.WriteLine($"No matches found with FIFA code {_fifaCode}");
            }

            LoadPlayerFormLabel();

        }

        private void LoadPlayerFormLabel()
        {
            foreach (var player in _players)
            {
                _playerForm = new PlayerForm();
           
                _playerForm.Name = player.ShirtNumber.ToString();
                Label lblName = _playerForm.Controls.Find("lblName", true).FirstOrDefault() as Label;
                lblName.Text = player.Name;
                Label lblNumber = _playerForm.Controls.Find("lblNumber", true).FirstOrDefault() as Label;
                lblNumber.Text = player.ShirtNumber.ToString();
                Label lblPosition = _playerForm.Controls.Find("lblPosition", true).FirstOrDefault() as Label;
                lblPosition.Text = player.Position;
                PictureBox pbCapitan = _playerForm.Controls.Find("pbCapitan", true).FirstOrDefault() as PictureBox;
                if (player.Captain)
                {
                    pbCapitan.Visible = true;
                }
                else
                {
                    pbCapitan.Visible = false;
                }
                PictureBox pbStar = _playerForm.Controls.Find("pbStar", true).FirstOrDefault() as PictureBox;
                OvalPictureBox pbImage = _playerForm.Controls.Find("pbImage", true).FirstOrDefault() as OvalPictureBox;
                pbImage.Image = Image.FromFile(player.ImagePath);
               // pbImage = ImageLayout.Stretch;
                pbStar.Visible = false;
                _playerForm.MouseDown += PlayerForm_MouseMove;
                Button btnPicture = _playerForm.Controls.Find("btnPicture", true).FirstOrDefault() as Button;
                btnPicture.Click += BtnChangeImage_Click;



                pnlAllPlayers.Controls.Add(_playerForm);
            }

        }

        private void BtnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Slike|*.jpg;*.jpeg;*.png;*.bmp|Sve datoteke|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog.FileName);
                string newPath = Path.Combine("..//..//..//..//DataLayer//Resources//", fileName);
                File.Copy(openFileDialog.FileName, newPath, true);

                // Pronalazimo kontrolu koja je pokrenula događaj
                Button clickedBtn = (Button)sender;
                PlayerForm clickedPlayerForm = (PlayerForm)clickedBtn.Parent;
                if (clickedPlayerForm == null)
                {
                    return;
                }
                OvalPictureBox pbImage = clickedPlayerForm.Controls.Find("pbImage", true).FirstOrDefault() as OvalPictureBox;
                pbImage.Image = new Bitmap(openFileDialog.FileName);
                // Get the shirt number of the player from the player form's Name property
                var shirtNumber = int.Parse(clickedPlayerForm.Name);
                var player = _players.FirstOrDefault(p => p.ShirtNumber == shirtNumber);
                if (player == null)
                {
                    return;
                }
                player.ImagePath = newPath;
            }
         

        }

        private void PlayerForm_MouseMove(object sender, MouseEventArgs e)
        {
            PlayerForm player = sender as PlayerForm;
            player?.DoDragDrop(player, DragDropEffects.Move);
        
            player.IsSelected = !player.IsSelected;
            if (player.IsSelected)
            {
                player.BackColor = Color.FromArgb(50, 130, 184);
            }
            else
            {
                player.BackColor = Color.FromArgb(15,76,117);
            }
        }
        

        private void PnlFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            PlayerForm draggedPlayer = e.Data?.GetData(typeof(PlayerForm)) as PlayerForm;
            if (draggedPlayer != null)
            {
                bool isPlayerAlreadyAdded = IsPlayerAdded(draggedPlayer, pnlFavoritePlayers);
                if (!isPlayerAlreadyAdded)
                {
                    if (pnlFavoritePlayers.Controls.Count < 3)
                    {

                        AddPlayer(draggedPlayer, pnlFavoritePlayers, pnlAllPlayers);

                    }
                    else
                    {
                        MessageBox.Show("Možete prenijeti najviše tri igrača u omiljene igrače.");
                    }
                }
                

            }
           

        }

        
        private void PnlFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        

        private void PnlAllPlayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void PnlAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            PlayerForm draggedPlayer = e.Data?.GetData(typeof(PlayerForm)) as PlayerForm;
            if (draggedPlayer != null)
            {
                bool isPlayerAlreadyAdded = IsPlayerAdded(draggedPlayer, pnlAllPlayers);

                // Dodaje novog igrača samo ako već nije dodan na pnlFavoritePlayers kontrolu
                if (!isPlayerAlreadyAdded)
                {

                    AddPlayer(draggedPlayer, pnlAllPlayers, pnlFavoritePlayers);
                }
            }
        }

        private void AddPlayer(PlayerForm draggedPlayer, FlowLayoutPanel addToPnl,
           FlowLayoutPanel removeFromPnl)
        {
            PlayerForm newPlayer = AddNewPlayerForm(draggedPlayer);
            Point mouseLocation = MousePosition;
            mouseLocation = addToPnl.PointToClient(mouseLocation);
            newPlayer.Location = mouseLocation;
            newPlayer.MouseDown += PlayerForm_MouseMove;
            addToPnl.Controls.Add(newPlayer);
            removeFromPnl.Controls?.Remove(draggedPlayer);
        }

        private bool IsPlayerAdded(PlayerForm draggedPlayer, FlowLayoutPanel panel)
        {
            bool isPlayerAlreadyAdded = false;
            foreach (PlayerForm player in panel.Controls)
            {
                if (player.Name == draggedPlayer.Name)
                {
                    isPlayerAlreadyAdded = true;
                    break;
                }
            }

            return isPlayerAlreadyAdded;
        }

        private PlayerForm AddNewPlayerForm(PlayerForm draggedPlayer)
        {
            PlayerForm newPlayer = new PlayerForm();
            newPlayer.Name = draggedPlayer.Name;
            Label lblName = newPlayer.Controls.Find("lblName", true).FirstOrDefault() as Label;
            lblName.Text = draggedPlayer.Controls.Find("lblName", true).FirstOrDefault().Text;
            Label lblNumber = newPlayer.Controls.Find("lblNumber", true).FirstOrDefault() as Label;
            lblNumber.Text = draggedPlayer.Controls.Find("lblNumber", true).FirstOrDefault().Text;
            Label lblPosition = newPlayer.Controls.Find("lblPosition", true).FirstOrDefault() as Label;
            lblPosition.Text = draggedPlayer.Controls.Find("lblPosition", true).FirstOrDefault().Text;
            PictureBox pbCapitan = newPlayer.Controls.Find("pbCapitan", true).FirstOrDefault() as PictureBox;
            pbCapitan.Visible = draggedPlayer.Controls.Find("pbCapitan", true).FirstOrDefault().Visible;
            PictureBox pbStar = newPlayer.Controls.Find("pbStar", true).FirstOrDefault() as PictureBox;
            if (pbStar.Visible == draggedPlayer.Controls.Find("pbStar", true).FirstOrDefault().Visible)
            {
                pbStar.Visible = false;
            }
            else
            {
                pbStar.Visible = true;
            }
            OvalPictureBox pbImage = newPlayer.Controls.Find("pbImage", true).FirstOrDefault() as OvalPictureBox;
            pbImage.Image = draggedPlayer.Controls.OfType<PictureBox>().FirstOrDefault()?.Image;

          
            Button btnPicture = _playerForm.Controls.Find("btnPicture", true).FirstOrDefault() as Button;
            btnPicture.Click += BtnChangeImage_Click;

            return newPlayer;

        }

        private void PbLeft_Click(object sender, EventArgs e)
        {
            List<PlayerForm> selectedPlayers = new List<PlayerForm>();
            foreach (PlayerForm playerForm in pnlFavoritePlayers.Controls)
            {
                if (playerForm.IsSelected)
                {
                    selectedPlayers.Add(playerForm);
                }


            }
            foreach(PlayerForm playerForm in selectedPlayers)
            {
                bool isPlayerAlreadyAdded = IsPlayerAdded(playerForm, pnlAllPlayers);
                if (!isPlayerAlreadyAdded)
                {
                    AddPlayer(playerForm, pnlAllPlayers, pnlFavoritePlayers);
                }
            }
                    
        }




        

        private void PbRight_Click(object sender, EventArgs e)
        {
            List<PlayerForm> selectedPlayers = new List<PlayerForm>();
            foreach (PlayerForm playerForm in pnlAllPlayers.Controls)
            {
                if (playerForm.IsSelected)
                {
                    selectedPlayers.Add(playerForm);
                }


            }


            foreach (PlayerForm playerForm in selectedPlayers)
            {
                bool isPlayerAlreadyAdded = IsPlayerAdded(playerForm, pnlFavoritePlayers);
                if (!isPlayerAlreadyAdded)
                {
                    if (pnlFavoritePlayers.Controls.Count < 3)
                    {
                        AddPlayer(playerForm, pnlFavoritePlayers, pnlAllPlayers);

                    }
                    else
                    {
                        MessageBox.Show("Možete prenijeti najviše tri igrača u omiljene igrače.");
                    }
                }
                



            }
            
        }








    }




}
