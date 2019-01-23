using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GKProjekt2
{
    public partial class Polygons : Form
    {
        static Timer _timer = new Timer();
        private List<Point> _staticPolygon = new List<Point> { new Point(20, 20), new Point(20, 50), new Point(50, 50), new Point(50, 20) };
        private List<Point> _movePolygon = new List<Point> { new Point(150, 100), new Point(450, 100), new Point(450, 350), new Point(150, 350) };
        private Point _staticCenterPoint;
        private Point _moveCenterPoint;
        private int _selectedV = -1;
        private bool _timeToSwapStaticP = false;
        private bool _timeToSwapMoveableP = false;
        private bool _timeToSwapV = false;
        private List<Point> _pointsToFillStatic = new List<Point>();
        private List<Point> _pointsToFillMoveable = new List<Point>();
        private FillPolygons _fillTool;
        private List<KeyValuePair<Point, int>> _linesToFill = new List<KeyValuePair<Point, int>>();
        private bool _drawStatic = false;
        private bool _drawMoveable = false;
        private List<Point> _crossPoints = new List<Point>();
        List<Point> _clipWithCrossing = new List<Point>();
        List<Point> _subjectWithCrossing = new List<Point>();
        private double _R, _Ry, _Rz;
        public Polygons()
        {
            InitializeComponent();
            _fillTool = new FillPolygons(_drawPanel.Size.Width,_drawPanel.Size.Height);
            _IOtextC.Image = _fillTool._objectMap;
            _Ncolor.Image = _fillTool._normalMap;
            updateCenter(false);
            updateCenter(true);
            _drawPanel.Invalidate();
            _timer.Tick += new EventHandler(sphereMotion);
            _timer.Interval = 1000;
        }
        private void sphereMotion(object sender, EventArgs e)
        {
            if (_Ry >= _drawPanel.Height / 2 + _R)
                _Ry = _drawPanel.Height / 2 - _R;
            _Ry += 0.05 * _R;
            _Rz = Math.Sqrt(_R*_R-(_Ry-_drawPanel.Height/2)* (_Ry - _drawPanel.Height / 2));
            _drawPanel.Invalidate();
        }

        //on click
        private void drawing(object sender, MouseEventArgs e)
        {
            if (_drawStatic)
            {
                Point newPoint = e.Location;
                if (_staticPolygon.Count > 2 && Math.Abs(_staticPolygon[0].X - newPoint.X) <= 3 && Math.Abs(_staticPolygon[0].Y - newPoint.Y) <= 3)
                    _drawStatic = false;
                else
                    _staticPolygon.Add(newPoint);
                updateCenter(true);
            }
            else if (_drawMoveable)
            {
                Point newPoint = e.Location;
                if (_movePolygon.Count > 2 && Math.Abs(_movePolygon[0].X - newPoint.X) <= 3 && Math.Abs(_movePolygon[0].Y - newPoint.Y) <= 3)
                    _drawMoveable = false;
                else
                    _movePolygon.Add(newPoint);
                updateCenter(false);
            }
            else
                modifyPolygon(e);
            _drawPanel.Invalidate();

        }
        //paint
        private void refreshPanel(object sender, PaintEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(_fillTool._currentBitmap))
            {
                    g.Clear(Color.White);
                if (_possibleMulti.Count > 0)
                {
                    _movePolygon.Clear();
                    _staticPolygon.Clear();
                    fillMulti();
                }
                else
                {
                    fillPolygons();
                    if (_staticPolygon.Count > 0)
                    {
                        g.FillEllipse(Brushes.Red, new Rectangle(_staticPolygon.First().X - 3, _staticPolygon.First().Y - 3, 7, 7));
                        for (int i = 0; i < _staticPolygon.Count - 1; i++)
                        {
                            g.DrawLine(new Pen(Brushes.Black), _staticPolygon[i], _staticPolygon[i + 1]);
                            g.FillEllipse(Brushes.Red, new Rectangle(_staticPolygon[i + 1].X - 3, _staticPolygon[i + 1].Y - 3, 7, 7));
                        }
                        if (!_drawStatic)
                            g.DrawLine(new Pen(Brushes.Black), _staticPolygon.Last(), _staticPolygon.First());
                    }
                    if (_movePolygon.Count > 0)
                    {
                        g.FillEllipse(Brushes.Black, new Rectangle(_movePolygon.First().X - 3, _movePolygon.First().Y - 3, 7, 7));
                        //g.FillEllipse(new SolidBrush(Color.FromArgb(255 - ((Bitmap)_drawPanel.Image).GetPixel(_movePolygon[0].X, _movePolygon[0].Y).R, 255 - ((Bitmap)_drawPanel.Image).GetPixel(_movePolygon[0].X, _movePolygon[0].Y).G, 255 - ((Bitmap)_drawPanel.Image).GetPixel(_movePolygon[0].X, _movePolygon[0].Y).B)), new Rectangle(_movePolygon.First().X - 3, _movePolygon.First().Y - 3, 7, 7));
                        for (int i = 0; i < _movePolygon.Count - 1; i++)
                        {
                            g.DrawLine(new Pen(Brushes.Black), _movePolygon[i], _movePolygon[i + 1]);
                            g.FillEllipse(Brushes.Blue, new Rectangle(_movePolygon[i + 1].X - 3, _movePolygon[i + 1].Y - 3, 7, 7));
                        }
                        if (!_drawMoveable)
                            g.DrawLine(new Pen(Brushes.Black), _movePolygon.Last(), _movePolygon.First());
                    }
                    if (_staticPolygon.Count > 0)
                        g.DrawEllipse(new Pen(Color.Gray), new Rectangle(_staticCenterPoint.X - 3, _staticCenterPoint.Y - 3, 7, 7));
                    if (_movePolygon.Count > 0)
                        g.DrawEllipse(new Pen(Color.Gray), new Rectangle(_moveCenterPoint.X - 3, _moveCenterPoint.Y - 3, 7, 7));
                }
            }
            e.Graphics.DrawImage(_fillTool._currentBitmap, 0, 0);
        }
        private void fillStatic()
        {
            if(_staticPolygon.Count>0 && !_drawStatic)
                _fillTool.fillPolygon(_staticPolygon, _VLSconstR.Checked, _IOconstR.Checked, _NconstR.Checked, _NtextR.Checked, _Pnone.Checked, _Ry, _Rz);
        }

        private void fillMoveable()
        {
            if(_movePolygon.Count>0 && !_drawMoveable)
                _fillTool.fillPolygon(_movePolygon, _VLSconstR.Checked, _IOconstR.Checked, _NconstR.Checked, _NtextR.Checked, _Pnone.Checked, _Ry, _Rz);
        }

        private void selectVLSconstR(object sender, EventArgs e)
        {
            _timer.Stop();
        }

        private void fillPolygons()
        {
            _linesToFill.Clear();
            fillStatic();
            fillMoveable();
        }

        private void removeCommonPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _possibleMulti.Clear();
            _drawPanel.Invalidate();
        }

        private void _PtextR_CheckedChanged(object sender, EventArgs e)
        {
            _drawPanel.Invalidate();
        }
        

        private void _IOtextR_CheckedChanged(object sender, EventArgs e)
        {
            _drawPanel.Invalidate();
        }

        private void _NconstR_CheckedChanged(object sender, EventArgs e)
        {
            _drawPanel.Invalidate();
        }

        private void _fButton_Click(object sender, EventArgs e)
        {
            double val;
            if(Double.TryParse(_fTextBox.Text, out val))
            {
                _fillTool._f = val;
                _drawPanel.Invalidate();
            }
        }

        private void sphereMoving(object sender, MouseEventArgs e)
        {
                _fillTool.middlePoint = e.Location;
        }

        private void _NsphereR_CheckedChanged(object sender, EventArgs e)
        {
            //_drawPanel.Invalidate();
        }

        private void fillMulti()
        {
            foreach (var poly in _possibleMulti)
                _fillTool.fillPolygon(poly, _VLSconstR.Checked, _IOconstR.Checked, _NconstR.Checked, _NtextR.Checked, _Pnone.Checked, _Ry, _Rz);
        }
        private void selectR(object sender, EventArgs e)
        {
            if (!Double.TryParse(_VLStextbox.Text, out _R) || _possibleMulti.Count>0)
            {
                _VLSconstR.Checked = true;
            }
            else
            {
                _Ry = _drawPanel.Height / 2;
                _timer.Start();

            }
        }
    }
}
