using EventWhiz.Models.Domain;

namespace EventWhiz.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
