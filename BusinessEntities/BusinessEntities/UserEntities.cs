using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    [DataContract, Serializable]
    public class UserEntities
    {
        [Key]
        [DataMember][ScaffoldColumn(false)]
        public Guid UserId { get; set; }

        [DataMember]
        public int? EmployeeId { get; set; }

        [DataMember] 
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}'s length should be between {2} and {1}...! ")]
        public string Username { get;set;}

        [DataMember] 
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}'s length should be between {2} and {1}...! ")]
        public string Password {get;set;}

        [DataMember]
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter valid email")]
        public string EmailAddress { get; set; }

        [DataMember]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}'s length should be between {2} and {1}...! ")]
        public string FirstName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}'s length should be between {2} and {1}...! ")]
        public string LastName { get; set; }

        [DataMember]        
        public DateTime? DOB { get; set; }
        
        [DataMember]
        public DateTime? DOJ { get; set; }

        [DataMember] 
        public string PFNumber { get; set; }

        [DataMember]
        [Required]
        [RegularExpression(@"[0-9]", ErrorMessage = "Please valid number")]
        public string ContactNumber { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public UserGroupEntities UserGroupEntity { get; set; }

        [DataMember]
        public UserTypeEntities UserTypeEntity { get; set; }

        [DataMember]
        public BloodGroupEntities BloodGroupEntity { get; set; }

        [DataMember]
        public EmployeeDesigEntities DesignationEntity { get; set; }

        [DataMember]
        public string Avatar { get; set; }

     
    }
}
