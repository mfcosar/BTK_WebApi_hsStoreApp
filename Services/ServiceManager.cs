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
    {
        private readonly Lazy<IHouseService> _houseService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _houseService = new Lazy<IHouseService>(() => new HouseManager(repositoryManager));
        }
        public IHouseService HouseService => _houseService.Value;
    }
}
