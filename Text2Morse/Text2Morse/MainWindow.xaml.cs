using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Text2Morse
{
    public class ConvertList
    {
        public string PartLetter { get; set; }

        public string PartMorse { get; set; }

        public override string ToString()
        {
            return "ID: " + PartMorse + "   Name: " + PartLetter;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ConvertList> table = new List<ConvertList>();
        public MainWindow()
        {
            table.Add(new ConvertList() { PartLetter = "E", PartMorse = "." });
            table.Add(new ConvertList() { PartLetter = "T", PartMorse = "-" });
            table.Add(new ConvertList() { PartLetter = "I", PartMorse = ".." });
            table.Add(new ConvertList() { PartLetter = "A", PartMorse = ".-" });
            table.Add(new ConvertList() { PartLetter = "N", PartMorse = "-." });
            table.Add(new ConvertList() { PartLetter = "M", PartMorse = "--" });
            table.Add(new ConvertList() { PartLetter = "S", PartMorse = "..." });
            table.Add(new ConvertList() { PartLetter = "D", PartMorse = "-.." });
            table.Add(new ConvertList() { PartLetter = "G", PartMorse = "--." });
            table.Add(new ConvertList() { PartLetter = "O", PartMorse = "---" });
            table.Add(new ConvertList() { PartLetter = "W", PartMorse = ".--" });
            table.Add(new ConvertList() { PartLetter = "U", PartMorse = "..-" });
            table.Add(new ConvertList() { PartLetter = "K", PartMorse = "-.-" });
            table.Add(new ConvertList() { PartLetter = "R", PartMorse = ".-." });
            table.Add(new ConvertList() { PartLetter = "H", PartMorse = "...." });
            table.Add(new ConvertList() { PartLetter = "B", PartMorse = "-..." });
            table.Add(new ConvertList() { PartLetter = "Z", PartMorse = "--.." });
            table.Add(new ConvertList() { PartLetter = "C", PartMorse = "-.-." });
            table.Add(new ConvertList() { PartLetter = "F", PartMorse = "..-." });
            table.Add(new ConvertList() { PartLetter = "J", PartMorse = ".---" });
            table.Add(new ConvertList() { PartLetter = "L", PartMorse = ".-.." });
            table.Add(new ConvertList() { PartLetter = "P", PartMorse = ".--." });
            table.Add(new ConvertList() { PartLetter = "Q", PartMorse = "--.-" });
            table.Add(new ConvertList() { PartLetter = "V", PartMorse = "...-" });
            table.Add(new ConvertList() { PartLetter = "X", PartMorse = "-..-" });
            table.Add(new ConvertList() { PartLetter = "Y", PartMorse = "-.--" });
            table.Add(new ConvertList() { PartLetter = "1", PartMorse = ".----" });
            table.Add(new ConvertList() { PartLetter = "2", PartMorse = "..---" });
            table.Add(new ConvertList() { PartLetter = "3", PartMorse = "...--" });
            table.Add(new ConvertList() { PartLetter = "4", PartMorse = "....-" });
            table.Add(new ConvertList() { PartLetter = "5", PartMorse = "....." });
            table.Add(new ConvertList() { PartLetter = "6", PartMorse = "-...." });
            table.Add(new ConvertList() { PartLetter = "7", PartMorse = "--..." });
            table.Add(new ConvertList() { PartLetter = "8", PartMorse = "---.." });
            table.Add(new ConvertList() { PartLetter = "9", PartMorse = "----." });
            table.Add(new ConvertList() { PartLetter = "0", PartMorse = "-----" });
            table.Add(new ConvertList() { PartLetter = ",", PartMorse = "--..--" });
            table.Add(new ConvertList() { PartLetter = ".", PartMorse = ".-.-.-" });
            table.Add(new ConvertList() { PartLetter = "?", PartMorse = "..--.." });
            table.Add(new ConvertList() { PartLetter = " ", PartMorse = "/" }); 
            InitializeComponent();
        }

        private string ToMorse(string[] text)
        {
            string output = "";
            for (int i = 0; i < text.Length; i++)
            {
                char[] word = text[i].ToCharArray();
                foreach (var item in word)
                {
                    ConvertList convertList = table.Find(x => x.PartLetter.Contains(item));
                    output += convertList.PartMorse + " ";
                }
                output += "/ ";

            }
            return output;
        }

        private string ToText(string[] text)
        {
            string output = "";
            foreach (var item in text)
            {
                ConvertList convertList = table.Find(x => x.PartMorse.Contains(item));
                output += convertList.PartLetter.ToLower();

            }
            return output.Remove(output.Length - 1);
        }

        private void Convert_To_Morse(object sender, RoutedEventArgs e)
        {
             MorseText.Text = ToMorse(NormalText.Text.ToUpper().Split(' '));
        }

        private void Convert_To_Text(object sender, RoutedEventArgs e)
        {
            NormalText.Text = ToText(MorseText.Text.ToUpper().Split(' '));
        }
    }
}
