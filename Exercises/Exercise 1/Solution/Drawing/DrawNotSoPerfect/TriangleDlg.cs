using Shapes;
namespace DrawNotSoPerfect;

public partial class TriangleDlg : ShapeDlg
{ 
    protected override Shape Generate()
    {
        Triangle c = Generate<Triangle>();
        c.Base = (int)hBase.Value;
        c.Heigth = (int)hHeight.Value;
        c.Angle = (int)hAngle.Value;
        return c;
    }
    public TriangleDlg()
    {
        InitializeComponent();
    }


}
