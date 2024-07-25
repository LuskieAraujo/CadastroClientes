using CadastroClientes.Models;
using System.Collections.Generic;

namespace CadastroClientes.Repositories
{
	public interface IClienteRepository
	{
		bool Adicionar(ClienteModel cliente);
		bool Alterar(ClienteModel cliente);
		void Excluir(int id);
		ClienteModel Obter(int id);
		List<ClienteModel> ListarTodos();
		List<ClienteModel> Filtrar(string nome, string documento);
	}
}
