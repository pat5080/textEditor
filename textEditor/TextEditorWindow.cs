using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditor
{
    public partial class TextEditorWindow : Form
    {
        AccountHandler accountLoad;
        public TextEditorWindow(ref AccountHandler accountLoad)
        {
            InitializeComponent();
            this.accountLoad = accountLoad;
            Show();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
