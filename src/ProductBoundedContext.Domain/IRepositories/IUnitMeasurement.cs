using ProductBoundedContext.Domain.EntityDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductBoundedContext.Domain.IRepositories
{
    interface IUnitMeasurement
    {
        Task<UnitMeasurementEntityDomain> CreateUnitMeasurementAsync(UnitMeasurementEntityDomain unitMeasurement);

        Task<bool> UpdateUnitMeasurementAsync(UnitMeasurementEntityDomain unitMeasurement);

        Task<bool> RemoveUnitMeasurementAsync(string id);

        Task<List<UnitMeasurementEntityDomain>> GetAllUnitMeasurementAsync();

        Task<UnitMeasurementEntityDomain> GetUnitMeasurementAsync(string id);
    }
}
