using System;
using System.Collections;
using System.Text;

namespace Lab2
{
    public interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }

    public enum Frequency { Weekly, Monthly, Quarterly, Yearly }

    public class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        public Person() { }
        public Person(string fn, string ln, DateTime bd)
        {
            firstName = fn;
            lastName = ln;
            birthDate = bd;
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

        public virtual object DeepCopy()
        {
            return new Person(firstName, lastName, birthDate);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person p)
            {
                return firstName == p.firstName && lastName == p.lastName && birthDate == p.birthDate;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Person a, Person b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            else 
            { 
                return a.Equals(b); 
            }
        }

        public static bool operator !=(Person a, Person b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(firstName, lastName, birthDate);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} (дата рождения: {2:d})", firstName, lastName, birthDate);
        }
    }

    public class Edition
    {
        protected string title;
        protected DateTime releaseDate;
        protected int circulation;
        public Edition() : this("Неизвестно", DateTime.Now, 0) { }
        public Edition(string title, DateTime date, int circulation)
        {
            this.title = title;
            this.releaseDate = date;
            Circulation = circulation;
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

        public virtual int Circulation
        {
            get 
            {
                return circulation; 
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Circulation", "Тираж должен быть неотрицательным числом");
                }
                circulation = value;
            }
        }

        public virtual object DeepCopy()
        {
            return new Edition(title, releaseDate, circulation);
        }

        public override bool Equals(object obj)
        {
            if (obj is Edition e)
            {
                return title == e.title && releaseDate == e.releaseDate && circulation == e.circulation;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Edition a, Edition b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            else
            {
                return a.Equals(b);
            }
        }

        public static bool operator !=(Edition a, Edition b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(title, releaseDate, circulation);
        }

        public override string ToString()
        {
            return String.Format("Название: {0}; Дата выхода: {1:d}; Тираж: {2}", title, releaseDate, circulation);
        }
    }

    public class Article : IRateAndCopy
    {
        private string title;
        private Person author;
        private double rating;

        public Article() { }

        public Article(string title, Person author, double rating)
        {
            this.title = title;
            this.author = author;
            this.rating = rating;
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

        public Person Author
        {
            get 
            { return author; 
            }
            set 
            { author = value; 
            }
        }

        public double Rating
        {
            get 
            { return rating; 
            }
            set 
            { rating = value; 
            }
        }

        public virtual object DeepCopy()
        {
            Person authorCopy = (Person)author?.DeepCopy();
            return new Article(title, authorCopy, rating);
        }

        object IRateAndCopy.DeepCopy()
        {
            return DeepCopy();
        }

        double IRateAndCopy.Rating
        {
            get { return rating; }
        }

        public override string ToString()
        {
            string authorStr = (author != null) ? author.ToString() : "Неизвестный автор";
            return String.Format("Статья: {0}; Автор: {1}; Рейтинг: {2}", title, authorStr, rating);
        }
    }

    public class Magazine : Edition, IRateAndCopy
    {
        private Frequency frequency;
        private ArrayList editors;
        private ArrayList articles;

        public Magazine() : base()
        {
            frequency = Frequency.Monthly;
            editors = new ArrayList();
            articles = new ArrayList();
        }

        public Magazine(string title, Frequency freq, DateTime date, int circulation) : base(title, date, circulation)
        {
            frequency = freq;
            editors = new ArrayList();
            articles = new ArrayList();
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

        public ArrayList Editors
        {
            get 
            { 
                return editors; 
            }
        }

        public ArrayList Articles
        {
            get 
            { 
                return articles; 
            }
        }

        public void AddEditors(params Person[] persons)
        {
            if (persons == null)
            {
                return;
            }
            foreach (Person p in persons)
            {
                editors.Add(p);
            }
        }

        public void AddArticles(params Article[] arts)
        {
            if (arts == null) return;
            foreach (Article a in arts)
            {
                articles.Add(a);
            }
        }

        public double AverageRating
        {
            get
            {
                if (articles == null || articles.Count == 0) return 0.0;
                double sum = 0.0;
                int count = 0;
                foreach (object obj in articles)
                {
                    Article a = obj as Article;
                    if (a != null)
                    {
                        sum += a.Rating;
                        count++;
                    }
                }
                if (count == 0) return 0.0;
                return sum / count;
            }
        }

        public override object DeepCopy()
        {
            Magazine copy = new Magazine(Title, frequency, ReleaseDate, Circulation);

            if (editors != null)
            {
                foreach (object obj in editors)
                {
                    Person p = obj as Person;
                    if (p != null)
                        copy.editors.Add(p.DeepCopy());
                }
            }

            // копируем статьи
            if (articles != null)
            {
                foreach (object obj in articles)
                {
                    Article a = obj as Article;
                    if (a != null)
                    {
                        copy.articles.Add(a.DeepCopy());
                    }
                }
            }
            return copy;
        }

        object IRateAndCopy.DeepCopy()
        {
            return DeepCopy();
        }

        double IRateAndCopy.Rating
        {
            get 
            { 
                return AverageRating; 
            }
        }

        public Edition EditionSubObject
        {
            get
            {
                return new Edition(Title, ReleaseDate, Circulation);
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                Title = value.Title;
                ReleaseDate = value.ReleaseDate;
                Circulation = value.Circulation;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(String.Format("Периодичность: {0}", frequency));
            sb.AppendLine("Редакторы:");
            if (editors != null)
            {
                foreach (object obj in editors)
                {
                    Person p = obj as Person;
                    if (p != null)
                        sb.AppendLine(" - " + p.ToString());
                }
            }
            sb.AppendLine("Статьи:");
            if (articles != null)
            {
                foreach (object obj in articles)
                {
                    Article a = obj as Article;
                    if (a != null)
                        sb.AppendLine(" - " + a.ToString());
                }
            }
            return sb.ToString();
        }

        public virtual string ToShortString()
        {
            return String.Format("{0}; Периодичность: {1}; Средний рейтинг статей: {2:F2}", base.ToString(), frequency, AverageRating);
        }
        public ArrayList GetArticlesWithRatingGreaterThan(double minRating)
        {
            ArrayList result = new ArrayList();
            if (articles == null)
            {
                return result;
            }
            foreach (object obj in articles)
            {
                Article a = obj as Article;
                if (a != null && a.Rating > minRating)
                {
                    result.Add(a);
                }
            }
            return result;
        }
        public ArrayList GetArticlesWithTitleContains(string substr)
        {
            ArrayList result = new ArrayList();
            if (string.IsNullOrEmpty(substr) || articles == null)
            {
                return result;
            }
            foreach (object obj in articles)
            {
                Article a = obj as Article;
                if (a != null && !string.IsNullOrEmpty(a.Title) &&
                    a.Title.IndexOf(substr, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(a);
                }
            }
            return result;
        }
    }
}
