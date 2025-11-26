using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto1
{
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            InitializeComponent();
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {

            // Accedemos a base de datos para mostrar resultados en datagridview

            string connectionString = @"Server=.;Database=CalculadoraDB;TrustServerCertificate=true;Integrated Security=SSPI;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT Operacion, Resultado FROM Calculos ORDER BY Id DESC";
                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvHistorial.DataSource = tabla;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
