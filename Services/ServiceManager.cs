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
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {   //?? Lazy loading yapabilmek için private IHouseService alıp, newlendikten sonra public olarak erişime açılır

        private readonly Lazy<IHouseService> _houseService;
        private readonly Lazy<IAuthenticationService> _authencationService;
        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IConfiguration configuration,
            UserManager<User> userManager, IMapper mapper, IHouseLinks houseLinks)
        {
            _houseService = new Lazy<IHouseService>(() => new HouseManager(repositoryManager, logger, mapper, houseLinks));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager, mapper));
            _authencationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger, mapper, userManager, configuration));
        }
        public IHouseService HouseService => _houseService.Value; //controller buraya erişebilsin
        public ICategoryService CategoryService => _categoryService.Value;
        public IAuthenticationService AuthenticationService => _authencationService.Value;
    }
}
