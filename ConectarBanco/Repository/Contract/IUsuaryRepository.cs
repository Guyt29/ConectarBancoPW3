using ConectarBanco.Models;

namespace ConectarBanco.Repository.Contract
{
    public interface IUsuaryRepository
    {
        //CRUD
        IEnumerable<Usuario> ObterTodosUsuarios();

        void Cadastrar (Usuario usuario);

        void Atualizar(Usuario usuario);

        Usuario ObterUsuario(int Id);

        void Excluir(int Id);
    }
}
