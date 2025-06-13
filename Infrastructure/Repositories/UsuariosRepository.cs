using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories
{
    public class UsuariosRepository : BaseRepository<Usuarios>, IUsuariosRepository
    {
        public UsuariosRepository(ContexDB context) : base(context)
        {
        }

        public async Task AddPrAsync(Usuarios entity)
        {
            await _context.Database.ExecuteSqlRawAsync("CALL AgregarUsuario({0}, {1}, {2})", entity.Nombre, entity.FechaNacimiento, entity.Sexo);
        }

        public async Task DeleteUserAsync(int id)
        {
           await _context.Database.ExecuteSqlRawAsync("CALL EliminarUsuario({0})", id);
        }

        public async Task<List<Usuarios>> GetUsersPrAsync()
        {
            return await _dbSet.FromSqlRaw("CALL ConsultarUsuarios()").ToListAsync();
        }

        public async Task UpdateUserPrAsync(Usuarios usuarios)
        {
           await _context.Database.ExecuteSqlRawAsync("CALL ModificarUsuario({0}, {1}, {2}, {3})", usuarios.Id, usuarios.Nombre, usuarios.FechaNacimiento, usuarios.Sexo);
        }
    }
}
