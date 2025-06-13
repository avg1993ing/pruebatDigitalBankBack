using Core.DTO;

namespace Core.Interfaces.Services
{
    public interface IUsuariosService
    {
        Task Add(UsuariosDto book);
        Task Update(UsuariosDto book);
        Task<List<UsuariosDto>> GetAll();
        Task<UsuariosDto> GetById(int id);
        Task DeleteUserAsync(int id);
    }
}
