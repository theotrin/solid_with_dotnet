using Alura.Adopet.Console.Servicos.Arquivos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class LeitorDeArquivosFactory
    {
        public static ILeitorDeArquivos? CreatePetFrom(string caminhoArquivo)
        {
            var extensao = Path.GetExtension(caminhoArquivo);
            switch (extensao)
        {
            case ".csv":
                return new LeitorDeArquivoCsv(caminhoArquivo);
            case ".json":
                return new LeitorDeArquivosJson (caminhoArquivo);
            default: return null; 
        }  
        }
    }
}