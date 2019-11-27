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

namespace RNtranslator3
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, int> romanNumerals = new Dictionary<string, int>()
            {
                {"I", 1 }, {"V", 5}, {"X", 10}, {"L", 50}, {"C", 100 }, {"D", 500 }, {"M", 1000 }
            };
        public MainWindow()
        {
            InitializeComponent();
        }


        private int Roman_Numeral_Translate(string numerals)
        {
            int sum = 0;
            List<char> chars = numerals.ToUpper().ToList();

            for (int i = 0; i < chars.Count; i++)
            {
                try
                {
                    
                    if (i + 1 < chars.Count)
                    {
                        if (romanNumerals[chars[i + 1].ToString()] > romanNumerals[chars[i].ToString()])
                        {
                            sum -= romanNumerals[chars[i].ToString()];
                        }
                        else
                        {
                            sum += romanNumerals[chars[i].ToString()];
                        }

                    }
                    else
                    {
                        sum += romanNumerals[chars[i].ToString()];
                    }
                    
                }



                catch (Exception)
                {
                    errorMessage.Text =  string.Format("{0} is not a Roman numeral",chars[i]);
                }
                
            }
            return sum;
        }



        private void RomanNumeralInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorMessage.Text = "";
            numberInput.Text = Roman_Numeral_Translate(romanNumeralInput.Text).ToString();
        }
    }
}
