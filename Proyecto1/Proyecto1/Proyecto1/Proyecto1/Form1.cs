using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.Scale(new SizeF(1f, 1f));
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            txtScreen.Text = "0";
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 1) txtScreen.Text = "0";
            else txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1);
        }

        private void btn_uno_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "1";
        }

        private void btn_dos_Click(object sender, EventArgs e)
        {

            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {

            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "3";
        }

        private void btn_cuatro_Click(object sender, EventArgs e)
        {

            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "4";
        }

        private void btn_cinco_Click(object sender, EventArgs e)
        {

            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "5";
        }

        private void btn_seis_Click(object sender, EventArgs e)
        {

            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "6";
        }

        private void btn_siete_Click(object sender, EventArgs e)
        {

            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "7";
        }

        private void btn_ocho_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "8";
        }

        private void btn_nueve_Click(object sender, EventArgs e)
        {

            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "9";
        }

        private void btn_cero_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "0";
        }

        private void btn_punto_Click(object sender, EventArgs e)
        {
            if (!txtScreen.Text.EndsWith("."))
                txtScreen.Text += ".";
        }

        private void btn_suma_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "+";
        }

        private void btn_resta_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "-";
        }

        private void btn_multi_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "*";
        }

        private void btn_division_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "/";
        }

        private void btn_igual_Click(object sender, EventArgs e)
        {
            try
            {
                string expresion = txtScreen.Text;

                // Reemplazar pi
                expresion = expresion.Replace("pi", Math.PI.ToString(CultureInfo.InvariantCulture));

                // Calcular raíces cuadradas
                expresion = Regex.Replace(expresion, @"√(\d+(\.\d+)?)", m =>
                {
                    double num = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
                    double result = Math.Pow(num, 0.5);
                    return result.ToString(CultureInfo.InvariantCulture);
                });

                // Calcular potencias
                expresion = Regex.Replace(expresion, @"(\d+(\.\d+)?)\^(\d+(\.\d+)?)", m =>
                {
                    double baseNum = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
                    double expNum = double.Parse(m.Groups[3].Value, CultureInfo.InvariantCulture);
                    double result = Math.Pow(baseNum, expNum);
                    return result.ToString(CultureInfo.InvariantCulture);
                });

                // Evaluar el resto de la expresión
                var resultado = new System.Data.DataTable().Compute(expresion, null);
                txtScreen.Text = resultado.ToString();

                // Enviar resultados a base de datos
                string connectionString = @"Server=.;Database=CalculadoraDB;TrustServerCertificate=true;Integrated Security=SSPI;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    string query = "INSERT INTO Calculos (Operacion, Resultado) VALUES (@Operacion, @Resultado)";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Operacion", expresion);
                    comando.Parameters.AddWithValue("@Resultado", Convert.ToDecimal(resultado));
                    comando.ExecuteNonQuery();
                }

            }
            catch
            {
                txtScreen.Text = "Error";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtScreen.Text = "0";
        }

        private void btn_historial_Click(object sender, EventArgs e)
        {
            //Se abre nueva ventana para mostrar historial
            FrmHistorial ventanaHistorial = new FrmHistorial();
            ventanaHistorial.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_parentesis_izq_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "(";

        }

        private void btn_parentesis_der_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + ")";
        }

        private void btn_pi_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "pi";
        }

        private void btn_potencia_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "^";
        }

        private void btn_raiz_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text == "0") txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "√";
        }

        private void btn_negative_Click(object sender, EventArgs e)
        {
            int valor;
            valor = Int32.Parse(txtScreen.Text);

            if (valor > 0)
            {
                valor = valor * -1;
            }
            else if (valor < 0)
            {
                valor = Math.Abs(valor);
            }
            txtScreen.Text = valor.ToString();
        }

        private void txtScreen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
