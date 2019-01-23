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

        private List<List<Point>> _possibleMulti = new List<List<Point>>();
        private void findCrossPoints(List<Point> _clip, List<Point> _subject)
        {
            _crossPoints.Clear();
            //   List<Point> _crossPoints = new List<Point>();

            //Point.X - indeks in _crossPoints, Point.Y - which segment (0 = <0-1>)
            List<Point> _clipCross = new List<Point>();
            List<Point> _subjectCross = new List<Point>();
            for (int i = 0; i < _subject.Count; i++)
                for (int j = 0; j < _clip.Count; j++)
                {
                    Point? p = areCrossing(_subject[i], _subject[(i + 1) % _subject.Count], _clip[j], _clip[(j + 1) % _clip.Count]);
                    if (p != null)
                    {
                        //MessageBox.Show($"static {i} oraz move {j}");
                        _crossPoints.Add((Point)p);
                        _clipCross.Add(new Point(_crossPoints.Count - 1, j));
                        _subjectCross.Add(new Point(_crossPoints.Count - 1, i));
                    }
                }
            if (_crossPoints.Count == 0)
                return;
            _clipCross = _clipCross.OrderBy(p => p.Y).ThenBy(p => Math.Sqrt((_crossPoints[p.X].X - _clip[p.Y].X) * (_crossPoints[p.X].X - _clip[p.Y].X) + (_crossPoints[p.X].Y - _clip[p.Y].Y) * (_crossPoints[p.X].Y - _clip[p.Y].Y))).ToList();
            _subjectCross = _subjectCross.OrderBy(p => p.Y).ThenBy(p => Math.Sqrt((_crossPoints[p.X].X - _subject[p.Y].X) * (_crossPoints[p.X].X - _subject[p.Y].X) + (_crossPoints[p.X].Y - _subject[p.Y].Y) * (_crossPoints[p.X].Y - _subject[p.Y].Y))).ToList();

            //List<Point> _clipWithCrossing = new List<Point>();
            //List<Point> _subjectWithCrossing = new List<Point>();
            int crossind = 0;
            for (int i = 0; i < _clip.Count; i++)
            {
                // <0 oznacza ze to punkt wielomianu, nie przeciecia
                _clipWithCrossing.Add(new Point(_clip[i].X, -_clip[i].Y));
                while (crossind < _crossPoints.Count && _clipCross[crossind].Y == i)
                {
                    _clipWithCrossing.Add(new Point(_crossPoints[_clipCross[crossind].X].X, _crossPoints[_clipCross[crossind].X].Y));
                    crossind++;
                }
            }
            crossind = 0;
            for (int i = 0; i < _subject.Count; i++)
            {
                _subjectWithCrossing.Add(new Point(_subject[i].X, -_subject[i].Y));
                while (crossind < _crossPoints.Count && _subjectCross[crossind].Y == i)
                {
                    _subjectWithCrossing.Add(new Point(_crossPoints[_subjectCross[crossind].X].X, _crossPoints[_subjectCross[crossind].X].Y));
                    crossind++;
                }
            }
            //Graphics g = _drawPanel.CreateGraphics();
            //while (indeksor < _subjectCross.Count)
            //{
            //    g.FillEllipse(Brushes.Yellow, new Rectangle(_crossPoints[_subjectCross[indeksor].X].X-3, _crossPoints[_subjectCross[indeksor].X].Y-3, 7, 7));
            //    indeksor+=2;
            //}
            List<Point> _finalList = new List<Point>();
            List<Point> _inputV = new List<Point>();
            int indeksor = 0;
            while (indeksor < _subjectCross.Count)
            {
                _inputV.Add(new Point(_crossPoints[_subjectCross[indeksor].X].X, _crossPoints[_subjectCross[indeksor].X].Y));
                indeksor += 2;
            }
            //znajdz input0 w subjectWithCrossing
            bool[] _usedInputs = new bool[_inputV.Count];
            int nextind = 0;
            for (int i = 0; i < _inputV.Count; i++)
            {
                _usedInputs[nextind] = true;
                nextind = _subjectWithCrossing.FindIndex(p => p.X == _inputV[nextind].X && p.Y == _inputV[nextind].Y);
                //nextind indeks _inputV[0] w subjectwithcrossing
                _finalList.Add(new Point(_subjectWithCrossing[nextind].X, _subjectWithCrossing[nextind++].Y));


                while (nextind < _subjectWithCrossing.Count && _subjectWithCrossing[nextind].Y < 0)
                {
                    _finalList.Add(new Point(_subjectWithCrossing[nextind % _subjectWithCrossing.Count].X, -_subjectWithCrossing[nextind % _subjectWithCrossing.Count].Y));
                    nextind++;
                }

                //spotkalismy wierzcholek wchodzacy do drugiego wielokata
                nextind = _clipWithCrossing.FindIndex(p => p.X == _subjectWithCrossing[nextind % _subjectWithCrossing.Count].X && p.Y == _subjectWithCrossing[nextind % _subjectWithCrossing.Count].Y);
                _finalList.Add(new Point(_clipWithCrossing[nextind].X, _clipWithCrossing[nextind++].Y));

                while (_clipWithCrossing[nextind % _clipWithCrossing.Count].Y < 0)
                {
                    _finalList.Add(new Point(_clipWithCrossing[nextind % _clipWithCrossing.Count].X, -_clipWithCrossing[nextind % _clipWithCrossing.Count].Y));
                    nextind++;
                }
                nextind = _inputV.FindIndex(p => p.X == _clipWithCrossing[nextind % _clipWithCrossing.Count].X && p.Y == _clipWithCrossing[nextind % _clipWithCrossing.Count].Y);
                if (nextind == -1) break;
                if (_usedInputs[nextind])
                {
                    _possibleMulti.Add(new List<Point>(_finalList));
                    _finalList.Clear();
                    for (int j = 0; j < _usedInputs.Length; j++)
                        if (!_usedInputs[j])
                        {
                            nextind = j;
                            break;
                        }
                }
            }
            //Graphics g = _drawPanel.CreateGraphics();
            //foreach (Point p in _finalList)
            //    g.FillEllipse(Brushes.Yellow, new Rectangle(p.X - 3, p.Y - 3, 7, 7));
            //_staticPolygon.Clear();
            //_movePolygon.Clear();
        }
        private Point? areCrossing(Point _s1, Point _e1, Point _s2, Point _e2)
        {
            long d1 = (_e2.X - _s2.X) * (_s1.Y - _s2.Y) - (_s1.X - _s2.X) * (_e2.Y - _s2.Y);
            long d2 = (_e2.X - _s2.X) * (_e1.Y - _s2.Y) - (_e1.X - _s2.X) * (_e2.Y - _s2.Y);
            long d3 = (_e1.X - _s1.X) * (_s2.Y - _s1.Y) - (_s2.X - _s1.X) * (_e1.Y - _s1.Y);
            long d4 = (_e1.X - _s1.X) * (_e2.Y - _s1.Y) - (_e2.X - _s1.X) * (_e1.Y - _s1.Y);

            long d12 = d1 * d2;
            long d34 = d3 * d4;
            if (d12 > 0 || d34 > 0)
                return null;
            if (d12 < 0 || d34 < 0)
                return crossPoint(_s1, _e1, _s2, _e2);
            if (onRectangle(_s1, _s2, _e2) || onRectangle(_e1, _s2, _e2) || onRectangle(_s2, _s1, _e1) || onRectangle(_e2, _s1, _e1))
                return crossPoint(_s1, _e1, _s2, _e2);
            return null;
        }
        private bool onRectangle(Point _s1, Point _s2, Point _e2)
        {
            return Math.Min(_s2.X, _e2.X) <= _s1.X && Math.Max(_s2.X, _e2.X) >= _s1.X && Math.Min(_s2.Y, _e2.Y) <= _s1.Y && Math.Max(_s2.Y, _e2.Y) >= _s1.Y;
        }
        private Point crossPoint(Point _s1, Point _e1, Point _s2, Point _e2)
        {
            //a1
            double a1;
            if (_e1.X == _s1.X)
                a1 = Double.MaxValue;
            else
                a1 = (double)((double)(_s1.Y - _e1.Y) / (double)(_s1.X - _e1.X));
            //b1
            double b1 = _s1.X;
            if (a1 != Double.MaxValue)
                b1 = (double)_s1.Y - a1 * (double)_s1.X;

            //a2
            double a2;
            if (_e2.X == _s2.X)
                a2 = Double.MaxValue;
            else
                a2 = (double)((double)(_s2.Y - _e2.Y) / (double)(_s2.X - _e2.X));
            //b2
            double b2 = _s2.X;
            if (a2 != Double.MaxValue)
                b2 = (double)_s2.Y - a2 * (double)_s2.X;
            if (a1 == a2)
            {
                //nakladaja sie
            }
            if (a1 == Double.MaxValue)
                return new Point((int)b1, (int)(a2 * b1 + b2));
            if (a2 == Double.MaxValue)
                return new Point((int)b2, (int)(a1 * b2 + b1));
            double newX = (b2 - b1) / (a1 - a2);
            return new Point((int)newX, (int)(a1 * newX + b1));
        }
    }
}