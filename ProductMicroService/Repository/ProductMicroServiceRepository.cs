using Entity.Data;
using Entity.Dto;
using Contract.IRepository;
using Contract.IService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Entity.Model;
using NLog;

namespace Repository
{
    public class ProductMicroServiceRepository
    {
        private ApiDbContext context;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private IMapper mapper;

        public ProductMicroServiceRepository(ApiDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

    }
}