
using System.Text.Json;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class LeitorDeArquivosJson : ILeitorDeArquivos
    {
        private string caminhoArquivo;

        public LeitorDeArquivosJson(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public IEnumerable<Pet> RealizaLeitura()
        {
            using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read); //abri o aquivo e transformei em um amontoado de bytes
            return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream)??Enumerable.Empty<Pet>(); //transformei o amontoado de bytes em um json e dpois em uma lista de pets
        }
    }
}