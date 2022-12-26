using Microsoft.AspNetCore.Mvc;
using netshop.Models;

namespace netshop.Services
{
    public interface ILinkService<T>
    {
        object ExpandSingleFoodItem(object resource, int identifier, ApiVersion version);

        List<LinkDto> CreateLinksForCollection(QueryParameters queryParameters, int totalCount, ApiVersion version);
    }
}
