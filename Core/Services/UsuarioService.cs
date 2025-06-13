using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class UsuarioService : BaseService, IUsuariosService
    {
        public UsuarioService(IAdminInterface adminInterface, IMapper mapper) : base(adminInterface, mapper)
        {
        }

        public async Task Add(UsuariosDto Usuarios)
        {
            try
            {
                await _adminInterface.usuariosRepository.AddPrAsync(_mapper.Map<Usuarios>(Usuarios));
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "UsuarioService";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }

        public async  Task DeleteUserAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    LogException logException = new LogException();
                    logException.Message = "ID inválido.";
                    logException.Name = "UsuarioService";
                    throw new BagRequestBusinessException(logException);
                }
                var usuario = _mapper.Map<UsuariosDto>(await _adminInterface.usuariosRepository.GetByIdAsync(id));
                if (usuario == null)
                {
                    LogException logException = new LogException();
                    logException.Message = "Usuario no encontrado.";
                    logException.Name = "UsuarioService";
                    throw new NotFoundException(logException);
                }
                await _adminInterface.usuariosRepository.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "UsuarioService";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }

        public async Task<List<UsuariosDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<UsuariosDto>>(await _adminInterface.usuariosRepository.GetUsersPrAsync());
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "UsuarioService";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }

        public async Task<UsuariosDto> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    LogException logException = new LogException();
                    logException.Message = "ID inválido.";
                    logException.Name = "UsuarioService";
                    throw new BagRequestBusinessException(logException);
                }
                var usuario = _mapper.Map<UsuariosDto>(await _adminInterface.usuariosRepository.GetByIdAsync(id));
                if (usuario == null)
                {
                    LogException logException = new LogException();
                    logException.Message = "Usuario no encontrado.";
                    logException.Name = "UsuarioService";
                    throw new NotFoundException(logException);
                }
                return usuario;
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "UsuarioService";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }

        public async Task Update(UsuariosDto Usuarios)
        {
            try
            {
                var usuario = _mapper.Map<UsuariosDto>(await _adminInterface.usuariosRepository.GetByIdAsync(Usuarios.Id));
                if (usuario == null)
                {
                    LogException logException = new LogException();
                    logException.Message = "Usuario no encontrado.";
                    logException.Name = "UsuarioService";
                    throw new NotFoundException(logException);
                }
                await _adminInterface.usuariosRepository.UpdateUserPrAsync(_mapper.Map<Usuarios>(Usuarios));
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "UsuarioService";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }
    }
}
