using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iOTClient
{
    public partial class iotRobot : UserControl
    {
        private Dictionary<Control, bool> draggables =
                   new Dictionary<Control, bool>();
        private System.Drawing.Size mouseOffset;

        public iotRobot()
        {
            InitializeComponent();
            lblRobot.Text = RobotName;
        }

        [Description("Resmin Üzerinde Gösterilecek Yazı"), Category("Data")]
        public string RobotName
        {
            get { return lblRobot.Text; }
            set { lblRobot.Text = value; }
        }

        public Font RobotFontSize
        {
            get { return lblRobot.Font; }
            set { lblRobot.Font = value; }
        }

        [Description("Resmin Üzerinde Gösterilecek Yazı"), Category("Data")]
        public Image RobotImage
        {
            get { return pRobotImage.Image; }
            set { pRobotImage.Image = value; }
        }

        [Description("Resmin Üzerinde Gösterilecek Yazı"), Category("Data")]
        public PictureBoxSizeMode RobotSizeMode
        {
            get { return pRobotImage.SizeMode; }
            set { pRobotImage.SizeMode = value; }
        }

        public new event MouseEventHandler MouseDown
        {
            add
            {
                base.MouseDown += value;
                foreach (Control control in Controls)
                {
                    control.MouseDown += value;
                }
            }
            remove
            {
                base.MouseDown -= value;
                foreach (Control control in Controls)
                {
                    control.MouseDown -= value;
                }
            }
        }

        public new event MouseEventHandler MouseMove
        {
            add
            {
                base.MouseMove += value;
                foreach (Control control in Controls)
                {
                    control.MouseMove += value;
                }
            }
            remove
            {
                base.MouseMove -= value;
                foreach (Control control in Controls)
                {
                    control.MouseMove -= value;
                }
            }
        }

        public new event MouseEventHandler MouseUp
        {
            add
            {
                base.MouseUp += value;
                foreach (Control control in Controls)
                {
                    control.MouseUp += value;
                }
            }
            remove
            {
                base.MouseUp -= value;
                foreach (Control control in Controls)
                {
                    control.MouseUp -= value;
                }
            }
        }
    }
}
