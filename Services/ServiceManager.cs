using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {   //?? Lazy loading yapabilmek için private IHouseService alıp, newlendikten sonra public olarak erişime açılır

        private readonly Lazy<IHouseService> _houseService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper, 
            IConfiguration configuration, UserManager<User> userManager, IHouseLinks houseLinks)
        {
            _houseService = new Lazy<IHouseService>(() => new HouseManager(repositoryManager, logger, mapper, houseLinks));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(logger, mapper, userManager, configuration));

        }
        public IHouseService HouseService => _houseService.Value; //controller buraya erişebilsin

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
