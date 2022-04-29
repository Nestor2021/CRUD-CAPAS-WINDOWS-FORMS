using CapaNegocio;
using System.Windows;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProds();
        }

        private void LeerProds()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.LeerProd();
        }

        private void LimpiarForm()
        {
            txtProd.Clear();
            txtDesc.Clear();
            txtPrec.Clear();
            txtExis.Clear();
            txtProd.Clear();
            txtEsta.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            {
                //Agregar
                if(Editar == false)
                {
                    try
                    {
                        objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text);
                        MessageBox.Show("Registro Insertado exitosamente");
                        LeerProds();
                        LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Registro no pude ser agregado, el motivo es: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //editar
                if (Editar == true)
                {
                    try
                    {
                        objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text,idProducto);
                        MessageBox.Show("Registro se actualizo exitosamente");
                        LeerProds();
                        LimpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                       
                        MessageBox.Show("Registro no pude ser actualizado, el motivo es: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            {
                if(dataGridView1.SelectedRows.Count > 0)
                {
                    Editar = true;
                    txtProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.ToString();
                    txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                    txtPrec.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                    txtExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                    txtEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                    idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Favor seleccionar una fila", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                    objetoCN.EliProd(idProducto);
                    MessageBox.Show("Se ha Eliminado", "Eliminar");
                    LeerProds();
                }
                else
                {
                    MessageBox.Show("Favor seleccionar una fila", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);                   
                }
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult opc;
            opc = MessageBox.Show("Desea salir? ", "Salir del formulario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opc == DialogResult.OK)
            {
                Close();
            }
        }
    }
}