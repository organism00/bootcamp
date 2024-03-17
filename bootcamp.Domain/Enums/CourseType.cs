using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bootcamp.Domain.Enums
{
    public enum CourseType
    {
        //[JsonConverter(typeof(CourseType))]
        [EnumMember(Value = "FrontEnd")]
        FrontEnd,
        [EnumMember(Value = "BackEnd")]
        BackEnd,
             [EnumMember(Value = "FrontEndAndBackEnd")]
        FrontEndAndBackEnd

    }
}
