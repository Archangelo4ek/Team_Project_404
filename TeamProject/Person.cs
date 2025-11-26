using System;
using System.Collections.Generic;
using System.Text;

namespace TeamProject
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        public Person(string firstName, string lastName, DateTime birthDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }
        public Person()
        {
            firstName = "Нет имени";
            lastName = "Нет фамилии";
            birthDate = new DateTime(2025, 1, 1);
        }
        public string FirstName
        {
            get 
            { 
                return firstName; 
            }
            set 
            { 
                firstName = value; 
            }
        }
        public string LastName
        {
            get 
            { 
                return lastName; 
            }
            set 
            { 
                lastName = value; 
            }
        }
        public DateTime BirthDate
        {
            get 
            { 
                return birthDate; 
            }
            set 
            { 
                birthDate = value; 
            }
        }
        public int BirthYear
        {
            get 
            { 
                return birthDate.Year; 
            }
            set 
            { 
                birthDate = new DateTime(value, birthDate.Month, birthDate.Day); 
            }
        }
        public override string ToString()
        {
            return "Имя " + firstName + " Фамилия " + lastName + " Дата рождения " + birthDate.ToShortDateString();
        }
        public virtual string ToShortString()
        {
            return "Имя " + firstName + " Фамилия " + lastName;
        }
    }
}