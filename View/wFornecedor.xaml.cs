using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrimeiraAPP.Controller;

namespace PrimeiraAPP.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



        }
        ControllerFornecedor fornecedor;
        ControllerFornecedor controllerFornecedor = new ControllerFornecedor();


        private void txtCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {


            AjustaMascaraCnpj();



        }


        private void AjustaMascaraCnpj()
        {
            int cont = 0;
            int cursorPos = txtCnpj.SelectionStart;




            foreach (Char c in txtCnpj.Text)
            {
                if (((cont == 2) || (cont == 6)) && (c != '.') && (txtCnpj.Text.Length >= cont))
                {
                    txtCnpj.Text = txtCnpj.Text.Insert(cont, ".");
                    txtCnpj.SelectionStart = cursorPos + 1;
                }
                if ((c == '.') && (txtCnpj.Text.Length >= cont) && (cont != 2) && (cont != 6))
                {
                    txtCnpj.Text = txtCnpj.Text.Remove(cont, 1);
                    txtCnpj.SelectionStart = cursorPos;
                }

                if ((cont == 10) && (c != '/') && (txtCnpj.Text.Length >= cont))
                {
                    txtCnpj.Text = txtCnpj.Text.Insert(10, @"/");
                    txtCnpj.SelectionStart = cursorPos + 1;
                }
                if ((c == '/') && (cont != 10) && (txtCnpj.Text.Length >= cont))
                {
                    txtCnpj.Text = txtCnpj.Text.Remove(cont, 1);
                    txtCnpj.SelectionStart = cursorPos;
                }

                if ((cont == 15) && (c != '-') && (txtCnpj.Text.Length >= cont))
                {
                    txtCnpj.Text = txtCnpj.Text.Insert(15, "-");
                    txtCnpj.SelectionStart = cursorPos + 1;
                }
                if ((c == '-') && (cont != 15) && (txtCnpj.Text.Length >= cont))
                {
                    txtCnpj.Text = txtCnpj.Text.Remove(cont, 1);
                    txtCnpj.SelectionStart = cursorPos;
                }

                cont++;
            }



        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            string status;

            if (rbFornecedorAtivo.IsChecked == true)
            {
                status = "1";
            }
            else
            {
                status = "0";
            }
            dgFornecedor.SelectedItems.Clear();

            fornecedor = new ControllerFornecedor(txtId.Text, txtInscricaoEstadual.Text, txtNome.Text, txtEstado.Text, txtNumero.Text, txtComplemento.Text, txtBairro.Text, txtCidade.Text, txtCEp.Text, status, txtRua.Text, txtCnpj.Text);
            fornecedor.AdicionaFornecedor();

            if (fornecedor.Mensagem != "")
            {
                const string caption = "Ocorreu um erro?";
                var result = MessageBox.Show(fornecedor.Mensagem, caption,
                                              MessageBoxButton.OK,
                                              MessageBoxImage.Warning);

            }
            LimpaCampos();
            dgFornecedor.ItemsSource = controllerFornecedor.ListaFornecedor().DefaultView;

        }

        private void LimpaCampos()
        {
            txtBairro.Clear();
            txtCEp.Clear();
            txtCidade.Clear();
            txtCnpj.Clear();
            txtComplemento.Clear();
            txtEstado.Clear();
            txtId.Clear();
            txtInscricaoEstadual.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            txtRua.Clear();


        }

        private void wFornecedor_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)

        {


            if (ckbInativo.IsChecked == true)
            {
                dgFornecedor.SelectedItems.Clear();
                dgFornecedor.ItemsSource = controllerFornecedor.ListaTodosFornecedores().DefaultView;


            }
            else
            {

                dgFornecedor.SelectedItems.Clear();

                dgFornecedor.ItemsSource = controllerFornecedor.ListaFornecedor().DefaultView;

            }




        }

        private void dgFornecedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgFornecedor.SelectedCells.Count > 0)
            {

                this.txtId.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["idFornecedor"].ToString();
                this.txtCnpj.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["Cnpj"].ToString();
                this.txtNome.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["nomeFantasia"].ToString();
                this.txtInscricaoEstadual.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["inscricaoEstadual"].ToString();
                this.txtCEp.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["cepFornecedor"].ToString();
                this.txtRua.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["Rua"].ToString();
                this.txtEstado.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["uf"].ToString();
                this.txtNumero.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["numero"].ToString();
                this.txtComplemento.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["complemento"].ToString();
                this.txtBairro.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["bairro"].ToString();
                this.txtCidade.Text = ((DataRowView)dgFornecedor.SelectedItem).Row["cidade"].ToString();

                bool ativo = bool.Parse(((DataRowView)dgFornecedor.SelectedItem).Row["statusAtivo"].ToString());

                if (ativo == true)
                {
                    rbFornecedorAtivo.IsChecked = true;
                }
                else
                    rbFornecedorInativo.IsChecked = true;

            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            string status;

            if (rbFornecedorAtivo.IsChecked == true)
            {
                status = "1";
            }
            else
            {
                status = "0";
            }
            dgFornecedor.SelectedItems.Clear();

            fornecedor = new ControllerFornecedor(txtId.Text, txtInscricaoEstadual.Text, txtNome.Text, txtEstado.Text, txtNumero.Text, txtComplemento.Text, txtBairro.Text, txtCidade.Text, txtCEp.Text, status, txtRua.Text, txtCnpj.Text);
            fornecedor.AlterarFornecedor();

            if (fornecedor.Mensagem != "")
            {
                const string caption = "Ocorreu um erro?";
                var result = MessageBox.Show(fornecedor.Mensagem, caption,
                                              MessageBoxButton.OK,
                                              MessageBoxImage.Warning);

            }
            LimpaCampos();
            dgFornecedor.ItemsSource = controllerFornecedor.ListaFornecedor().DefaultView;

        }
    }
}


