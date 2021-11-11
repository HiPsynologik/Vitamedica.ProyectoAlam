using System.Runtime.Serialization;

namespace Vitamedica.ProyectoAlam.Shared.Models
{
    public enum TipoParametro
    {
        [EnumMember]
        Int,
        [EnumMember]
        DateTime,
        [EnumMember]
        String,
        [EnumMember]
        Bool,
        [EnumMember]
        Decimal,
        [EnumMember]
        Double,
        [EnumMember]
        Long
    }
}