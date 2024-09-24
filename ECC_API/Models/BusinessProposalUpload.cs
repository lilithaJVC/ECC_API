using System.ComponentModel.DataAnnotations;

namespace ECC_API.Models
{
    public class BusinessProposalUpload
    {
        [Key]
        public int UploadID { get; set; }
        public int StudentNum { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }

        // Navigation property
        public virtual Students Student { get; set; }
    }
}
