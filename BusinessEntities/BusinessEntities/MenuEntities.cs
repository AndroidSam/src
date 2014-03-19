using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    [DataContract,Serializable]
    public class MenuEntities
    {
        [Key]
        [DataMember]
        [ScaffoldColumn(false)]
        public Guid MenuId { get; set; }
        [DataMember]
        public string MenuName { get; set; }
        [DataMember]
        public int MenuOrder { get; set; }
        [DataMember]
        public bool IsMain { get; set; }
        [DataMember]
        public Guid? MainMenuId { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public string View { get; set; }
        [DataMember]
        public int level { get; set; }
        [DataMember]
        public string Controller { get; set; }
        [DataMember]
        public string ActionControl { get; set; }
    }
}
