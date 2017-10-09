using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL.Repositorio;
using Projeto.Entidades;
using System.Data.SqlClient;

namespace Projeto.DAL.Persistencia
{
    public class UsuarioDAL : Conexao
    {
        public void Cadastrar(Usuario u)
        {
            AbirConexao();

            string query = "insert into Usuario (nome, login, senha, dataCadastro, ativo) values (@nome, @login, @senha, @dataCadastro, @ativo)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nome", u.nome);
            cmd.Parameters.AddWithValue("@login", u.login);
            cmd.Parameters.AddWithValue("@senha", u.senha);
            cmd.Parameters.AddWithValue("@dataCadastro", u.dataCadastro);
            cmd.Parameters.AddWithValue("@ativo", u.ativo);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

        public Usuario Consultar(string login, string senha)
        {
            AbirConexao();

            string query = "select * from Usuario where login = @login and senha = @senha and ativo = 1";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            Usuario u = null;

            if (dr.Read())
            {
                u = new Usuario();
                u.idUsuario = (int)dr["idUsuario"];
                u.nome = (string)dr["nome"];
                u.login = (string)dr["login"];
                u.senha = (string)dr["senha"];
                u.dataCadastro = (DateTime)dr["dataCadastro"];
            }

            FecharConexao();
            return u;
        }
    }
}
