using ConectarBanco.Models;

namespace ConectarBanco.Repository.Contract
{
    public interface IEnderecoRepositorio
    {
        IEnumerable<Endereco> ObterTodosEnderecos();

        void Cadastrar(Endereco endereco);

        void Atualizar(Endereco endereco);

        Endereco ObterEndereco(int Id);

        void Excluir(int Id);
    }
}
