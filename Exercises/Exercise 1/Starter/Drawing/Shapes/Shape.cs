using System.Drawing;

namespace Shapes
{
    public class Shape
    {
        public Position Location { get; set; }
        public Color Color { get; set; } = Color.Black;
        public int LineWidth { get; set; } = 5;
        public bool IsSelected { get; set; } = false;

        public virtual void Draw(IDevice device)
        {

        }
    }
}