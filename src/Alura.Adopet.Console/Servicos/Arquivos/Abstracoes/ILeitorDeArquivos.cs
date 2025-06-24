using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos.Abstracoes
{
    public interface ILeitorDeArquivos
    {
        IEnumerable<Pet> RealizaLeitura();
    }
}