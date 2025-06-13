using AutoMapper;
using Core.Interfaces.Repository;

namespace Core.Services
{
    public class BaseService
    {
        public IAdminInterface _adminInterface;
        public IMapper _mapper;
        public BaseService(IAdminInterface adminInterface, IMapper mapper)
        {
            _adminInterface = adminInterface;
            _mapper = mapper;
        }
    }
}
