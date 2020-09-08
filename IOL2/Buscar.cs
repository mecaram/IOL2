using System;
using System.Windows.Forms;


namespace IOL2
{
    public partial class Buscar : Form
    {

        public Buscar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

        }

        private void rctBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboBuscar_SelectedValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }
    }
}
