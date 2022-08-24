using Shapes;

namespace DrawNotSoPerfect;

public partial class DrawMain : Form
{
    public class DragInfo
    {
        public Shape? SelectedShape { get; internal set; }
    }

    private List<Shape> _shapes = new List<Shape>();
    private DragInfo? _selected = null;
    // TODO 4: Get an instance from IStorage from the Dependency Injector
    // and test the application.
    private IStorage _storage;

    public DrawMain(IStorage storage)
    {
        _storage = storage;
        InitializeComponent();
    }

    private void circleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dlg = new CircleDlg();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
           _shapes.Add(dlg.Shape!);
            Invalidate();
        }
    }

    private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dlg = new RectangleDlg();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            _shapes.Add(dlg.Shape!);
            Invalidate();
        }
    }

    private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dlg = new TriangleDlg();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            _shapes.Add(dlg.Shape!);
            Invalidate();
        }
    }

    private void DrawMain_Paint(object sender, PaintEventArgs e)
    {
        var g = new GraphicsDevice(e.Graphics);
        foreach(Shape s in _shapes)
        {
            s.Draw(g);
        }
    }

    private void DrawMain_MouseDown(object sender, MouseEventArgs e)
    {
        foreach(Shape s in _shapes)
        {
            int dx = s.Location.X - e.X;
            int dy = s.Location.Y - e.Y;
            if (Math.Sqrt(dx*dx + dy*dy) < 50)
            {
                _selected = new DragInfo { SelectedShape = s};
            }
        }
        Invalidate();
        if(_selected != null)
            _selected.SelectedShape!.IsSelected = true;
    }

    private void DrawMain_DragDrop(object sender, DragEventArgs e)
    {
        DragInfo? s = e.Data?.GetData(typeof(DragInfo)) as DragInfo;
        if (s != null && s.SelectedShape != null)
        {
            var pos = PointToClient(new Point(e.X, e.Y));
            s.SelectedShape.Location = new Position { X = pos.X, Y = pos.Y };
            s.SelectedShape.IsSelected = false;
            Invalidate();
            _selected = null;
        }
    }

    private void DrawMain_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
        Invalidate();
    }

    private void DrawMain_MouseMove(object sender, MouseEventArgs e)
    {
        if (_selected != null) 
            DoDragDrop(_selected, DragDropEffects.Move);
    }

    private void DrawMain_MouseUp(object sender, MouseEventArgs e)
    {
        if (_selected != null)
        {
            _selected.SelectedShape!.IsSelected = false;
        }
        _selected = null;
        Invalidate();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _shapes = _storage.Open(openFileDialog.FileName)!;
                Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _storage.SaveAs(saveFileDialog.FileName, _shapes);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            _storage.Save(_shapes);
        }
        catch (FileNotFoundException)
        {
            saveAsToolStripMenuItem_Click(sender, e);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void clearToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _shapes = new List<Shape>();
        _selected = null;
        Invalidate();
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}