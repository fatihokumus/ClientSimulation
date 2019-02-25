using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iOTClient
{
    public class ExtendedPanel : Panel
    {
        private const int WS_EX_TRANSPARENT = 0x20;
        public ExtendedPanel(List<List<GridPiont>> node, int distance)
        {
            SetStyle(ControlStyles.Opaque, true);
            _node = node;
            _distance = distance;
        }

        public List<List<GridPiont>> _node { get; set; }
        public int _distance { get; set; }
        private int opacity = 0;
        [DefaultValue(0)]
        public int Opacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("value must be between 0 and 100");
                this.opacity = value;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
                Pen p = new Pen(Color.Red, 5);

                if(_node != null)
                {
                    for (int j = 0; j < _node.Count; j++)
                    {
                        int lastX = -1, lastY = -1;
                        var list = _node[j].ToList();
                        for (int i = 0; i < list.Count; i++)
                        {
                            var node = list[i];
                            var rDis = _distance / 2;
                            if (lastX > -1)
                            {
                                e.Graphics.DrawLine(p, lastX, lastY, node.XPoint * _distance + rDis, node.YPoint * _distance + rDis);
                                lastX = node.XPoint * _distance + rDis;
                                lastY = node.YPoint * _distance + rDis;
                            }
                            else
                            {
                                lastX = node.XPoint * _distance + rDis;
                                lastY = node.YPoint * _distance + rDis;
                            }
                        }
                    }
                    
                }

            }
            base.OnPaint(e);
        }

        public void ClearColor(PaintEventArgs e)
        {
            // Clear screen with teal background.
            e.Graphics.Clear(Color.Teal);
        }
    }
}
