using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Tracker.Controls
{
    public class SecondaryButton : Button
    {
        public SecondaryButton()
        {
            BackColor = Color.FromArgb(255, 128, 128);
            ForeColor = Color.Black;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = new Font("Shabnam", 9.75f, FontStyle.Regular);
            Cursor = Cursors.Hand;
            TabStop = false;
        }
    }
}
