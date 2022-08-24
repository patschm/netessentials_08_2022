using Shapes;

namespace DrawNotSoPerfect;

public partial class RectangleDlg : ShapeDlg
{
    protected override Shape Generate()
    {
        Shapes.Rectangle c = Generate<Shapes.Rectangle>();
        c.Height = (int)hWidth.Value;
        c.Width = (int)hHeight.Value;
        return c;
    }
    public RectangleDlg()
    {
        InitializeComponent();
    }
}
