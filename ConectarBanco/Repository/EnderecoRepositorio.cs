using ConectarBanco.Models;
using ConectarBanco.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConectarBanco.Repository
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly string _conexaoMySQL;

        public EnderecoRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Endereco endereco)
        {
            try
            {
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "insert into Endereco(CEP, Estado, Cidade, Bairro, " +
                        "Logradouro, Complemento, Numero) " +
                        "values (@CEP, @Estado, @Cidade, @Bairro, @Logradouro, @Complemento, @Numero)",
                        conexao); // @ = PARAMETRO

                    cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = endereco.CEP;
                    cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = endereco.Estado;
                    cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = endereco.Cidade;
                    cmd.Parameters.Add("@Bairro", MySqlDbType.VarChar).Value = endereco.Bairro;
                    cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = endereco.Logradouro;
                    cmd.Parameters.Add("@Complemento", MySqlDbType.VarChar).Value = endereco.Complemento;
                    cmd.Parameters.Add("@numero", MySqlDbType.VarChar).Value = endereco.Numero;

                    cmd.ExecuteNonQuery();

                    conexao.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro no banco em cadastro cliente" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação em cadastro cliente" + ex.Message);
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Endereco ObterEndereco(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> ObterTodosEnderecos()
        {
            List<Endereco> EnderecoList = new List<Endereco>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from endereco", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    EnderecoList.Add(
                        new Endereco
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            CEP = (string)dr["CEP"],
                            Estado = (string)dr["Estado"],
                            Cidade = (string)dr["Cidade"],
                            Bairro = (string)dr["Bairro"],
                            Logradouro = (string)dr["Logradouro"],
                            Complemento = (string)dr["Complemento"],
                            Numero = (string)dr["Numero"],



                        });
                }
                return EnderecoList;
            }
        }
    }
}
