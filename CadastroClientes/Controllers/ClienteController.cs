using CadastroClientes.Models;
using CadastroClientes.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroClientes.Controllers
{
	public class ClienteController : Controller
	{
		private readonly IClienteRepository _repository;
		public ClienteController(IClienteRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Clientes(string nome = "", string documento = "")
		{
			return nome != "" || documento != ""
				? View(_repository.ListarTodos())
				: View(_repository.Filtrar(nome, documento));
		}
		public IActionResult Cliente(int id)
		{
			return id == 0
				? View()
				: View(_repository.Obter(id));
		}
		[HttpPost]
		public IActionResult Salvar(ClienteModel cliente)
		{
			bool retorno;
			if(cliente.Id == 0)
			{
				cliente.Ativo = true;
				cliente.DataCadastro = DateTime.Today;
				retorno = _repository.Adicionar(cliente);
			}
			else
			{
				retorno = _repository.Alterar(cliente);
			}

			return RedirectToAction("Clientes");
		}
		[HttpPost]
		public IActionResult Excluir(int id)
		{
			ClienteModel cliente = _repository.Obter(id);
			cliente.Ativo = false;

			return RedirectToAction("Clientes");
		}
	}
}
