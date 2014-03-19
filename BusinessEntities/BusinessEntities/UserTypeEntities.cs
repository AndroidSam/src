using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace BusinessEntities
{
    [DataContract,Serializable]
    public class UserTypeEntities
    {
        [Key]
        [DataMember]
        [ScaffoldColumn(false)]
        public Guid UserTypeId { get; set; }

        [DataMember] 
        [Required(ErrorMessage = "User Type Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "length should be between {2} and {1}...! ")]
        public string UserTypeName { get; set; }

        [DataMember]
        public bool Active { get; set; }

    }
}
