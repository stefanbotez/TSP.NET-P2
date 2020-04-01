using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFService
{
    [DataContract(IsReference = true)]
    public partial class TagDTO
    {
        [DataMember]
        public int TagId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int MediaId { get; set; }
        [DataMember]
        public virtual MediaDTO Media { get; set; }
    }
    [DataContract]
    public partial class MediaDTO
    {
        public MediaDTO()
        {
            this.Tags = new List<TagDTO>(); //new HashSet<Comment>();
        }
        [DataMember]
        public int MediaId { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public System.DateTime Creation_Date { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public virtual List<TagDTO> Tags { get; set; }
    }
}
