using Dapper.Contrib.Extensions;
using System;

namespace ProductBoundedContext.Data.EntityData
{
    [Table("UnitMeasurement")]
    class UnitMeasurementEntityData
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
