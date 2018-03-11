namespace P02_BookShop
{
    using System;
    using System.Text;

    public class Application
    {
        public static void Main()
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                decimal price = decimal.Parse(Console.ReadLine());

                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    internal class Book
    {
        private string author;
        private string title;
        private decimal price;

        internal Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        protected string Author
        {
            get
            {
                return this.author;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    string[] names = value.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (names.Length > 1 && char.IsDigit(names[1][0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.author = value;
            }
        }

        protected string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        protected virtual decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: ").Append(this.GetType().Name)
                    .Append(Environment.NewLine)
                    .Append("Title: ").Append(this.Title)
                    .Append(Environment.NewLine)
                    .Append("Author: ").Append(this.Author)
                    .Append(Environment.NewLine)
                    .Append("Price: ").Append(string.Format("{0:F1}", this.Price))
                    .Append(Environment.NewLine);

            return sb.ToString();
        }

    }

    internal class GoldenEditionBook : Book
    {
        internal GoldenEditionBook(string author, string title, decimal price)
            : base(author, title, price)
        {
        }

        protected override decimal Price
        {
            get
            {
                return base.Price;
            }

            set
            {
                base.Price = value + ((value / 100) * 30);
            }
        }
    }
}