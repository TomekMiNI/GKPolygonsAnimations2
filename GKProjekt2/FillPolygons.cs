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
    public class FillPolygons
    {
        public Bitmap _objectMap;
        public Bitmap _normalMap;
        public Bitmap _heightMap;
        public Bitmap _currentBitmap;
        public Color _lightColor;
        public Color _objectColor;
        private List<KeyValuePair<Point, int>> _linesToFill;
        private bool _VLS;
        private bool _IO;
        private bool _N;
        private bool _Ntext;
        private bool _P;
        private double _Ry, _Rz;
        public Point middlePoint = new Point(200, 200);
        public double _f { get; set; }
        public FillPolygons(int width, int height)
        {
            _currentBitmap = new Bitmap(width, height);
            _objectColor=_lightColor = Color.White;
            _normalMap = new Bitmap(Image.FromFile(@"brick_normalmap.png", true), width, height);
            _objectMap = new Bitmap(Image.FromFile(@"defaultTexture.jpe", true), width, height);
            _heightMap = new Bitmap(Image.FromFile(@"brick_heightmap.png", true),width, height);
        }


        public void makeBitmap()
        {
            foreach (var l in _linesToFill)
            {
                if (l.Key.Y >= _currentBitmap.Height || l.Key.Y < 0) continue;
                for (int i = 0; i < l.Value; i++)
                {
                    if (l.Key.X + i >= _currentBitmap.Width || l.Key.X + i < 0)
                        continue;
                    //wektor normalny Nx, Ny <-1,1> Nz <0,1>
                    double Nx, Ny, Nz;
                    Nx = Ny = 0;
                    Nz = 1;
                    if(_Ntext)
                    {
                        Nx = (((double)_normalMap.GetPixel((l.Key.X + i) % _normalMap.Width, l.Key.Y % _normalMap.Height).R) / 255 - 0.5) * 2.0;
                        Ny = ((double)_normalMap.GetPixel((l.Key.X + i) % _normalMap.Width, l.Key.Y % _normalMap.Height).G / 255 - 0.5) * 2.0;
                        Nz = (double)_normalMap.GetPixel((l.Key.X + i) % _normalMap.Width, l.Key.Y % _normalMap.Height).B / 255;

                        //normalizacja
                        Nx /= Nz;
                        Ny /= Nz;
                        Nz = 1;
                    }
                    else if(!_N)
                    {
                        //sphereMoving
                        //jesli pixel jest w zasiegu
                        double disP= Math.Sqrt((l.Key.X + i - middlePoint.X) * (l.Key.X + i - middlePoint.X) + (l.Key.Y - middlePoint.Y) * (l.Key.Y - middlePoint.Y));
                        if (disP <= 40)
                        {
                            Nx = l.Key.X + i - middlePoint.X;
                            Ny = l.Key.Y - middlePoint.Y;
                            Nz = Math.Sqrt(1600 - Nx * Nx - Ny * Ny);
                        }

                    }
                    //zaburzenie
                    //D=T*dhx + B*dhy
                    //T=[1,0,-Nx] B=[0,1,-Ny]
                    //dhx=H[x+1,y]-H[x,y] dhy=H[x,y+1]-H[x,y]

                    double dhxR, dhxB, dhyG, dhyB;
                    if (_P)
                    {
                        dhxB = dhxR = dhyB = dhyG = 0;
                    }
                    else
                    {
                        dhxR = _heightMap.GetPixel(((l.Key.X + i) + 1) % _heightMap.Width, l.Key.Y % _heightMap.Height).R - _heightMap.GetPixel((l.Key.X + i) % _heightMap.Width, l.Key.Y % _heightMap.Height).R;
                        //double dhxG = _heightMap.GetPixel(((l.Key.X+i) + 1) % _heightMap.Width, l.Key.Y).G - _heightMap.GetPixel((l.Key.X+i), l.Key.Y).G;
                        dhxB = _heightMap.GetPixel(((l.Key.X + i) + 1) % _heightMap.Width, l.Key.Y % _heightMap.Height).B - _heightMap.GetPixel((l.Key.X + i) % _heightMap.Width, l.Key.Y % _heightMap.Height).B;

                        //double dhyR = _heightMap.GetPixel((l.Key.X+i), (l.Key.Y + 1) % _heightMap.Height).R - _heightMap.GetPixel((l.Key.X+i), l.Key.Y).R;
                        dhyG = _heightMap.GetPixel((l.Key.X + i) % _heightMap.Width, (l.Key.Y + 1) % _heightMap.Height).G - _heightMap.GetPixel((l.Key.X + i) % _heightMap.Width, l.Key.Y % _heightMap.Height).G;
                        dhyB = _heightMap.GetPixel((l.Key.X + i) % _heightMap.Width, (l.Key.Y + 1) % _heightMap.Height).B - _heightMap.GetPixel((l.Key.X + i) % _heightMap.Width, l.Key.Y % _heightMap.Height).B;

                        //T
                        dhxB *= (-Nx) * _f;
                        //B
                        dhyB *= (-Ny) * _f;

                        //D = [dhxR, dhyG, dhxB+dhyB]
                    }
                    //wektor normalny po zaburzeniu
                    Nx += dhxR;
                    Ny += dhyG;
                    Nz += dhxB + dhyB;

                    //normalizacja

                    double dis = Math.Sqrt(Nx * Nx + Ny * Ny + Nz * Nz);
                    Nx /= dis;
                    Ny /= dis;
                    Nz /= dis;

                    //wersor do swiatla

                    double Lx, Ly, Lz;
                    if (_VLS)
                    {
                        Lx = 0;
                        Ly = 0;
                        Lz = 1;
                    }
                    else
                    {
                        Lx = 150-l.Key.X;
                        Ly = _Ry - (double)l.Key.Y;
                        Lz = _Rz;
                        //normalizacja
                        double dir = Math.Sqrt(Lx * Lx + Ly * Ly + Lz * Lz);
                        Lx /= dir;
                        Ly /= dir;
                        Lz /= dir;
                    }
                    double cosNL = Nx * Lx + Ny * Ly + Nz * Lz;
                    //kolor swiatla
                    double iLR = (double)_lightColor.R / 255;
                    double iLG = (double)_lightColor.G / 255;
                    double iLB = (double)_lightColor.B / 255;

                    //kolor obiektu bez zmian
                    int iOR, iOG, iOB;
                    if(_IO)
                    {
                        iOR = _objectColor.R;
                        iOG = _objectColor.G;
                        iOB = _objectColor.B;
                    }
                    else
                    {
                        iOR = _objectMap.GetPixel((l.Key.X + i) % _objectMap.Width, l.Key.Y % _objectMap.Height).R;
                        iOG = _objectMap.GetPixel((l.Key.X + i) % _objectMap.Width, l.Key.Y % _objectMap.Height).G;
                        iOB = _objectMap.GetPixel((l.Key.X + i) % _objectMap.Width, l.Key.Y % _objectMap.Height).B;
                    }
                    iLR *= iOR * cosNL;
                    if (iLR < 0)
                        iLR = 0;
                    iLG *= iOG * cosNL;
                    if (iLG < 0)
                        iLG = 0;
                    iLB *= iOB * cosNL;
                    if (iLB < 0)
                        iLB = 0;
                    _currentBitmap.SetPixel((l.Key.X + i), l.Key.Y, Color.FromArgb((int)iLR, (int)iLG, (int)iLB));
                    
                }
            }
            return;
        }

        public void fillPolygon(List<Point> _polygon2, bool VLS, bool IO, bool N, bool Ntext, bool P, double Ry, double Rz)
        {
            _Ry = Ry;
            _Rz = Rz;
            List<Point> _polygon = new List<Point>(_polygon2);
            List<KeyValuePair<Point, int>> _linesToFill = new List<KeyValuePair<Point, int>>();
            List<KeyValuePair<int, Point>> ind = new List<KeyValuePair<int, Point>>();
            List<AETPointer> AET = new List<AETPointer>();
            int i;
            for (i = 0; i < _polygon.Count; i++)
                ind.Add(new KeyValuePair<int, Point>(i, _polygon[i]));
            ind = ind.OrderBy(p => p.Value.Y).ThenBy(p => p.Value.X).ToList();
            List<Point> paintIT = new List<Point>();
            foreach (var el in ind)
                Console.Write($"{el.Value} ");
            i = 0;
            int y;
            List<Point> _pointsToFill = new List<Point>();
            for (y = ind[0].Value.Y; y < ind.Last().Value.Y; y++)
            {
                while (i < _polygon.Count && _polygon[ind[i].Key].Y == y)
                {
                    //ind[i].Value.y = y - 1;
                    _polygon[ind[i].Key] = new Point(_polygon[ind[i].Key].X, y - 1);
                    int prevind = (ind[i].Key - 1 + _polygon.Count) % _polygon.Count; //previous 
                    double a;
                    if (_polygon[prevind].X == _polygon[ind[i].Key].X)
                        a = 0;
                    else
                        a = 1 / ((double)(_polygon[ind[i].Key].Y - _polygon[prevind].Y) / (double)(_polygon[ind[i].Key].X - _polygon[prevind].X));
                    if (_polygon[prevind].Y >= _polygon[ind[i].Key].Y)
                    {
                        AET.Add(new AETPointer(a, _polygon[ind[i].Key].X, ind[i].Key, prevind));
                    }
                    else
                    {
                        for (int rem = 0; rem < AET.Count; rem++)
                            if (AET[rem].vertex1 == prevind && AET[rem].vertex2 == ind[i].Key)
                            {
                                AET.RemoveAt(rem);
                                break;
                            }
                    }
                    int nextind = (ind[i].Key + 1) % _polygon.Count; //next 

                    if (_polygon[nextind].X == _polygon[ind[i].Key].X)
                        a = 0;
                    else
                        a = 1 / ((double)(_polygon[ind[i].Key].Y - _polygon[nextind].Y) / (double)(_polygon[ind[i].Key].X - _polygon[nextind].X));
                    if (_polygon[nextind].Y >= _polygon[ind[i].Key].Y)
                    {

                        int rozmiar = AET.Count;
                        AET.Add(new AETPointer(a, _polygon[ind[i].Key].X, ind[i].Key, nextind));
                    }
                    else
                    {
                        for (int rem = 0; rem < AET.Count; rem++)
                            if (AET[rem].vertex1 == nextind && AET[rem].vertex2 == ind[i].Key)
                            {
                                AET.RemoveAt(rem);
                                break;
                            }
                    }
                    i++;
                }

                //update AET

                //sort
                AET.Sort();
                for (int k = 0; k < AET.Count; k += 2)
                {
                    int _width = k + 1 < AET.Count ? (int)(AET[k + 1].x - AET[k].x) : 1;
                    _linesToFill.Add(new KeyValuePair<Point, int>(new Point((int)AET[k].x, y), _width));

                }
                //update x foreach AETPointer
                foreach (var el in AET)
                    el.x += el.a;
            }
            this._linesToFill = new List<KeyValuePair<Point, int>>(_linesToFill);
            _VLS = VLS;
            _N = N;
            _Ntext = Ntext;
            _IO = IO;
            _P = P;
            //if (!_VLS)
            //{
            //    _Ry = _R;
            //    _timer.Start();
            //}
            makeBitmap();
        }

    }
}
