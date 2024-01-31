using AutoMapper;

namespace Api.Services
{
    public abstract class BaseService
    {
        private readonly IMapper _mapper;   
        public BaseService(IMapper mapper)
        { 
            _mapper = mapper;
        }

        public T MapToDot<T>(object source)
        { 
            return _mapper.Map<T>(source);  
        }
    }
}
