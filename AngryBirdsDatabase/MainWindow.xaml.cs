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
            

            string userName = UsernameTextBox.Text;

           player= new Player { PlayerName = userName };

            context.Players.Add(player);

            if (LevelTextBox.Text != "" || ScoreTextBox.Text!="")
            {

                string level = LevelTextBox.Text;

                Level levelNumber = new Level { LevelKey = int.Parse(level) };
                context.Levels.Add(levelNumber);

                string score = ScoreTextBox.Text;
                context.Scores.Add(new Score { Player = player, Level = levelNumber, LevelScore =int.Parse(score) });
            }
           //fixa listbox så att players läggs in där

            context.SaveChanges();

            PlayerListBox.Items.Clear();
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

                ScoreListBox.Items.Add($"{s.ScoreKey}. Level: {s.Level.LevelKey} {s.Player.PlayerName} Score: {s.LevelScore} ");
            }


        }

       
    }


}
