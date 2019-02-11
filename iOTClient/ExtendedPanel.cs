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
        public ExtendedPanel(List<Node> node)
        {
            SetStyle(ControlStyles.Opaque, true);
            _node = node;
        }

        public List<Node> _node { get; set; } 
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
                int lastX = -1, lastY = -1;

                if(_node != null)
                {
                    var list = _node.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        var node = list[i];
                        if (lastX > -1)
                        {
                            e.Graphics.DrawLine(p, lastX, lastY, node.Pos.X, node.Pos.Y);
                            lastX = node.Pos.X;
                            lastY = node.Pos.Y;
                        }
                        else
                        {
                            lastX = node.Pos.X;
                            lastY = node.Pos.Y;
                        }
                    }
                    //while (_node.Count > 0)
                    //{
                    //    matrixNode node = _node.Pop();
                    //    if (lastX > -1)
                    //    {
                    //        e.Graphics.DrawLine(p, lastX, lastY, node.x, node.y);
                    //        lastX = node.x;
                    //        lastY = node.y;
                    //    }
                    //    else
                    //    {
                    //        lastX = node.x;
                    //        lastY = node.y;
                    //    }
                    //}
                }

            }
            base.OnPaint(e);
        }
    }
}
