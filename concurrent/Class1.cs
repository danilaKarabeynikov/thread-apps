using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
namespace ThreadApp
{
    class Butt : Button 
    {
        public void CreateMyButt(Button btn, Form frm, string str, int x, int y, int w, int h, EventHandler evh)
        {
            btn = new Button();
            btn.Text = str;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.Click += evh;
            frm.Controls.Add(btn);
        }
    }

    class SortMessage : TextBox
    {
        public void CreateSortMessageBox(ref TextBox text, Form frm, string str, int x, int y, int w, int h)
        {
            text = new TextBox();
            text.Text = str;
            text.Location = new Point(x, y);
            text.Size = new Size(w, h);
            frm.Controls.Add(text);
        }
    }
}
