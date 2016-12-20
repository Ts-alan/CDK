using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public interface IVideoContainerModel
    {
        string VideosJSON
        {
            get; set;
        }

        string VideoListJSON();
    }
}
