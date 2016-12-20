using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.DataAccess.Models
{
    public interface IExternalModel
    {
        DateTime LastExternalUpdate
        {
            get; set;
        }
    }
}
