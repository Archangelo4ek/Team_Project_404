using System;
using System.Collections.Generic;
using System.Text;

namespace TeamProject
{
    public class Magazine
    {
        private string name;
        private Frequency frequency;
        private DateTime releaseDate;
        private int circulation;
        private Article[] articles;
        public Magazine(string name, Frequency frequency, DateTime releaseDate, int circulation)
        {
            this.name = name;
            this.frequency = frequency;
            this.releaseDate = releaseDate;
            this.circulation = circulation;
            this.articles = new Article[0];
        }
        public Magazine()
        {
            name = "Без названия";
            frequency = Frequency.Monthly;
            releaseDate = DateTime.MinValue;
            circulation = 0;
            articles = new Article[0];
        }
        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            { 
                name = value; 
            }
        }

        public Frequency Frequency
        {
            get 
            { 
                return frequency; 
            }
            set 
            { 
                frequency = value; 
            }
        }

        public DateTime ReleaseDate
        {
            get 
            { 
                return releaseDate; 
            }
            set 
            { 
                releaseDate = value; 
            }
        }
        public int Circulation
        {
            get 
            { 
                return circulation; 
            }
            set 
            { 
                circulation = value; 
            }
        }
        public Article[] Articles
        {
            get 
            { 
                return articles; 
            }
            set 
            { 
                articles = value; 
            }
        }
        public double AverageRating
        {
            get
            {
                if (articles.Length == 0) return 0.0;
                double sum = 0;
                foreach (var article in articles)
                {
                    sum += article.Rating;
                }
                return sum / articles.Length;
            }
        }
        public bool this[Frequency freq]
        {
            get { return frequency == freq; }
        }
        public void AddArticles(params Article[] newArticles)
        {
            int oldLength = articles.Length;
            Array.Resize(ref articles, oldLength + newArticles.Length);
            for (int i = 0; i < newArticles.Length; i++)
            {
                articles[oldLength + i] = newArticles[i];
            }
        }
        public override string ToString()
        {
            string result = "название " + name +" периодичность " + frequency + " дата выхода " + releaseDate + " тираж " + circulation +  " статьи ";
            foreach (var article in articles)
            {
                result += article.ToString() + "\n";
            }
            return result;
        }
        public virtual string ToShortString()
        {
            return "название " + name + " периодичность " + frequency + " дата выхода " + releaseDate + " тираж " + circulation + " средний рейтинг " + AverageRating.ToString("F2");
        }
    }
}
