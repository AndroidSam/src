using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    [DataContract, Serializable]
    public class EmployeeDesigEntities
    {
        [Key]
        [DataMember]
        [ScaffoldColumn(false)]
        public Guid EmployeeDesigId { get; set; }

        [DataMember]
        public string EmployeeDesigName { get; set; }

        [DataMember]
        public bool Active { get; set; } 

    }
}
