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
        private bool isVerticalOnThisEdge(Point _check, int i)
        {
            Point _p1 = _movePolygon[i];
            Point _p2 = _movePolygon[(i + 1) % _movePolygon.Count];
            if (_check.X <= Math.Max(_p1.X, _p2.X) && _check.X >= Math.Min(_p1.X, _p2.X) && _check.Y <= Math.Max(_p1.Y, _p2.Y) && _check.Y >= Math.Min(_p1.Y, _p2.Y))
            {
                if ((_check.Y - _p2.Y) == 0 || (_check.Y - _p1.Y) == 0 || (_check.X - _p2.X) == 0 || (_check.X - _p1.X) == 0)
                {
                    if (Math.Abs(_check.Y - _p1.Y) == 0 && Math.Abs(_p2.Y - _check.Y) == 0)
                    {
                        if (_check.X <= Math.Max(_p1.X, _p2.X) && _check.X >= Math.Min(_p1.X, _p2.X))
                        {
                            return true;
                        }
                        return false;
                    }
                    if (Math.Abs(_check.X - _p1.X) == 0 && Math.Abs(_p2.X - _check.X) == 0)
                    {
                        if (_check.Y <= Math.Max(_p1.Y, _p2.Y) && _check.Y >= Math.Min(_p1.Y, _p2.Y))
                        {
                            return true;
                        }
                        return false;
                    }
                }
                foreach (var el in _movePolygon)
                    if (_check == el)
                        return true;
            }
            return false;
        }
        private void addVerticle(object sender, MouseEventArgs e)
        {
            if (!_drawStatic && !_drawMoveable && _movePolygon.Count > 0)
            {
                for (int i = 0; i < _movePolygon.Count; i++)
                    if (isVerticalOnThisEdge(e.Location, i))
                    {
                        _movePolygon.Insert((i + 1) % _movePolygon.Count, e.Location);
                        _drawPanel.Invalidate();
                        return;
                    }
            }
        }
        private void swapPolygon(MouseEventArgs e, List<Point> _list, Point _center)
        {
            int diffX = e.Location.X - _center.X;
            int diffY = e.Location.Y - _center.Y;
            for (int j = 0; j < _list.Count; j++)
                _list[j] = new Point(_list[j].X + diffX, _list[j].Y + diffY);


        }
        //mousemove
        private void swaping(object sender, MouseEventArgs e)
        {
            if (_timeToSwapV)
            {
                swapVerticle(e);
                updateCenter(false);
            }
            else if (_timeToSwapStaticP)
            {
                swapPolygon(e, _staticPolygon, _staticCenterPoint);
                updateCenter(true);
            }
            else if (_timeToSwapMoveableP)
            {
                swapPolygon(e, _movePolygon, _moveCenterPoint);
                updateCenter(false);
            }
            else if (_NsphereR.Checked)
                sphereMoving(sender, e);
            else return;
            _drawPanel.Invalidate();
        }
        private void updateCenter(bool _static)
        {
            List<Point> _listOfSegments = new List<Point>();
            if (_static)
                _listOfSegments = _staticPolygon;
            else
                _listOfSegments = _movePolygon;
            if (_listOfSegments.Count == 0) return;
            int sumX = 0;
            int sumY = 0;
            foreach (var el in _listOfSegments)
            {
                sumX += el.X;
                sumY += el.Y;
            }
            Point centerPoint = new Point(sumX / _listOfSegments.Count, sumY / _listOfSegments.Count);
            if (_static)
                _staticCenterPoint = centerPoint;
            else
                _moveCenterPoint = centerPoint;
        }
        //mouseup
        private void stopSwaping(object sender, MouseEventArgs e)
        {
            _timeToSwapMoveableP = _timeToSwapV = _timeToSwapStaticP = false;
        }
        private void swapVerticle(MouseEventArgs e)
        {
            _movePolygon[_selectedV] = e.Location;
        }
        private bool centerClick(Point clickp, Point p)
        {
            if (Math.Sqrt((clickp.X - p.X) * (clickp.X - p.X) + (clickp.Y - p.Y) * (clickp.Y - p.Y)) > 3)
                return false;
            return true;
        }
        private void modifyPolygon(MouseEventArgs e)
        {
            Point verify = e.Location;
            if (centerClick(verify, _staticCenterPoint))
            {
                _timeToSwapStaticP = true;
                return;
            }
            if (centerClick(verify, _moveCenterPoint))
            {
                _timeToSwapMoveableP = true;
                return;
            }
            for (int i = 0; i < _movePolygon.Count; i++)
                //vertically.Text = $"{verify.X}, {verify.Y} - {_movePolygon[i].First().X}.{_movePolygon[i].First().Y}";
                if (Math.Abs(verify.X - _movePolygon[i].X) <= 3 && Math.Abs(verify.Y - _movePolygon[i].Y) <= 3)
                {
                    _timeToSwapV = true;
                    //drawVerticle(_movePolygon[i].First().X, _movePolygon[i].First().Y, Brushes.Yellow);
                    Graphics g = _drawPanel.CreateGraphics();
                    g.FillEllipse(Brushes.Yellow, new Rectangle(_movePolygon[i].X - 3, _movePolygon[i].Y - 3, 7, 7));
                    g.Dispose();
                    _selectedV = i;
                    return;
                }
            _selectedV = -1;
        }

    }
}
