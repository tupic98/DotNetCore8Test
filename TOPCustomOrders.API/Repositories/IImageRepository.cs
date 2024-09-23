using TOPCustomOrders.API.Models.Domain;

namespace TOPCustomOrders.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
