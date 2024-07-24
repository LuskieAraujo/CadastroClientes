using System;

namespace CadastroClientes.Models
{
	public class ClienteModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Documento { get; set; }
		public string Telefone { get; set; }
		public int Tipo { get; set; }
		public DateTime DataCadastro { get; set; }
		public bool Ativo {  get; set; }
	}
}
