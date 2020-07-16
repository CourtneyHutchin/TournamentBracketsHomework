using CourtneyHutchinTournamentBrackets.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Courtney Hutchin
// CPW 205
// Brackets Program Phase One

// NOTE: The groupboxes are just used on the form itself for a break down of each game visually

namespace CourtneyHutchinTournamentBrackets
{
    public partial class TournamentBracketForm : Form
    {
        // Arrays to hold pieces of the text file
        private List<string> tournamentElementInfo;
        private string[,] tournament;

        // Player info
        private const int PlayerName = 0;
        private const int gameOneScore = 1;
        private const int gameTwoScore = 2;
        private const int gameThreeScore = 3;
        
        // Players
        private int PlayerOne { get; set; }
        private int PlayerTwo { get; set; }
        private int PlayerThree { get; set; }
        private int PlayerFour { get; set; }
        private int PlayerFive { get; set; }
        private int PlayerSix { get; set; }
        private int PlayerSeven { get; set; }
        private int PlayerEight { get; set; }

        public TournamentBracketForm()
        {
            InitializeComponent();

            // Grab the tournament text file
            string filePath = Resources.tournament;

            // Create a list to hold elements from txt file in
            tournamentElementInfo = new List<String>();

            // https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
            // Split each line into the new array
            string[] file = filePath.Split(new[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries).ToArray();

            // Loop through the line and split each element
            foreach (string line in file)
            {
                // split by using the whitespace
                string[] linesAsArray = line.Split(' ');

                // Loop through each element in the array
                foreach (string word in linesAsArray)
                {
                    // Add into array
                    tournamentElementInfo.Add(word);
                }
            }
        }

        private void TournamentBracketForm_Load(object sender, EventArgs e)
        {
            int numPlayers = 8;    // There are eight lines one player per line
            int numPlayerInfo = 4; // There are four pieces of info per line in the tournament txt file

            // Create a 2d array to hold players and their info(scores)
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
            string[,] tournamentInfoArr = new string[numPlayers, numPlayerInfo];

            // Hold the index of the file so the info gets added in the correct order 
            int fileListIndex = 0;

            // Loop through the array and add the values to another array
            for (int i = 0; i < numPlayers; i++) {
                for (int j = 0; j < numPlayerInfo; j++)
                {
                    tournamentInfoArr[i, j] = tournamentElementInfo[fileListIndex];
                    fileListIndex++;
                }
            }
            tournament = tournamentInfoArr;
        }

        private void CreateTournamentBtn_Click(object sender, EventArgs e)
        {
            // Create a list to store the players in
            List<int> newPlayerNum = new List<int>();

            // Assign the players numbers so that it can be randoms
            PlayerOne = GetRandomPlayerNum(newPlayerNum);
            PlayerTwo = GetRandomPlayerNum(newPlayerNum);
            PlayerThree = GetRandomPlayerNum(newPlayerNum);
            PlayerFour = GetRandomPlayerNum(newPlayerNum);
            PlayerFive = GetRandomPlayerNum(newPlayerNum);
            PlayerSix = GetRandomPlayerNum(newPlayerNum);
            PlayerSeven = GetRandomPlayerNum(newPlayerNum);
            PlayerEight = GetRandomPlayerNum(newPlayerNum);

            // Add text into form
            Game1Slot1Txt.Text = $"{tournament[PlayerOne, PlayerName]} {tournament[PlayerOne, gameOneScore]}";
            Game1Slot2Txt.Text = $"{tournament[PlayerTwo, PlayerName]} {tournament[PlayerTwo, gameOneScore]}";
            Game1Slot3Txt.Text = $"{tournament[PlayerThree, PlayerName]} {tournament[PlayerThree, gameOneScore]}";
            Game1Slot4Txt.Text = $"{tournament[PlayerFour, PlayerName]} {tournament[PlayerFour, gameOneScore]}";
            Game1Slot5Txt.Text = $"{tournament[PlayerFive, PlayerName]} {tournament[PlayerFive, gameOneScore]}";
            Game1Slot6Txt.Text = $"{tournament[PlayerSix, PlayerName]} {tournament[PlayerSix, gameOneScore]}";
            Game1Slot7Txt.Text = $"{tournament[PlayerSeven, PlayerName]} {tournament[PlayerSeven, gameOneScore]}";
            Game1Slot8Txt.Text = $"{tournament[PlayerEight, PlayerName]} {tournament[PlayerEight, gameOneScore]}";

            // Broken down per sub-bracket p1 vs p2. p3 vs p4 etc
            int gameOneWinnerOne;
            int gameOneWinnerTwo;
            int gameOneWinnerThree;
            int gameOneWinnerFour;

            // Winners from game 2
            int gameTwoWinnerOne;
            int gameTwoWinnerTwo;

            // Finialists
            int firstPlaceWinner;
            int secondPlaceWinner;

            // Check for winner of player 1 vs player 2
            if (Convert.ToInt32(tournament[PlayerOne, gameOneScore]) > Convert.ToInt32(tournament[PlayerTwo, gameOneScore]))
            {
                Game2Slot1Txt.Text = $"{tournament[PlayerOne, PlayerName]} {tournament[PlayerOne, gameTwoScore]}";
                gameOneWinnerOne = PlayerOne;
            }
            else
            {
                Game2Slot1Txt.Text = $"{tournament[PlayerTwo, PlayerName]} {tournament[PlayerTwo, gameTwoScore]}";
                gameOneWinnerOne = PlayerTwo;
            }

            // 3 vs 4
            if (Convert.ToInt32(tournament[PlayerThree, gameOneScore]) > Convert.ToInt32(tournament[PlayerFour, gameOneScore]))
            {
                Game2Slot2Txt.Text = $"{tournament[PlayerThree, PlayerName]} {tournament[PlayerThree, gameTwoScore]}";
                gameOneWinnerTwo = PlayerThree;
            }
            else
            {
                Game2Slot2Txt.Text = $"{tournament[PlayerFour, PlayerName]} {tournament[PlayerFour, gameTwoScore]}";
                gameOneWinnerTwo = PlayerFour;
            }

            // 5 vs 6
            if (Convert.ToInt32(tournament[PlayerFive, gameOneScore]) > Convert.ToInt32(tournament[PlayerSix, gameOneScore]))
            {
                Game2Slot3Txt.Text = $"{tournament[PlayerFive, PlayerName]} {tournament[PlayerFive, gameTwoScore]}";
                gameOneWinnerThree = PlayerFive;
            }
            else
            {
                Game2Slot3Txt.Text = $"{tournament[PlayerSix, PlayerName]} {tournament[PlayerSix, gameTwoScore]}";
                gameOneWinnerThree = PlayerSix;
            }

            // 7 vs 8
            if (Convert.ToInt32(tournament[PlayerSeven, gameOneScore]) > Convert.ToInt32(tournament[PlayerEight, gameOneScore]))
            {
                Game2Slot4Txt.Text = $"{tournament[PlayerSeven, PlayerName]} {tournament[PlayerSeven, gameTwoScore]}";
                gameOneWinnerFour = PlayerSeven;
            }
            else
            {
                Game2Slot4Txt.Text = $"{tournament[PlayerEight, PlayerName]} {tournament[PlayerEight, gameTwoScore]}";
                gameOneWinnerFour = PlayerEight;
            }

            //                                          GAME TWO

            // Game 2 bracket 1 winner vs Game 2 bracket 2 winner
            if (Convert.ToInt32(tournament[gameOneWinnerOne, gameTwoScore]) > Convert.ToInt32(tournament[gameOneWinnerTwo, gameTwoScore]))
            {
                Game3Slot1Txt.Text = $"{tournament[gameOneWinnerOne, PlayerName]} {tournament[gameOneWinnerOne, gameThreeScore]}";
                gameTwoWinnerOne = gameOneWinnerOne;
            }
            else
            {
                Game3Slot1Txt.Text = $"{tournament[gameOneWinnerTwo, PlayerName]} {tournament[gameOneWinnerTwo, gameThreeScore]}";
                gameTwoWinnerOne = gameOneWinnerTwo;
            }

            // Game 2 bracket 3 winner vs Game 2 bracket 4 winner
            if (Convert.ToInt32(tournament[gameOneWinnerThree, gameTwoScore]) > Convert.ToInt32(tournament[gameOneWinnerFour, gameTwoScore]))
            {
                Game3Slot2Txt.Text = $"{tournament[gameOneWinnerThree, PlayerName]} {tournament[gameOneWinnerThree, gameThreeScore]}";
                gameTwoWinnerTwo = gameOneWinnerThree;
            }
            else
            {
                Game3Slot2Txt.Text = $"{tournament[gameOneWinnerFour, PlayerName]} {tournament[gameOneWinnerFour, gameThreeScore]}";
                gameTwoWinnerTwo = gameOneWinnerFour;
            }

            //                                          GAME THREE

            if (Convert.ToInt32(tournament[gameTwoWinnerOne, gameThreeScore]) > Convert.ToInt32(tournament[gameTwoWinnerTwo, gameThreeScore]))
            {
                firstPlaceWinner = gameTwoWinnerOne;
                secondPlaceWinner = gameTwoWinnerTwo;
            }
            else
            {
                firstPlaceWinner = gameTwoWinnerTwo;
                secondPlaceWinner = gameTwoWinnerOne;
            }

            // Display winners
            FirstPlaceTxt.Text = $"{tournament[firstPlaceWinner, PlayerName]} $25";
            SecondPlaceTxt.Text = $"{tournament[secondPlaceWinner, PlayerName]} $10";
        }

        /// <summary>
        /// Gives a player a random number
        /// </summary>
        /// <param name="assignPlayerNums"></param>
        /// <returns></returns>
        private int GetRandomPlayerNum(List<int> newPlayerNum)
        {
            Random randNum = new Random();

            bool goAgain = true;
            int playerNum = -1;

            while (goAgain)
            {
                // get a random num 
                int num = randNum.Next(0, 8);

                // if nobody has that number...assign it
                if (!newPlayerNum.Contains(num))
                {
                    newPlayerNum.Add(num);
                    goAgain = false;
                    playerNum = num;
                }
                else // if someone DOES have that number
                {
                    goAgain = true; // go through the loop again
                }
            }
            return playerNum;
        }
    }
}
