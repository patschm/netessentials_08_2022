using Shapes;
using System.Drawing.Drawing2D;

namespace DrawNotSoPerfect;

public class GraphicsDevice : IDevice
{
    private Graphics _grapics;

    public GraphicsDevice(Graphics grapics)
    {
        _grapics = grapics;
    }
    
    public void DrawCircle(Circle c)
    {
        using (Pen pen = new Pen(c.Color, c.LineWidth))
        {
            if (c.IsSelected)
            {
                DrawOrigin(c.Location.X, c.Location.Y);
                pen.DashStyle = DashStyle.Dash;
            }
            _grapics.DrawArc(pen, c.Location.X, c.Location.Y, c.Radius, c.Radius, 0, 360);
        }
    }

    public void DrawRectangle(Shapes.Rectangle r)
    {
        using (Pen pen = new Pen(r.Color, r.LineWidth))
        {
            if (r.IsSelected)
            {
                DrawOrigin(r.Location.X, r.Location.Y);
                pen.DashStyle = DashStyle.Dash;
            }
            _grapics.DrawRectangle(pen, r.Location.X, r.Location.Y, r.Height, r.Width);
        }
    }

    public void DrawTriangle(Triangle t)
    {
        Point[] points = new Point[3];
        points[0] = new Point(t.Location.X, t.Location.Y);
        points[1] = new Point(t.Location.X + t.Base, t.Location.Y);
        double hoekRads = t.Angle * Math.PI / 180;
        int delta = (int)(t.Heigth / Math.Tan(hoekRads));
        points[2] = new Point(t.Location.X + delta, t.Location.Y - t.Heigth);
        using (Pen pen = new Pen(t.Color, t.LineWidth))
        {
            if (t.IsSelected)
            {
                DrawOrigin(t.Location.X, t.Location.Y);
                pen.DashStyle = DashStyle.Dash;
            }
            _grapics.DrawPolygon(pen, points);
        }
    }
    private void DrawOrigin(int x, int y)
    {
        _grapics.FillRectangle(Brushes.Black, x - 5, y - 5, 10, 10);
    }
}
