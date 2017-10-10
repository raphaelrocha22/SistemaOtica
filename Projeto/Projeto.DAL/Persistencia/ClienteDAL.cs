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
    public class ClienteDAL : Conexao
    {
        public void Cadastrar(Cliente c)
        {
            try
            {
                AbirConexao();
                tr = con.BeginTransaction("cadastrarCliente");

                string query = "insert into Cliente (nome, email, dataCadastro, cpfCnpj, tipoCliente) " +
                    "values (@nome, @email, @dataCadastro, @cpfCnpj, @tipoCliente) SELECT SCOPE_IDENTITY()";
                cmd = new SqlCommand(query, con, tr);

                cmd.Parameters.AddWithValue("@nome", c.nome);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@cpfCnpj", c.cpfCnpj);
                cmd.Parameters.AddWithValue("@tipoCliente", c.tipoCliente.ToString());
                int idCliente = Convert.ToInt32(cmd.ExecuteScalar());

                if (c.endereco != null)
                {
                    query = "insert into Endereco (rua, numero, complemento, bairro, cidade, estado, cep, idCliente) " +
                        "values (@rua, @numero, @complemento, @bairro, @cidade, @estado, @cep, @idCliente)";
                    cmd = new SqlCommand(query, con, tr);

                    cmd.Parameters.AddWithValue("@rua", c.endereco.rua);
                    cmd.Parameters.AddWithValue("@numero", c.endereco.numero);
                    cmd.Parameters.AddWithValue("@complemento", c.endereco.complemento);
                    cmd.Parameters.AddWithValue("@bairro", c.endereco.bairro);
                    cmd.Parameters.AddWithValue("@cidade", c.endereco.cidade);
                    cmd.Parameters.AddWithValue("@estado", c.endereco.estado);
                    cmd.Parameters.AddWithValue("@cep", c.endereco.cep);
                    cmd.Parameters.AddWithValue("@idcliente", idCliente);
                    cmd.ExecuteNonQuery();
                }

                if (c.telefones != null)
                {
                    foreach (var t in c.telefones)
                    {
                        query = "insert into Telefone (ddd, numero, idCliente) values (@ddd, @numero, @idCliente)";
                        cmd = new SqlCommand(query, con, tr);

                        cmd.Parameters.AddWithValue("@ddd", t.ddd);
                        cmd.Parameters.AddWithValue("@numero", t.numero);
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);
                        cmd.ExecuteNonQuery();
                    }
                }

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

        public List<Cliente> Consultar(Cliente cliente)
        {
            AbirConexao();

            string query = "select c.*, e.* from Cliente c inner join Endereco e on c.idCliente = e.idCliente ";
            
            if (cliente.idCliente != 0)
                query += "where idCliente = @idCliente";
                
            if (cliente.nome != null)
                query += "where c.nome = @nome";
                
            if (cliente.email != null)
                query += "where c.email = @email";
                
            if (cliente.cpfCnpj != null)
                query += "where c.cpfCnpj = @cpfCnpj";
                
            if (cliente.endereco.bairro != null)
                query += "where e.bairro = @bairro";
                
            
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@email", cliente.email);
            cmd.Parameters.AddWithValue("@cpfCnpj", cliente.cpfCnpj);
            cmd.Parameters.AddWithValue("@bairro", cliente.endereco.bairro);
            dr = cmd.ExecuteReader();

            var lista = new List<Cliente>();

            while (dr.Read())
            {
                var c = new Cliente();
                c.endereco = new Endereco();
                c.telefones = new List<Telefone>();

                c.idCliente = (int)dr["idCliente"];
                c.nome = (string)dr["nome"];
                c.email = (string)dr["email"];
                c.dataCadastro = (DateTime)dr["dataCadastro"];
                c.cpfCnpj = (string)dr["cpfCnpj"];
                c.tipoCliente = (TipoCliente)Enum.Parse(typeof(TipoCliente), dr["tipoCliente"].ToString());
                c.endereco.idEndereco = (int)dr["idEndereco"];
                c.endereco.rua = (string)dr["rua"];
                c.endereco.numero = (string)dr["numero"];
                c.endereco.bairro = (string)dr["bairro"];
                c.endereco.cidade = (string)dr["cidade"];
                c.endereco.estado = (string)dr["estado"];
                c.endereco.cep = (string)dr["cep"];

                dr.Dispose();
                query = "select * from Telefone where idCliente = @idCliente";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idCliente", c.idCliente);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var t = new Telefone();
                    t.idTelefone = (int)dr["idTelefone"];
                    t.ddd = (int)dr["ddd"];
                    t.numero = (int)dr["numero"];

                    c.telefones.Add(t);
                }

                lista.Add(c);
            }
            FecharConexao();
            return lista;
        }

        public void Atualizar(Cliente c)
        {
            try
            {
                AbirConexao();
                tr = con.BeginTransaction("atualizarCliente");

                string query = "update Cliente set nome = @nome, email = @email, cpfCnpj = @cpfCnpj, tipoCliente = @tipoCliente where idCliente = @idCliente";
                cmd = new SqlCommand(query, con, tr);

                cmd.Parameters.AddWithValue("@idCliente", c.idCliente);
                cmd.Parameters.AddWithValue("@nome", c.nome);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@cpfCnpj", c.cpfCnpj);
                cmd.Parameters.AddWithValue("@tipoCliente", c.tipoCliente.ToString());
                cmd.ExecuteNonQuery();


                query = "update Endereco set rua = @rua, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep " +
                    "where idEndereco = @idEndereco and idCliente = @idCliente";
                cmd = new SqlCommand(query, con, tr);

                cmd.Parameters.AddWithValue("@idCliente", c.idCliente);
                cmd.Parameters.AddWithValue("@rua", c.endereco.rua);
                cmd.Parameters.AddWithValue("@numero", c.endereco.numero);
                cmd.Parameters.AddWithValue("@complemento", c.endereco.complemento);
                cmd.Parameters.AddWithValue("@bairro", c.endereco.bairro);
                cmd.Parameters.AddWithValue("@cidade", c.endereco.cidade);
                cmd.Parameters.AddWithValue("@estado", c.endereco.estado);
                cmd.Parameters.AddWithValue("@cep", c.endereco.cep);
                cmd.Parameters.AddWithValue("@idEndereco", c.endereco.idEndereco);
                cmd.ExecuteNonQuery();


                foreach (var t in c.telefones)
                {
                    query = "update Telefone set ddd = @ddd, numero = @numero where idTelefone = @idTelefone and idCliente = @idCliente";
                    cmd = new SqlCommand(query, con, tr);

                    cmd.Parameters.AddWithValue("@idTelefone", t.idTelefone);
                    cmd.Parameters.AddWithValue("@ddd", t.ddd);
                    cmd.Parameters.AddWithValue("@numero", t.numero);
                    cmd.Parameters.AddWithValue("@idCliente", c.idCliente);
                    cmd.ExecuteNonQuery();
                }

                FecharConexao();
            }
            catch (Exception e)
            {
                tr.Rollback();
                FecharConexao();
                throw new Exception (e.Message);
            }
        }
    }
}
