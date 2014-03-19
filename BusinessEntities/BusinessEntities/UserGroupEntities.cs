using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
namespace BusinessEntities
{
    [DataContract, Serializable]
    public class UserGroupEntities
    {
        [Key]
        [DataMember] 
        [ScaffoldColumn(false)]
        public Guid UserGroupId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "UserGroup Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}'s length should be between {2} and {1}...! ")]
        public string UserGroupName { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
