using Shapes;

namespace DrawNotSoPerfect;

public partial class ShapeDlg : Form
{
    public Shape? Shape 
    {
        get
        {
            return Generate();
        }
    }
    protected T Generate<T>() where T: Shape, new()
    {
        T shape = new T();
        shape.Location = new Position { X = (int)hX.Value, Y = (int)hY.Value };
        shape.Color = colorDialog1.Color;
        shape.LineWidth = (int)hLineWidth.Value;
        return shape;
    }
    protected virtual Shape Generate()
    {
        return Generate<Shape>();
    }
    public ShapeDlg()
    {
        InitializeComponent();
    }

    private void btnColor_Click(object sender, EventArgs e)
    {
        colorDialog1.ShowDialog();
        btnColor.BackColor = colorDialog1.Color;
    }
}
