﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDeClienteCRUD
{
    public partial class FrmCadastroDeClientes : Form
    {
        string connectionString = @"Server=DESKTOP-7ETD8RD;Database=BDCADASTRO;Trusted_Connection=True;";
        bool novo;
        public FrmCadastroDeClientes()
        {
            InitializeComponent();
        }
        private void FrmCadastroDeClientes_Load(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCep.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUf.Enabled = false;
            mskTelefone.Enabled = false;
        }



        private void tsbNovo_Click_1(object sender, EventArgs e)
        {
            tsbNovo.Enabled = false;
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = false;
            tstId.Enabled = false;
            tsbBuscar.Enabled = false;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            mskCep.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUf.Enabled = true;
            mskTelefone.Enabled = true;

            txtNome.Focus();
            novo = true;
        }

        private void tsbSalvar_Click_1(object sender, EventArgs e)
        {
            if (novo == true)
            {
                string sql = $"INSERT INTO BDCADASTRO.dbo.CLIENTE(NOME, ENDERECO, CEP, BAIRRO, CIDADE, UF, TELEFONE) " +
                $"VALUES('{txtNome.Text}', '{txtEndereco.Text}', '{mskCep.Text}', '{txtBairro.Text}', '{txtCidade.Text}', '{txtUf.Text}', '{mskTelefone.Text}')";

                //   ERRO
                //   $"(INSERT INTO BDCADASTRO.dbo.CLIENTE(NOME, ENDERECO, CEP, BAIRRO, CIDADE, UF, TELEFONE) " +
                //   $"VALUES('{txtNome.Text}', '{txtEndereco.Text}', {mskCep.Text}, '{txtBairro.Text}', '{txtCidade.Text}', '{txtUf.Text}', {mskTelefone.Text})");


                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Cadastro realizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                string sql = ($"(UPDATE CLIENTE SET NOME='{txtNome.Text}',ENDERECO='{txtEndereco.Text}'" +
                    $",CEP='{mskCep.Text}',BAIRRO='{txtBairro.Text}',CIDADE='{txtCidade.Text}',UF='{txtUf.Text}',TELEFONE='{mskTelefone.Text}')");

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Cadastro atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCep.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUf.Enabled = false;
            mskTelefone.Enabled = false;
            txtId.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            mskCep.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
            mskTelefone.Text = "";
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCep.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUf.Enabled = false;
            mskTelefone.Enabled = false;
            txtId.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            mskCep.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
            mskTelefone.Text = "";
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM CLIENTE WHERE ID=" + txtId.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCep.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUf.Enabled = false;
            mskTelefone.Enabled = false;
            txtId.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            mskCep.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
            mskTelefone.Text = "";
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM CLIENTE WHERE ID= " + tstId.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            if (tstId.Text == "")
            {
                MessageBox.Show("Não foi inserido nenhum Id para a busca!S");
            }
            else
            {
                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tsbNovo.Enabled = false;
                        tsbSalvar.Enabled = true;
                        tsbCancelar.Enabled = true;
                        tsbExcluir.Enabled = true;
                        tstId.Enabled = false;
                        tsbBuscar.Enabled = false;
                        txtNome.Enabled = true;
                        txtEndereco.Enabled = true;
                        mskCep.Enabled = true;
                        txtBairro.Enabled = true;
                        txtCidade.Enabled = true;
                        txtUf.Enabled = true;
                        mskTelefone.Enabled = true;
                        txtId.Text = reader[0].ToString();
                        txtNome.Text = reader[1].ToString();
                        txtEndereco.Text = reader[2].ToString();
                        mskCep.Text = reader[3].ToString();
                        txtBairro.Text = reader[4].ToString();
                        txtCidade.Text = reader[5].ToString();
                        txtUf.Text = reader[6].ToString();
                        mskTelefone.Text = reader[7].ToString();
                        novo = false;
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro encontrado com o Id informado!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            tstId.Text = "";
        }
    }
}
