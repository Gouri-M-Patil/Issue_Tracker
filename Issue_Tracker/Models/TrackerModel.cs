using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Issue_Tracker.Models
{
    public class TrackerModels
    {
        [Key]        
        public int Issue_ID { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        public int RepoterID { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [Column(TypeName ="nvarchar(50)")]
        public string RepoterName { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [Column(TypeName = "text")]
        public string Description  { get; set;}

        [Required(ErrorMessage = "This Filed Is Required")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [Column(TypeName = "nvarchar(50)")]
        public string AssignedToName { get; set; }

    }
}
