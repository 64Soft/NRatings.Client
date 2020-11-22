using System;
using System.ComponentModel;

namespace NRatings.Client.Domain
{
    [Serializable]
    public enum CarMappingMethod
    {
        [Description("By Number And Name")]
        NUMBER_AND_NAME,
        [Description("By Number Only")]
        NUMBER,
        [Description("By Name Only")]
        NAME
    };

    public enum SessionType
    {
        QUALIFYING,
        RACE
    }
}
