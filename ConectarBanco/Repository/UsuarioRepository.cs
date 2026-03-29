using ConectarBanco.Models;
using ConectarBanco.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConectarBanco.Repository
{
    public class UsuarioRepository : IUsuaryRepository
    {

        private readonly string _conexaoMySQL;

        public UsuarioRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Usuario usuario)
        {
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE usuario SET nomeUsu=@nomeUsu, cargo=@Cargo," +
                                                    "DataNasc=@DataNasc WHERE IdUsu=@IdUsu;", conexao);

                cmd.Parameters.Add("@nomeUsu", MySqlDbType.VarChar).Value = usuario.nomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@IdUsu", MySqlDbType.VarChar).Value = usuario.IdUsu;

                cmd.ExecuteNonQuery();
                conexao.Close();


            }
        }

        public void Cadastrar(Usuario usuario)
        {
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into usuario(nomeUsu, cargo, DataNasc, CEP, Estado, Cidade, Bairro, Logradouro, Complemento, Numero) " +
                                                   " values (@nomeUsu, @Cargo, @DataNasc, @CEP, @Estado, @Cidade, @Bairro, @Logradouro, @Complemento, @Numero)", conexao);

                cmd.Parameters.Add("@nomeUsu", MySqlDbType.VarChar).Value = usuario.nomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.DateTime).Value = usuario.DataNasc;
                cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = usuario.CEP;
                cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = usuario.Estado;
                cmd.Parameters.Add("@Bairro", MySqlDbType.VarChar).Value = usuario.Bairro;
                cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = usuario.Cidade;
                cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = usuario.Logradouro;
                cmd.Parameters.Add("@Complemento", MySqlDbType.VarChar).Value = usuario.Complemento;
                cmd.Parameters.Add("@Numero", MySqlDbType.VarChar).Value = usuario.Numero;




                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM usuario WHERE IdUsu = @IdUsu", conexao);
                cmd.Parameters.AddWithValue("@IdUsu", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            List<Usuario> UsuarioList = new List<Usuario>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from usuario", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    UsuarioList.Add(
                        new Usuario
                        {
                            IdUsu = Convert.ToInt32(dr["IdUsu"]),
                            nomeUsu = (string)dr["nomeUsu"],
                            Cargo = (string)dr["Cargo"],
                            DataNasc = Convert.ToDateTime(dr["DataNasc"]),
                            CEP = (string)dr["CEP"],
                            Estado = (string)dr["Estado"],
                            Cidade = (string)dr["Cidade"],
                            Bairro = (string)dr["Bairro"],
                            Logradouro = (string)dr["Logradouro"],
                            Complemento = (string)dr["Complemento"],
                            Numero = (string)dr["Numero"],



                        });
                }
                return UsuarioList;
            }
        }

        public Usuario ObterUsuario(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from usuario " +
                                                    "where IdUsu=@IdUsu", conexao);

                cmd.Parameters.AddWithValue("@IdUsu", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Usuario usuario = new Usuario();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    usuario.IdUsu = Convert.ToInt32(dr["IdUsu"]);
                    usuario.nomeUsu = (string)dr["nomeUsu"];
                    usuario.Cargo = (string)dr["Cargo"];
                    usuario.DataNasc = Convert.ToDateTime(dr["DataNasc"]);
                }

                return usuario;

            }
        }


    }
}
