using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Atributos;
using FluentResults;
using Alura.Adopet.Console.Results;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import:IComando
    {
        private readonly HttpClientPet clientPet;

        private readonly LeitorDeArquivoCsv leitor;

        public Import(HttpClientPet clientPet, LeitorDeArquivoCsv leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {                       
                   await clientPet.CreateAsync(pet);               
                }
                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet,"Importação Realizada com Sucesso!"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
            
            
            
            
        }
    }
}
