using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    [Serializable]
    public class Person
    {
        private static readonly string[] westernZodiacs = {"The Sea-goat", "The Water Bearer", "The Fish", "The Ram", "The Bull", "The Twins",
            "The Crab", "The Lion", "The Virgin", "The Scales", "The Scorpion", "The Archer"};
        private static readonly string[] chineseZodiacs = {"Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox",
            "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat"};


        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthday;

        public string FirstName 
        { 
            get => _firstName; 
            set => _firstName = value; 
        }
       
        public string LastName 
        {
            get => _lastName; set => _lastName = value; 
        }
        
        public string Email 
        {
            get => _email; set => _email = value; 
        }
        
        public DateTime Birthday 
        {
            get => _birthday; set => _birthday = value; 
        }

        public string ChineseSign
        {
            get => chineseZodiacs[CalculateChineseZodiac()];
        }

        public string SunSign
        {
            get => westernZodiacs[CalculateWesternZodiac()];
        }


        public bool IsAdult
        {
            get
            {
                int age = GetAge(_birthday);
                return age >= 18;
            }
        }

        public bool IsBirthday
        {
            get => DateTime.Now.Month == _birthday.Month && DateTime.Now.Day == _birthday.Day;
        }

        public static bool IsDateCorrect(DateTime date)
        {
            int age = GetAge(date);
            return age >= 0 && age <= 135;
        }

        public Person(string firstName, string lastName, string email, DateTime birthday)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
            this._birthday = birthday;
        }

        public Person(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this._lastName = lastName;
            this._email = email;
        }

        public Person(string firstName, string lastName, DateTime birthday)
        {
            this.FirstName = firstName;
            this._lastName = lastName;
            this._birthday = birthday;
        }

        public Person()
        {

        }

        private static int GetAge(DateTime date)
        {
            int result = DateTime.Now.Year - date.Year;
            if (DateTime.Now.Month < date.Month)
            {
                result--;
            }
            else if (DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day)
            {
                result--;
            }
            return result;
        }

        private int CalculateWesternZodiac()
        {
            switch (_birthday.Month)
            {
                case 1:
                    return _birthday.Day <= 20 ? 0 : 1;
                case 2:
                    return _birthday.Day <= 19 ? 1 : 2;
                case 3:
                    return _birthday.Day <= 20 ? 2 : 3;
                case 4:
                    return _birthday.Day <= 20 ? 3 : 4;
                case 5:
                    return _birthday.Day <= 20 ? 4 : 5;
                case 6:
                    return _birthday.Day <= 21 ? 5 : 6;
                case 7:
                    return _birthday.Day <= 22 ? 6 : 7;
                case 8:
                    return _birthday.Day <= 22 ? 7 : 8;
                case 9:
                    return _birthday.Day <= 22 ? 8 : 9;
                case 10:
                    return _birthday.Day <= 22 ? 9 : 10;
                case 11:
                    return _birthday.Day <= 22 ? 10 : 11;
                case 12:
                    return _birthday.Day <= 21 ? 11 : 0;
                default:
                    return 1;
            }
        }

        private int CalculateChineseZodiac()
        {
            return _birthday.Year % 12;
        }

    }

}

