using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL.Repositorio;
using Projeto.Entidades;
using System.Data.SqlClient;
using Projeto.Util;

namespace Projeto.DAL.Persistencia
{
    public class UsuarioDAL : Conexao
    {
        public void Cadastrar(Usuario u)
        {
            try
            {
                AbirConexao();
                tr = con.BeginTransaction("cadastrarUsuario");

                string query = "insert into Usuario (nome, login, senha, dataCadastro, ativo) values (@nome, @login, @senha, @dataCadastro, @ativo)";
                cmd = new SqlCommand(query, con, tr);
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@login", u.login);
                cmd.Parameters.AddWithValue("@senha", Criptografia.EncriptarSenha(u.senha));
                cmd.Parameters.AddWithValue("@dataCadastro", u.dataCadastro);
                cmd.Parameters.AddWithValue("@ativo", u.ativo);
                cmd.ExecuteNonQuery();

                tr.Commit();
                FecharConexao();

            }
            catch (Exception e)
            {
                tr.Rollback();
                FecharConexao();
                throw e;
            }
        }

        public Usuario Consultar(string login, string senha)
        {
            AbirConexao();

            string query = "select * from Usuario where login = @login and senha = @senha and ativo = 1";
            cmd = new SqlCommand(query, con, tr);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", Criptografia.EncriptarSenha(senha));
            dr = cmd.ExecuteReader();

            Usuario u = null;

            if (dr.Read())
            {
                u = new Usuario();
                u.idUsuario = (int)dr["idUsuario"];
                u.nome = (string)dr["nome"];
                u.login = (string)dr["login"];
                u.dataCadastro = (DateTime)dr["dataCadastro"];
            }

            FecharConexao();
            return u;
        }
    }
}
