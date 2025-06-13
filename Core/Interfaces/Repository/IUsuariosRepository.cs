using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IUsuariosRepository : IBaseRepository<Usuarios>
    {
        Task AddPrAsync(Usuarios entity);
        Task<List<Usuarios>> GetUsersPrAsync();
        Task UpdateUserPrAsync(Usuarios usuarios);
        Task DeleteUserAsync(int id);
    }
}
