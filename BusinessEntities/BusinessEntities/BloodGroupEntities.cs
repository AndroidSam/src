using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
      [DataContract, Serializable]
    public class BloodGroupEntities
    {
          [Key]
          [DataMember]
          [ScaffoldColumn(false)]
          public Guid BloodGroupID { get; set; }

          [DataMember]
          [Required]
          public string BloodGroupName { get; set; }

          [DataMember]
          public bool Active { get; set; }
    }
}
