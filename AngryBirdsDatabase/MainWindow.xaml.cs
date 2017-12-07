﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AngryBirdsDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext context = new MyContext();

        Player player;
        Player player2;
        Player playerviewScore;

        List<Score> ScoresList;
      

        public MainWindow()
        {
            InitializeComponent();
            //gör relationerna mellan tabellerna enligt normaliseringstabellen 3.

            //En spelare ska ha ett namn.
            //En bana ska ha antal tillgängliga fåglar. (antal drag som man har på sig för att klara banan)
            //Poängen för en spelare på en specifik bana(dvs antal drag) ska också finnas i databasen.

            // tredje normaliseringsformen? :

            /*De olika tabellerna:
             * Players :
             * -PlayerId(name)
             * - Currentlevel(Levelid)
             * - TotalScore
             * 
             * Levels
             * - PlayerId
             * - LevelId
             * - Birds
             * 
             
             * 
             * Scores
             * -PlayerId
             * -LevelId
             * -Score
             * -Birds left
             * 
             
             
             */

            using (var ctx = new MyContext())
            {
                var t = ctx.Players.Count();
                //Console.WriteLine(t);
            }

            AddDataToListBoxes();
         
            Console.ReadLine();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
           var playerNames = context.Players.Select(s => s.PlayerName);
          
                string userName = UsernameTextBox.Text;

            if (UsernameTextBox.Text != "")
            {
                if (!playerNames.Contains(userName))
                {

                    player = new Player { PlayerName = userName };

                    context.Players.Add(player);
                }
                               
            }

                if (LevelTextBox.Text != "" || ScoreTextBox.Text != "")
                {
                try
                {

                    int levelNumber = int.Parse(LevelTextBox.Text);
                    int choosenScore = int.Parse(ScoreTextBox.Text);


                    var checkscore = context.Levels.Where(s => s.LevelKey == levelNumber).Select(x => x.Birds).Single();

                    if (choosenScore <= checkscore)
                    {



                        var selectedPlayer = context.Scores.Where(s => s.Level.LevelKey == levelNumber && s.Player.PlayerName == userName).Select(x => x).Single();
                        var newScore = selectedPlayer.LevelScore = choosenScore;

                        context.Entry(selectedPlayer).CurrentValues.SetValues(newScore);


            context.SaveChanges();
                    }
                else
                {
                    MessageBox.Show("Score is too high!");
                }

                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid input");
                }

            }


            PlayerListBox.Items.Clear();
            LevelListbox.Items.Clear();
            ScoreListBox.Items.Clear();
            ViewScoreOnePlayerListbox.Items.Clear();
            AddDataToListBoxes();

           
          //var selectedPlayer = context.Scores.Where(s => s.Player.PlayerName == userName);

          //  ScoreListBox.Items.Add(selectedPlayer);

        }
        private void AddDataToListBoxes()
        {
            

            var allPlayers = context.Players.ToList();
              

            foreach (var p in allPlayers)
            {
                PlayerListBox.Items.Add("Id: "+p.PlayerKey +" Name: "+p.PlayerName);
            
            }

            var getLevels = context.Levels.ToList();

            foreach (var l in getLevels)
            {
                LevelListbox.Items.Add("Level "+l.LevelKey + " ,total Birds: " + l.Birds);
            }


            ScoresList = context.Scores.ToList();


            foreach (var s in ScoresList)
            {

                ScoreListBox.Items.Add($"{s.ScoreKey}. Level: {s.Level.LevelKey} {s.Player.PlayerName} Score: {s.LevelScore} Birdsleft: {s.Level.Birds - s.LevelScore}");
            }

        }

        private void AddLevelButton_Click(object sender, RoutedEventArgs e)
        {
            

            string NumberOfBirds = AddLevelBirdsTextBox.Text;
            try
            {
                Level levelNumber = new Level { Birds = int.Parse(NumberOfBirds) };
                context.Levels.Add(levelNumber);
            }
            catch (Exception)
            {
                MessageBox.Show("Only digits valid.");
            }

            context.SaveChanges();

            LevelListbox.Items.Clear();
            PlayerListBox.Items.Clear();
            ScoreListBox.Items.Clear();

            AddLevelBirdsTextBox.Clear();

            AddDataToListBoxes();
        }

        private void ViewScoreButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateViewScore();
        }

        private void AddLevelBirdsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AddLevelBirdsTextBox.Text != "")
            {
                AddLevelButton.IsEnabled = true;
            }

            else
                AddLevelButton.IsEnabled = false;
        }
        private void UpdateViewScore()
        {
            string user = UsernameTextBox.Text;

            ViewScoreOnePlayerListbox.Items.Clear();

            if (UsernameTextBox.Text != "")
            {
                var selectedPlayer = context.Players.Where(p => p.PlayerName == user).Single();

                //var numberOfBirds = context.Levels.Select(s => s.Birds).ToList();
                //var score = context.Scores.Select(s => s.LevelScore).ToList();
                //int birdsLeft = numberOfBirds - score;

                var list = selectedPlayer.Scores;

                int totalScore = selectedPlayer.Scores.Select(p => p.LevelScore).Sum();

                foreach (var x in list)
                {
                    ViewScoreOnePlayerListbox.Items.Add($"Level: {x.Level.LevelKey} Score: {x.LevelScore}  ({x.Level.Birds - x.LevelScore} birds left)");

                }
                ViewScoreOnePlayerListbox.Items.Add("Total score: " + totalScore);
            }
        }

        private void AddNewScoreButton_Click(object sender, RoutedEventArgs e)
        {

            var playerNames = context.Players.Select(s => s.PlayerName);


            if (LevelTextBox.Text != "" || ScoreTextBox.Text != "")
            {
                try
                {
                    Score score2;
                    string userName = UsernameTextBox.Text;
                    int levelNumber = int.Parse(LevelTextBox.Text);
                    int choosenScore = int.Parse(ScoreTextBox.Text);

                    var selectedLevelKey = context.Levels.Where(s => s.LevelKey == levelNumber).Select(x => x).Single();

                    var checkscore = context.Levels.Where(s => s.LevelKey == levelNumber).Select(x => x.Birds).Single();

                    if (choosenScore <= checkscore)
                    {
                        if (!playerNames.Contains(userName))
                        {


                            player2 = new Player { PlayerName = userName };

                            score2 = new Score { LevelScore = choosenScore, Level = selectedLevelKey, Player = player2 };

                        }
                        else
                        {

                            var searchPlayer = context.Players.Where(p => p.PlayerName == userName).Select(x => x).Single();

                            score2 = new Score { LevelScore = choosenScore, Level = selectedLevelKey, Player = searchPlayer };
                        }

                        context.Scores.Add(score2);
                    context.SaveChanges();
                    }

                    else
                    {
                        MessageBox.Show("Score is too high!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid input");
                }

                PlayerListBox.Items.Clear();
                ScoreListBox.Items.Clear();
                LevelListbox.Items.Clear();
                ViewScoreOnePlayerListbox.Items.Clear();

                AddDataToListBoxes();
            }
        }

        
    }


}
