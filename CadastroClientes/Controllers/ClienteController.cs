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

		public IActionResult Clientes()
		{
			return View(_repository.ListarTodos());
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
		[HttpDelete]
		public IActionResult Excluir()
		{
			return View();
		}
	}
}
