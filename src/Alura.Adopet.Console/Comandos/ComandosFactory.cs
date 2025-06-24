using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if ((argumentos is null) || (argumentos.Length == 0))
        {
            return null;
        }
        var comando = argumentos[0];
        switch (comando)
        {
            case "import":
                var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivos = new LeitorDeArquivoCsv(argumentos[1]);
                return new Import(httpClientPet, leitorDeArquivos);

            case "list":
                var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new List(httpClientPetList);

            case "show":
                var leitorDeArquivosShow = new LeitorDeArquivoCsv(argumentos[1]);
                return new Show(leitorDeArquivosShow);

            case "help":
                var comandoASerExibido = argumentos.Length==2? argumentos[1] : null;
                return new Help(comandoASerExibido);

            default: return null;
        }           
    }
}
