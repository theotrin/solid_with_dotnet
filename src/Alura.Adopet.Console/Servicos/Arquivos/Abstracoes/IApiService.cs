using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos.Abstracoes
{
    public interface IApiService
    {
        Task CreateAsync(Pet pet);
        Task<IEnumerable<Pet>?> ListAsync();
    }
}