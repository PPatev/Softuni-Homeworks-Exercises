namespace P13_DrawingTool
{
    using System;

    public class Application
    {
        public static void Main()
        {
            string figureInfo = Console.ReadLine();
            int side = int.Parse(Console.ReadLine());
            Figure figure = null;

            if (!figureInfo.Equals("Rectangle"))
            {
                figure = new Square(side);
            }
            else
            {
                int sideSecond = int.Parse(Console.ReadLine());
                figure = new Rectangle(side, sideSecond);
            }

            CorDraw cd = new CorDraw(figure);
            cd.PerformDrawing();
        }
    }

    public class CorDraw
    {
        private Figure figure;

        public CorDraw(Figure figure)
        {
            this.figure = figure;
        }

        public void PerformDrawing()
        {
            this.figure.Draw();
        }
    }

    public abstract class Figure
    {
        private int side;

        public Figure(int side)
        {
            this.side = side;
        }

        public int Side
        {
            get
            {
                return this.side;
            }
        }

        public abstract void Draw();
    }

    public class Square : Figure
    {
        public Square(int side)
            : base(side)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("|{0}|", new string('-', this.Side));

            for (int i = 0; i < this.Side - 2; i++)
            {
                Console.WriteLine("|{0}|", new string(' ', this.Side));
            }

            Console.WriteLine("|{0}|", new string('-', this.Side));
        }
    }

    public class Rectangle : Figure
    {
        private int sideSecond;

        public Rectangle(int side, int sideSecond)
            : base(side)
        {
            this.sideSecond = sideSecond;
        }

        public int SideSecond
        {
            get
            {
                return this.sideSecond;
            }
        }

        public override void Draw()
        {
            Console.WriteLine("|{0}|", new string('-', this.Side));

            for (int i = 0; i < this.SideSecond - 2; i++)
            {
                Console.WriteLine("|{0}|", new string(' ', this.Side));
            }

            Console.WriteLine("|{0}|", new string('-', this.Side));
        }
    }
}