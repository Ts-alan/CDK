using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client = CDK.BusinessLogic.Core.DTO.Client;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client.Interfaces
{
    public interface IClientSearchService
    {
        IList<client.Area> FindAreas(string searchCriteria, int take = 10);

        IList<client.Neighborhood> FindNeighborhoodArea(long areaId, string searchQuery, int take = 10);

        IList<client.Neighborhood> FindNeighborhoodArea(string stateName, string areaName, string searchQuery, int take = 10);

        IList<client.Area> GetPopularAreas();

        client.Area FindAreaBySluggedValue(string value);

        client.Neighborhood FindNeighborhoodBySluggedValue(string value);                    

        object GetDetails(string searchString);

        object GetDetails(int id, DTO.Client.MarkerEntityEnum type);
    }
}
