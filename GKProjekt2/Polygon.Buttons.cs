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
        private void fillPolygonsBtn(object sender, EventArgs e)
        {
            _drawPanel.Invalidate();
        }

        private void removePolygonsBtn(object sender, EventArgs e)
        {
            _linesToFill.Clear();
            _movePolygon.Clear();
            _staticPolygon.Clear();
            _drawPanel.Invalidate();
        }

        private void removeVerticle(object sender, EventArgs e)
        {
            if (_selectedV != -1 && _movePolygon.Count > 3)
            {
                _movePolygon.RemoveAt(_selectedV);
                _selectedV = -1;
                _drawPanel.Invalidate();
            }
        }

        private void selectIOconstR(object sender, EventArgs e)
        {
            _fillTool._objectColor = _IOconstC.BackColor;
        }

        private void _IOtextBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "image file (*.png)|*.png|(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _fillTool._objectMap = (Bitmap)Image.FromStream(ofd.OpenFile());
                _IOtextC.Image = _fillTool._objectMap;
            }
            ofd.Dispose();
        }

        private void changeColorIL(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            _fillTool._lightColor = _ILcolor.BackColor = cd.Color;
        }
        private void findCommonPart(object sender, EventArgs e)
        {
            _linesToFill.Clear();
            findCrossPoints(_movePolygon, _staticPolygon);
            _drawPanel.Invalidate();
        }

        private void changeColorIO(object sender, EventArgs e)
        {

            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            _IOconstC.BackColor = cd.Color;
        }

        private void changePerturbation(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "image file (*.png)|*.png|(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _fillTool._heightMap = (Bitmap)Image.FromStream(ofd.OpenFile());
            }
            ofd.Dispose();
        }

        private void changeNormalMap(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "image file (*.png)|*.png|(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _fillTool._normalMap = (Bitmap)Image.FromStream(ofd.OpenFile());
                _Ncolor.Image = _fillTool._normalMap;
            }
            ofd.Dispose();
        }

        private void staticDrawClick(object sender, EventArgs e)
        {
            if (_staticPolygon.Count == 0)
                _drawStatic = true;
        }

        private void moveableDrawClick(object sender, EventArgs e)
        {
            if (_movePolygon.Count == 0)
                _drawMoveable = true;
        }

    }
}
