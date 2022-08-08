using System;
namespace DiceRoller.Models
{
    public class Die
    {
        private string Name { get; set; }

        private int NumSides { get; set; }

        private int CurrentSide { get; set; }

        public Die() 
        {
            Name = "d6";
            NumSides = 6;
            Roll();
        }

        public Die(int numSides) 
        {
            Name = "d" + numSides;
            NumSides = numSides;
            Roll();
        }

        public void SetSideUp(int newSideUp) 
        {
            if (newSideUp >= 1 && newSideUp <= NumSides)
                this.CurrentSide = newSideUp;
        }

        public void Roll() 
        {
            Random r = new Random();
            CurrentSide = r.Next(NumSides) + 1;
        }

        public String GetName() { return Name; } 

        public int GetNumSides() { return NumSides; } 

        public int GetCurrentSide() { return CurrentSide; } 
    }
}
