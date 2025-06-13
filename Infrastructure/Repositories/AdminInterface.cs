using Core.Interfaces.Repository;
using Persistence.DataContext;

namespace Infrastructure.Repositories
{
    public class AdminInterface : IAdminInterface
    {
        public ContexDB _context;
        public AdminInterface(ContexDB context)
        {
            _context = context;
        }
        public IUsuariosRepository _usuariosRepository;
        public IUsuariosRepository usuariosRepository => _usuariosRepository ?? new UsuariosRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
