using Shapes;

namespace DrawNotSoPerfect;

public partial class CircleDlg : ShapeDlg
{
    protected override Shape Generate()
    {
        Circle c = Generate<Circle>();
        c.Radius = (int)hRadius.Value;
        return c;
    }
    public CircleDlg()
    {
        InitializeComponent();
    }
}
