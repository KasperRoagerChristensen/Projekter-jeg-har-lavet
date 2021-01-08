using System;
using System.Windows;
using System.Windows.Controls;

namespace Gui_Programmering
{
    /// <summary>
    /// Interaction logic for SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        Game game;


        public SubWindow(string p1ID, string p2ID)
        {
            InitializeComponent();

            game = new Game(p1ID, p2ID, infoBoard);


        }


        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRetry_Click(object sender, RoutedEventArgs e)
        {
            b1.Content = "#";
            b2.Content = "#";
            b3.Content = "#";
            b4.Content = "#";
            b5.Content = "#";
            b6.Content = "#";
            b7.Content = "#";
            b8.Content = "#";
            b9.Content = "#";
            game.playerTurn = 0;
            game.place[0] = 0;
            game.place[1] = 0;
            infoBoard.Clear();
        }


        private void btn_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = game.btnUpdate(Convert.ToInt32((sender as Button).Name.Trim('b')), Convert.ToChar((sender as Button).Content.ToString()));
            game.checkForWin();
        }
    }

    public class Game
    {
        char fieldEmpty = '#';
        char fieldp1 = 'X';
        char fieldp2 = 'O';
        char[] field = new char[9];
        char[] symbols = { 'X', 'O' };

        TextBox textBox;

        string[] playerID = new string[2];
        public int[] place = new int[2]; // stores amount of X/O
        public int playerTurn = 0;
        public Game(string ID1, string ID2, TextBox box)
        {
            playerID[0] = ID1;
            playerID[1] = ID2;
            place[0] = 0;
            place[1] = 0;
            textBox = box;
        }

        public string btnUpdate(int id, char content)
        {
            string newContent = "!";
            if (content == fieldEmpty && place[playerTurn] < 3)
            {
                newContent = playerTurn == 0 ? "X" : "O";

            }
            else if (content == fieldp1 && playerTurn == 0 && place[0] > 2)
            {
                place[0] = 2;
                field[id - 1] = '#';
                return "#";

            }
            else if (content == fieldp2 && playerTurn == 1 && place[1] > 2)
            {
                place[1] = 2;
                field[id - 1] = '#';
                return "#";
            }



            if (newContent == "X")
            {
                place[0] = place[0] + 1;
                field[id - 1] = Convert.ToChar(newContent);
                // changes player
                playerTurn = playerTurn == 0 ? 1 : 0;
                return newContent;
            }
            else if (newContent == "O")
            {
                place[1] = place[1] + 1;
                field[id - 1] = Convert.ToChar(newContent);
                // changes player
                playerTurn = playerTurn == 0 ? 1 : 0;
                return newContent;
            }
            else if (newContent == "#")
            {
                field[id - 1] = Convert.ToChar(newContent);
                return newContent;
            }
            else
            {
                return content.ToString();
            }

        }


        public void checkForWin()
        {
            playerTurn = playerTurn == 0 ? 1 : 0;
            if (field[0] == symbols[playerTurn] && field[1] == symbols[playerTurn] && field[2] == symbols[playerTurn] || field[3] == symbols[playerTurn] && field[4] == symbols[playerTurn] && field[5] == symbols[playerTurn] ||
                field[6] == symbols[playerTurn] && field[7] == symbols[playerTurn] && field[8] == symbols[playerTurn] || field[0] == symbols[playerTurn] && field[3] == symbols[playerTurn] && field[6] == symbols[playerTurn] ||
                field[1] == symbols[playerTurn] && field[4] == symbols[playerTurn] && field[7] == symbols[playerTurn] || field[2] == symbols[playerTurn] && field[5] == symbols[playerTurn] && field[8] == symbols[playerTurn] ||
                field[0] == symbols[playerTurn] && field[4] == symbols[playerTurn] && field[8] == symbols[playerTurn] || field[2] == symbols[playerTurn] && field[4] == symbols[playerTurn] && field[6] == symbols[playerTurn]) // checks for player win
            {
                textBox.Text = $"{playerID[playerTurn]} has won";
            }
            playerTurn = playerTurn == 0 ? 1 : 0;
        }
    }
}
