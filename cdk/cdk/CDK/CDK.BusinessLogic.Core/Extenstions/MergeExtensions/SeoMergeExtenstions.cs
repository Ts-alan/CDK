using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.Extenstions.MergeExtensions
{
    public static class SeoMergeExtenstions
    {
        public static void MergeSeo<TBd, TDto>(this TBd original, TDto data) 
            where TDto : DTO.CMS.ISeoModel 
            where TBd : DataAccess.Models.ISeoModel
        {
            original.SeoCaption = data.SeoCaption;
            original.SeoDescription = data.SeoDescription;
            original.SeoKeywords = data.SeoKeywords;
            original.SeoSlug = data.SeoSlug;
            original.SeoMetaDescription = data.SeoMetaDescription;
            original.SeoTitle = data.SeoTitle;
            original.SeoURI = data.SeoURI;
        }
    }
}
