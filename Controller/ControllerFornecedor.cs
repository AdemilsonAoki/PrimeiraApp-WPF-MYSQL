using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PrimeiraAPP.Model;
using PrimeiraAPP.Data;
using System.Data;

namespace PrimeiraAPP.Controller
{
    class ControllerFornecedor
    {
        string mensagem = "";
        string resposta = "";
        string inscricaoSoNumeros = "";
        string cepSoNumeros = "";


        Fornecedor fornecedor = new Fornecedor();
        MySqlCommand cmd = new MySqlCommand();
        Conexao conexao = new Conexao();
        DataSet mDts = new DataSet("Retorno");

        public DataSet RetornoDts
        {
            get { return mDts; }
            set { mDts = value; }
        }

        public string Mensagem { get { return mensagem; } set { mensagem = value; } }
        public string Resposta { get { return resposta; } set { resposta = value; } }
        public ControllerFornecedor()
        {

        }

        public ControllerFornecedor(string idFornecedor, string inscricaoEstadual, string nomeFantasia, string uf, string numero, string complemento, string bairro, string cidade,
                                    string cep, string statusAtivo, string rua, string cnpj)
        {

            if (mensagem == "")
            {
                try
                {
                    if (!string.IsNullOrEmpty(idFornecedor))
                    {
                        fornecedor.Id = int.Parse(idFornecedor);
                    }
                    if (!string.IsNullOrEmpty(rua) && !string.IsNullOrEmpty(nomeFantasia) && !string.IsNullOrEmpty(bairro)
                        && !string.IsNullOrEmpty(cidade) && !string.IsNullOrEmpty(uf) && !string.IsNullOrEmpty(cnpj) && !string.IsNullOrEmpty(inscricaoEstadual)
                        && !string.IsNullOrEmpty(statusAtivo) && !string.IsNullOrEmpty(numero) && !string.IsNullOrEmpty(cep))
                    {
                        fornecedor.Rua = rua;
                        fornecedor.NomeFantasia = nomeFantasia;
                        fornecedor.Bairro = bairro;
                        fornecedor.Cidade = cidade;
                        fornecedor.Uf = uf;
                        inscricaoSoNumeros = inscricaoEstadual.Replace(".", "");
                        fornecedor.InscricaoEstadual = inscricaoSoNumeros;
                        fornecedor.Complemento = complemento;
                        cepSoNumeros = cep.Replace(".", "").Replace("-", "");
                        fornecedor.Cep = int.Parse(cepSoNumeros);
                        fornecedor.Numero = numero;
                        fornecedor.StatusAtivo = int.Parse(statusAtivo);
                        fornecedor.Cnpj = cnpj;



                    }
                    else
                    {
                        mensagem = "Preencha todos os dados corretamente!";
                    }

                }
                catch (Exception e)
                {
                    mensagem = e.Message;
                }
            }

        }


        public DataTable ListaFornecedor()
        {
            try
            {

                try
                {
                    cmd.CommandText = "Select *from Fornecedor where statusAtivo = 1";

                    cmd.Connection = conexao.AbrirBanco();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dtLista = new DataTable();
                    da.Fill(dtLista);
                    return dtLista;

                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    conexao.FecharBanco();
                }



            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {

                conexao.FecharBanco();
            }
        }
        public DataTable ListaTodosFornecedores()
        {
            try
            {

                try
                {
                    cmd.CommandText = "Select *from Fornecedor";

                    cmd.Connection = conexao.AbrirBanco();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dtLista = new DataTable();
                    da.Fill(dtLista);
                    return dtLista;

                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    conexao.FecharBanco();
                }


            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                conexao.FecharBanco();
            }
        }

        public void AdicionaFornecedor()
        {
            mensagem = "";
            if (mensagem == "")
            {
                try
                {
                    cmd.CommandText = "insert into Fornecedor (cnpj, nomefantasia, inscricaoEstadual, cepfornecedor, Rua, uf,numero, complemento,bairro,cidade, statusAtivo) " +
                        "values(@cnpj, @nomefantasia, @inscricaoEstadual, @cepFornecedor, @rua, @uf , @numero, @complemento, @bairro, @cidade,@statusAtivo)";
                    cmd.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                    cmd.Parameters.AddWithValue("@nomefantasia", fornecedor.NomeFantasia);
                    cmd.Parameters.AddWithValue("@inscricaoEstadual", fornecedor.InscricaoEstadual);
                    cmd.Parameters.AddWithValue("@cepFornecedor", fornecedor.Cep);
                    cmd.Parameters.AddWithValue("@rua", fornecedor.Rua);
                    cmd.Parameters.AddWithValue("@uf", fornecedor.Uf);
                    cmd.Parameters.AddWithValue("@numero", fornecedor.Numero);
                    cmd.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                    cmd.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                    cmd.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                    cmd.Parameters.AddWithValue("@statusAtivo", fornecedor.StatusAtivo);

                    cmd.Connection = conexao.AbrirBanco();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    mensagem = e.Message;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conexao.FecharBanco();
                }
            }
        }

        public void AlterarFornecedor()
        {
            mensagem = "";
            if (mensagem == "")
            {
                try 
                {
                    cmd.CommandText = "update Fornecedor set   cnpj = @cnpj ,nomeFantasia = @nomeFantasia, inscricaoEstadual = @inscricaoEstadual, uf = @uf , numero = @numero, complemento = @complemento, bairro = @bairro,cidade = @cidade, cepFornecedor = @cepFornecedor, statusAtivo = @statusAtivo, rua = @rua where idFornecedor = @idFornecedor";
                    cmd.Parameters.AddWithValue("@idFornecedor", fornecedor.Id);
                    cmd.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                    cmd.Parameters.AddWithValue("@nomefantasia", fornecedor.NomeFantasia);
                    cmd.Parameters.AddWithValue("@inscricaoEstadual", fornecedor.InscricaoEstadual);
                    cmd.Parameters.AddWithValue("@cepFornecedor", fornecedor.Cep);
                    cmd.Parameters.AddWithValue("@rua", fornecedor.Rua);
                    cmd.Parameters.AddWithValue("@uf", fornecedor.Uf);
                    cmd.Parameters.AddWithValue("@numero", fornecedor.Numero);
                    cmd.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                    cmd.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                    cmd.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                    cmd.Parameters.AddWithValue("@statusAtivo", fornecedor.StatusAtivo);

                    cmd.Connection = conexao.AbrirBanco();
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conexao.FecharBanco();
                }

            }
        }

    }
}
