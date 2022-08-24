namespace Shapes;

public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw(IDevice device)
    {
        device.DrawRectangle(this);
    }
}
