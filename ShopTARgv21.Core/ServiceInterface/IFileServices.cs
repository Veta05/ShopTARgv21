using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System.Xml;


namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(CarDto dto, Car domain);

        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dto);
    }
}