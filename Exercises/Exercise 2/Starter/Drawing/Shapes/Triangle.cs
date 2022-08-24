namespace Shapes;

public class Triangle : Shape
{
    public int Base { get; set; }
    public int Heigth { get; set; }
    public int Angle { get; set; }

    public override void Draw(IDevice device)
    {
        device.DrawTriangle(this);
    }
}
