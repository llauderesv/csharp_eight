using System;
using System.Threading.Tasks;
using static System.Console;
using static csharp_eight.src.Helpers.AsyncHelpers;

namespace csharp_eight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Hello World!");

            Rectangle rectangle = new Rectangle(150, 80);
            (int width, int height) = rectangle;

            WriteLine($"Width: {width}");
            WriteLine($"Height: {height}");

            static async Task<string> GetName()
            {
                var rnd = new Random().Next(0, 40);
                if (rnd > 25)
                    throw new Exception($"Random value: {rnd} exceeded max allowed value.");

                await Task.Delay(TimeSpan.FromSeconds(5));

                return await Task.FromResult<string>("Vincent Llauderes");
            }

            var name = await Retry<string>(GetName, retryCount: 5);

            WriteLine(name);
        }
    }

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
