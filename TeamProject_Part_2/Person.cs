using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    using System;

    namespace TeamProject
    {
        public class Person : IEquatable<Person>, ICloneable
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
                birthDate = new DateTime(2000, 1, 1);
            }
            public string FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Имя не может быть пустым");
                    }
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
                    if (value == null)
                    {
                        throw new ArgumentNullException("Фамилия не может быть пустой");
                    }
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
            public bool Equals(Person other)
            {
                if (ReferenceEquals(other, null))
                {
                    return false;
                }
                if (ReferenceEquals(this, other))
                {
                    return true;
                }
                return string.Equals(this.firstName, other.firstName, StringComparison.Ordinal) && string.Equals(this.lastName, other.lastName, StringComparison.Ordinal) && this.birthDate.Equals(other.birthDate);
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(obj, null))
                {
                    return false;
                }
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (obj.GetType() != this.GetType())
                {
                    return false;
                }
                return Equals(obj as Person);
            }
            public static bool operator ==(Person left, Person right)
            {
                if (ReferenceEquals(left, right))
                {
                    return true;
                }
                if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                {
                    return false;
                }
                return left.Equals(right);
            }
            public static bool operator !=(Person left, Person right)
            {
                return !(left == right);
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + (firstName != null ? StringComparer.Ordinal.GetHashCode(firstName) : 0);
                    hash = hash * 23 + (lastName != null ? StringComparer.Ordinal.GetHashCode(lastName) : 0);
                    hash = hash * 23 + birthDate.GetHashCode();
                    return hash;
                }
            }
            public object DeepCopy()
            {
                return new Person(string.Copy(firstName ?? string.Empty), string.Copy(lastName ?? string.Empty), birthDate);
            }
            public object Clone()
            {
                return DeepCopy();
            }
        }
    }

}
