using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Assignment1
{
    public class FootballPlayer
    {
        
        public int PlayerID { get; set; }
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "a 1 year old should not play football at this level")]
        public int Age { get; set; }
        [Range(1, 99, ErrorMessage = "Please choose a number between 1 and 99, no space for 3 numbers")]
        public int ShirtNumber { get; set; }
        public FootballPlayer()
        { }
        public FootballPlayer(int playerID, string name, int age, int shirtNumber)
        {
            PlayerID = playerID;
            Name = name;
            Age = age;
            ShirtNumber = shirtNumber;
        }

        public void ValidateName()
        {
            if (Name == null)
                throw new ArgumentNullException("Name is null, should not be null");
            if (Name.Length < 2)
                throw new ArgumentException("shortest name allowed is 2 letters long");

        }
        public void ValidateAge()
        {
            if (Age <= 1)
                throw new ArgumentOutOfRangeException("Age must be more than" + Age);
        }

        public void ValidateShirtNumber()
        {
            //if (ShirtNumber == null)
            //    throw new ArgumentNullException("ShirtNumber is null");
            if (ShirtNumber < 1 || ShirtNumber > 99)
                throw new ArgumentOutOfRangeException("ShirtNumber numbers allowed is between 1 & 99");
        }

        public void Validate()
        {
            ValidateName();
            ValidateAge();
            ValidateShirtNumber();
        }

        

    }





}