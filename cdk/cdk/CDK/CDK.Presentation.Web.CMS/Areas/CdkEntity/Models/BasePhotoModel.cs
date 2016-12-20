using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class BasePhotoModel : BaseModel, IPhotoModel
    {            
        [Display(Name = "Photo Name")]
        [Required]
        [MaxLength(255)]
        public string PhotoName
        {
            get; set;
        }

        [Display(Name = "Photo Alt")]
        [MaxLength(255)]
        public string PhotoAlt
        {
            get; set;
        }

        [Display(Name = "Photo Type")]
        [MaxLength(255)]
        public string PhotoType
        {
            get; set;
        }

        [Display(Name = "Photo")]     
        [DataType(DataType.ImageUrl)]
        public string LargeUri
        {
            get; set;
        }

        [Display(Name = "Photo small")]    
        [DataType(DataType.ImageUrl)]
        public string SmallUri
        {
            get; set;
        }

        [Display(Name = "Thumbnail")]   
        [DataType(DataType.ImageUrl)]
        public string ThumbnailUri
        {
            get; set;
        }

        [Display(Name = "Photo Description")]
        [DataType(DataType.MultilineText)]
        public string PhotoDescription
        {
            get; set;
        }

        //For UI
        public bool IsDeleted
        {
            get; set;
        }

        public string Base64String
        {
            get; set;
        }
    }
}
