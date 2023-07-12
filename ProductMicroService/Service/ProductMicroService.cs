using Entity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository;
using AutoMapper;
using Contract.IRepository;
using Contract.IService;
using Entity.Dto;
using Exception;
using Entity.Model;
using NLog;

namespace Service
{
    public class ProductMicroService
    {
        private readonly ProductMicroServiceRepository productMicroServiceRepository;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMapper mapper;

        public ProductMicroService(ProductMicroServiceRepository _productMicroServiceRepository, IMapper _mapper)
        {
            mapper = _mapper;
            productMicroServiceRepository = _productMicroServiceRepository;
        }

    }
}