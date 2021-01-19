using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface IImageRepository : IRepositoryBase<Image>
    {
        void CreateImage(Image image);
        Task<Image> GetImageAsync(int imageId);
        void EditImage(Image image);
        void DeleteImage(Image image);
        Task<List<Image>> GetAllImagesAsync();

        Task<List<Image>> GetAllJobImagesAsync(List<Job> currentJobs);

        Task<List<Image>> GetAllJobTaskImagesAsync(List<JobTask> currentJobTasks);

    }
}
