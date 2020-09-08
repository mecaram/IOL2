using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace IOL2
{
    public partial class Prueba : Form
    {
        //Token tkn1 = new Token("riazorII@live.com.ar", "Rb441168");
        readonly Token tkn1 = new Token("mecaram", "Mec18047");

        public Prueba()
        {
            InitializeComponent();
        }

        private void btnObtenerToken_Click(object sender, EventArgs e)
        {
            tkn1.ObtenerToken();
            MessageBox.Show(tkn1.access_token);
            MessageBox.Show(tkn1.refresh_token);

        }

        private void btnRefrescarToken_Click(object sender, EventArgs e)
        {
            tkn1.RefrescarToken();
            MessageBox.Show(tkn1.access_token);
            MessageBox.Show(tkn1.refresh_token);

        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            tkn1.ObtenerToken();
            Operaciones panel1 = new Operaciones();
            panel1.ObtenerPanel(tkn1.access_token);
        }

        private void btnObtenerCotizacion_Click(object sender, EventArgs e)
        {
            tkn1.ObtenerToken();
            Operaciones panel1 = new Operaciones();
            panel1.ObtenerCotizacion(tkn1.access_token, "bCBA", "ALUA", "t2");
        }

        private void btnObtenerDatosTitulo_Click(object sender, EventArgs e)
        {
            tkn1.ObtenerToken();
            Operaciones datostitulo = new Operaciones();
            datostitulo.ObtenerDatosTitulo(tkn1.access_token, "bCBA", "ALUA");

        }

        private void btnObtenerSerieHistorica_Click(object sender, EventArgs e)
        {
            tkn1.ObtenerToken();
            Operaciones opera = new Operaciones();
            opera.ObtenerSerieHistorica(tkn1.access_token, "bCBA", "ALUA", "sinajustar", "01/01/2020", "01/31/2020");
        }

        private void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            var txtIdRueda = new TextBox();
            txtIdRueda.Text = "22";

            int simulador = 1;
            string simbolo = "ALUA";
            double cantidadcomprada = 100;
            double preciocompra = 50.5;
            double importe = cantidadcomprada * preciocompra;
            double precioactual = preciocompra;

            var txtPorcComisionIOL = new TextBox();
            txtPorcComisionIOL.Text = "0.7";

            double comisionIOL = importe * 0.7 / 100;
            int IndicePaneles = 10;

            string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            using (MySqlConnection cone = new MySqlConnection(conexion))
            {
                cone.Open();
                string sentencia = string.Format("Insert Into RuedasDetalleSimulador(IdRuedaActual, IdRuedaCompra, IdSimulacion, " +
                                          "FechaCompra, Simbolo, Cantidad, " +
                                          "PrecioCompra, ImporteCompra, UltimoPrecio," +
                                          "FechaUltimoPrecio, VariacionenPesos, VariacionenPorcentajes," +
                                          "Estado, PorcComisionIOL, ImporteComisionIOL, IdPanel) " +
                                          "Values({0}, {1}, {2}, " +
                                          "str_to_date('{3}','%d/%m/%Y'),'{4}',{5}, " +
                                          "{6},{7},{8}," +
                                          "str_to_date('{9}','%d/%m/%Y'),{10},{11}," +
                                          "'{12}',{13},{14},{15})",
                                           txtIdRueda.Text, txtIdRueda.Text, simulador,
                                           DateTime.Now.ToShortDateString(), simbolo, cantidadcomprada,
                                           preciocompra, importe, precioactual,
                                           DateTime.Now.ToShortDateString(), 0, 0,
                                           "Comprado", txtPorcComisionIOL.Text.Trim(), comisionIOL, IndicePaneles);
                var comando = new MySqlCommand(sentencia, cone);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                cone.Close();
            }

        }
    }
}
