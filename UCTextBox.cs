using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class UCTextBox : UserControl
    {
        public UCTextBox()
        {
            InitializeComponent();


            TextBoxNumeric numericTextBox = new TextBoxNumeric();

            numericTextBox.Dock = DockStyle.Fill;

            this.Controls.Add(numericTextBox);
        }

    }
}
