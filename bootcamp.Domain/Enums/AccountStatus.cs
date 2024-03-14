using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Domain.Enums
{
    public enum AccountStatus
    {
        [EnumMember(Value = "new user")]
        user,
        [EnumMember(Value = "new applicant")]
        applicant,
        [EnumMember(Value = "new student")]
        student
    }
}
