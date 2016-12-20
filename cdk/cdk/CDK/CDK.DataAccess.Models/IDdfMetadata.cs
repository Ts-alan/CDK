using Repository.Pattern.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.DataAccess.Models
{
    public interface IDdfMetadata: IObjectState
    {
        long Id
        {
            get; set;
        }

        string Value
        {
            get; set;
        }

        string ShortName
        {
            get; set;
        }

        string Name
        {
            get; set;
        }

        string AlternateName
        {
            get; set;
        }

        string ImgUrl
        {
            get; set;
        }
    }
}
