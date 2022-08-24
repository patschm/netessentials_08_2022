namespace Shapes;

public class Circle : Shape
{
    public int Radius { get; set; }

    public override void Draw(IDevice device)
    {
        device.DrawCircle(this);
    }
}
