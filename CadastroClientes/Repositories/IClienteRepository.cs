using CadastroClientes.Models;
using System.Collections.Generic;

namespace CadastroClientes.Repositories
{
	public interface IClienteRepository
	{
		bool Adicionar(ClienteModel cliente);
		bool Alterar(ClienteModel cliente);
		ClienteModel Obter(int id);
		List<ClienteModel> ListarTodos();
	}
}
