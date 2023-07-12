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
    public class UserMicroService
    {
        private readonly UserMicroServiceRepository userMicroServiceRepository;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMapper mapper;

        public UserMicroService(UserMicroServiceRepository _userMicroServiceRepository, IMapper _mapper)
        {
            mapper = _mapper;
            userMicroServiceRepository = _userMicroServiceRepository;
        }

    }
}