using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public interface IPhotoContainerModel
    {
        string PhotoJSON
        {
            get; set;
        }

        string PhotoStorageUrl
        {
            get;
        }

        string PhotoListJSON();
    }
}
