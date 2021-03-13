namespace csharp_eight.src.sample01.Deconstruction
{
    // Deconstruct example 
    public class Rectangle
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Deconstruct(out int width, out int height)
        {
            width = Width;
            height = Height;
        }

        public override string ToString()
        {
            return $"Rectangle Width: {Width} and Height: {Height}";
        }
    }
}