using System;
using System.Collections.Generic;
using System.Text;

namespace TeamProject
{
    public enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }
    public class Article
    {
        private Person author;
        private string title;
        private double rating;
        public Person Author
        {
            get 
            { 
                return author; 
            }
            set 
            { 
                author = value; 
            }
        }
        public string Title
        {
            get 
            { 
                return title; 
            }
            set 
            { 
                title = value; 
            }
        }
        public double Rating
        {
            get 
            { 
                return rating; 
            }
            set
            {
                rating = value; 
            }
        }
        public Article(Person author, string title, double rating)
        {
            this.author = author;
            this.title = title;
            this.rating = rating;
        }
        public Article()
        {
            author = new Person();
            title = "Без названия";
            rating = 0.0;
        }
        public override string ToString()
        {
            return "Автор " + author.ToShortString() + " название " + title + " рейтинг " + rating;
        }
    }
}
