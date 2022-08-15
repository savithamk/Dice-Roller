using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DiceRoller.Models;

namespace DiceRoller
{
    public partial class MainPage : ContentPage
    {
        private int numOfSides = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        
        void Display_One_Handler(System.Object sender, System.EventArgs e)
        {

            if (numOfSides > 0) {
                Die die = new Die(numOfSides);
                Result2.IsVisible = false;
                Result1.IsVisible = true;
                Result1.Text = die.GetCurrentSide().ToString();
            } 
            
        }

        void Display_Two_Handler(System.Object sender, System.EventArgs e)
        {
            if (numOfSides > 0) {
                Die die1 = new Die(numOfSides);
                Die die2 = new Die(numOfSides);
                Result1.IsVisible = false;
                Result2.IsVisible = true;
                Result2.Text = die1.GetCurrentSide().ToString() + "," + die2.GetCurrentSide().ToString();
            }
            
        }

        void Die_Selected_Handler(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            RadioButton changed = (RadioButton)sender;
            if (changed.IsChecked) {
                numOfSides = Int32.Parse(changed.Value.ToString());
            }
            

        }
    }
}
