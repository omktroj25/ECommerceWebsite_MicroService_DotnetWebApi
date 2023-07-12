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
    public class OrderMicroService
    {
        private readonly OrderMicroServiceRepository orderMicroServiceRepository;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMapper mapper;

        public OrderMicroService(OrderMicroServiceRepository _orderMicroServiceRepository, IMapper _mapper)
        {
            mapper = _mapper;
            orderMicroServiceRepository = _orderMicroServiceRepository;
        }
        
        
    }
}