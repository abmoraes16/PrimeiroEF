using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeiroEF.Dados;
using PrimeiroEF.Models;

namespace PrimeiroEF.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController:Controller
    {
        Cliente cliente = new Cliente();
        readonly ClienteContexto contexto; //Somente leitura

        public ClienteController(ClienteContexto contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Cliente> Listar(){
            return contexto.ClienteBase.ToList();
        }

        [HttpGet("{id}")]
        public Cliente Listar(int id){
            Console.WriteLine("Listar");
            return contexto.ClienteBase.ToList().Where(cli=>cli.Id==id).FirstOrDefault();
        }

        [HttpPost]
        public void Cadastrar([FromBody]Cliente cli){
            Console.WriteLine("Cadastrar");
            contexto.ClienteBase.Add(cli);
            contexto.SaveChanges();
        }
    }
}