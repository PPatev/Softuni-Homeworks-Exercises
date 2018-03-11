namespace P11_RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double x;
        private double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
        }

        public double X
        {
            get
            {
                return this.x;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
        }

        public bool IntersectionCheck(Rectangle other)
        {
            bool horisontalIntersection = (this.X <= other.X && other.X <= this.X + this.Width)
                                          || (other.X <= this.X && this.X <= other.X + other.Width);
            bool verticalIntersection = (this.Y <= other.Y && other.Y <= this.Y + this.Height)
                                          || (other.Y <= this.Y && this.Y <= other.Y + other.Height);

            return horisontalIntersection && verticalIntersection;
        }
    }
}