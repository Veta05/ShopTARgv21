using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);

        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
    }
}
