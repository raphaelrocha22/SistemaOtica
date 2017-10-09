using Projeto.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Projeto.Entidades;
using Projeto.Entidades.Enum;

namespace Projeto.DAL.Persistencia
{
    public class ClienteDAL:Conexao
    {
        public void Cadastrar(Cliente c)
        {
            AbirConexao();

            string query = "insert into Cliente (nome, email, dataCadastro, cpf/cnpj, tipoCliente) " +
                "values (@nome, @email, @dataCadastro, @cpf/cnpj, @tipoCliente); SELECT SCOPE_IDENTITY()";
            cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@nome", c.nome);
            cmd.Parameters.AddWithValue("@email", c.email);
            cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
            cmd.Parameters.AddWithValue("@cpf/cnpj", c.cpfCnpj);
            cmd.Parameters.AddWithValue("@tipoCliente", c.tipo.ToString());
            int idCliente = (int)cmd.ExecuteScalar();

            if (c.endereco != null)
            {
                query = "insert into Endereco (rua, numero, complemento, cidade, estado, cep, idCliente) " +
                    "values (@rua, @numero, @complemento, @cidade, @estado, @cep, @idCliente)";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@rua", c.endereco.rua);
                cmd.Parameters.AddWithValue("@numero", c.endereco.numero);
                cmd.Parameters.AddWithValue("@complemento", c.endereco.complemento);
                cmd.Parameters.AddWithValue("@cidade", c.endereco.cidade);
                cmd.Parameters.AddWithValue("@estado", c.endereco.estado);
                cmd.Parameters.AddWithValue("@cep", c.endereco.cep);
                cmd.Parameters.AddWithValue("@idcliente", idCliente);
                cmd.ExecuteNonQuery();
            }

            foreach (var t in c.telefones)
            {
                query = "insert into Telefone (ddd, numero, idCliente) values (@ddd, @numero, @idCliente)";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ddd", t.ddd);
                cmd.Parameters.AddWithValue("@numero", t.numero);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.ExecuteNonQuery();
            }

            FecharConexao();
        }

        public List<Cliente> Consultar(Cliente c)
        {
            AbirConexao();

            string query = "select * from Cliente where idCliente = @idCliente or nome = @nome or email = @email " +
                "or cpf/cnpj = @cpf/cnpj or tipoCliente = @tipoCliente";
            cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@idCliente", c.idCliente);
            cmd.Parameters.AddWithValue("@nome", c.nome);
            cmd.Parameters.AddWithValue("@email", c.email);
            cmd.Parameters.AddWithValue("@cpf/cnpj", c.cpfCnpj);
            cmd.Parameters.AddWithValue("@tipoCliente", c.tipo.ToString());
            dr = cmd.ExecuteReader();

            var lista = new List<Cliente>();

            while (dr.Read())
            {
                var cliente = new Cliente();

                cliente.idCliente = (int)dr["idCliente"];
                cliente.nome = (string)dr["nome"];
                cliente.email = (string)dr["email"];
                cliente.dataCadastro = (DateTime)dr["dataCadastro"];
                cliente.cpfCnpj = (string)dr["cpf/cnpj"];
                cliente.tipo = (TipoCliente)Enum.Parse(typeof(TipoCliente),dr["tipoCliente"].ToString());

                lista.Add(cliente);
            }
            
            FecharConexao();
            return lista;
        }

        public void Atualizar(Cliente c)
        {
            AbirConexao();

            string query = "update Cliente set nome = @nome, email = @email, cpf/cnpj = @cpf/cnpj, tipoCliente = @tipoCliente where idCliente = @idCliente";
            cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@idCliente", c.idCliente);
            cmd.Parameters.AddWithValue("@nome", c.nome);
            cmd.Parameters.AddWithValue("@email", c.email);
            cmd.Parameters.AddWithValue("@cpf/cnpj", c.cpfCnpj);
            cmd.Parameters.AddWithValue("@tipoCliente", c.tipo.ToString());
            cmd.ExecuteNonQuery();

            FecharConexao();
        }
    }
}
