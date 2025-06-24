﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Results;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "list",
      documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class List: IComando
    {
        private readonly HttpClientPet clientPet;

        public List(HttpClientPet clientPet)
        {
            this.clientPet = clientPet;
        }

        public Task<Result> ExecutarAsync()
        {
            return this.ListaDadosPetsDaAPIAsync();
        }

        private async Task<Result> ListaDadosPetsDaAPIAsync()
        {
            try
            {
                IEnumerable<Pet>? pets = await clientPet.ListAsync();               
                return Result.Ok().WithSuccess(new SuccessWithPets(pets,"Listagem de Pet's realizada com sucesso!"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
            }

        }

    }
}
