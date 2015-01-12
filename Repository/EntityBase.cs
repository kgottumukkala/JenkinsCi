using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Repository
{
    [DataContract]
    public abstract class EntityBase : IObjectState
    {
        [NotMapped]
        
        public ObjectState ObjectState { get; set; } //TODO: Renamed since a possible coflict with State entity column
    }
}