using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DigitClicker
{
    public partial class FormDigitClicker : Form
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public FormDigitClicker()
        {
            InitializeComponent();
            Process.Start("D:\\[C#]\\Project_s\\Digits\\Digits\\bin\\Debug\\Digits.exe");
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxX.Text = "";
            textBoxY.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int mouseX, mouseY;

            mouseX = Cursor.Position.X;
            mouseY = Cursor.Position.Y;

            textBoxX.Text += mouseX.ToString() + Environment.NewLine;
            textBoxY.Text += mouseY.ToString() + Environment.NewLine;

        }

        public void DoMouseClick( int x, int y)
        {
            Cursor.Position = new System.Drawing.Point( x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private void buttonRepeat_Click(object sender, EventArgs e)
        {
            int x, y;
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < textBoxX.Lines.Length; i++)
                {
                    x = Convert.ToInt16(textBoxX.Lines[0]);
                    y = Convert.ToInt16(textBoxY.Lines[0]);

                    DoMouseClick(x, y);
                }
            }
        }
    }
}
