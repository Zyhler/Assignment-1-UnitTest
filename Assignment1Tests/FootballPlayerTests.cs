using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Tests
{
    [TestClass()]
    public class FootballPlayerTests
    {
        private FootballPlayer PlayerStandard = new FootballPlayer { PlayerID = 1, Name = "jon dahl", Age = 25, ShirtNumber = 4 };
        private FootballPlayer PlayerNegativeAge = new FootballPlayer { PlayerID = 2, Name = "jon dahl", Age = -1, ShirtNumber = 6 };
        private FootballPlayer PlayerAgeTooLow = new FootballPlayer { PlayerID = 2, Name = "jon dahl", Age = 1, ShirtNumber = 6 };
        private FootballPlayer playerNegativeShirtnumber = new FootballPlayer{ PlayerID = 4, Name = "jon dahl", Age = 24, ShirtNumber = -1 };
        private FootballPlayer playerNameShort = new FootballPlayer{ PlayerID = 4, Name = "i", Age = 24, ShirtNumber = -1 };
        private FootballPlayer playerNameNull = new FootballPlayer{ PlayerID = 4, Name = null, Age = 24, ShirtNumber = -1 };
        
        [TestMethod()]
        public void ValidateNameTest()
        {
           //Assert.ThrowsException<ArgumentNullException>(() => playerBlankName.ValidateName()) ;
           Assert.ThrowsException<ArgumentNullException>(() => playerNameNull.ValidateName()) ;
           Assert.ThrowsException<ArgumentException>(() => playerNameShort.ValidateName()) ;
        }

        [TestMethod()]
        public void ValidateAgeTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PlayerNegativeAge.ValidateAge()) ;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PlayerAgeTooLow.ValidateAge()) ;
        }

        [TestMethod()] // All the shirt numbers that should work
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(50)]
        [DataRow(98)]
        [DataRow(99)]
            
        public void ValidateShirtNumberTest(int shirtnumber)
        {
            PlayerStandard.ShirtNumber = shirtnumber;
            PlayerStandard.ValidateShirtNumber();
        }
        
        [TestMethod()] // All the shirt numbers that should give an exception
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(100)]
        
        public void ValidateShirtNumbersTest(int shirtnumber)
        {
            PlayerStandard.ShirtNumber = shirtnumber;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PlayerStandard.ValidateShirtNumber());
            //Assert.ThrowsException<ArgumentOutOfRangeException>(() => PlayerAgeTooLow.ValidateAge());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            PlayerStandard.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => playerNameNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PlayerNegativeAge.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PlayerAgeTooLow.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PlayerNegativeAge.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerNegativeShirtnumber.Validate());
        }
    }
}