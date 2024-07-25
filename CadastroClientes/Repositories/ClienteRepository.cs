using CadastroClientes.Data;
using CadastroClientes.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroClientes.Repositories
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly BancoContext _context;
		public ClienteRepository(BancoContext con)
		{
			_context = con;
		}

		public bool Adicionar(ClienteModel cliente)
		{
			try
			{
				_context.Clientes.Add(cliente);
				_context.SaveChanges();

				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool Alterar(ClienteModel cliente)
		{
			try
			{
				_context.Clientes.Update(cliente);
				_context.SaveChanges();

				return true;
			}
			catch
			{
				return false;
			}
		}
		public ClienteModel Obter(int id)
		{
			try
			{
				return _context.Clientes.FirstOrDefault(x => x.Id == id);
			}
			catch
			{
				return new ClienteModel();
			}
		}
		public List<ClienteModel> ListarTodos()
		{
			try
			{
				return _context.Clientes.Where(x =>x.Ativo == true).ToList();
			}
			catch
			{
				return new List<ClienteModel>();
			}
		}
		public List<ClienteModel> Filtrar(string nome, string documento)
		{
			try
			{
				return _context.Clientes
					.Where(x => x.Ativo == true)
					.Where(c => c.Nome.Contains(nome) || nome == string.Empty)
					.Where(l => l.Documento.Contains(documento) || documento == string.Empty).ToList();
			}
			catch
			{
				return new List<ClienteModel>();
			}
		}
	}
}
