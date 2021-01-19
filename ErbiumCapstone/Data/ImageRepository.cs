using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using ErbiumCapstone.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Data
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        private object _repo;

        public ImageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public void CreateImage(Image image) => Create(image);

        public async Task<List<Image>> GetAllImagesAsync() => await FindAll().ToListAsync();

        public async Task<List<Image>> GetAllJobImagesAsync(List<Job> currentJobs)
        {
            List<Image> jobImages = new List<Image> { };
            foreach (Job job in currentJobs)
            {
                var jobImage = await FindByCondition(c => c.JobId.Equals(job.JobId)).FirstOrDefaultAsync();
                jobImages.Add(jobImage);
            }
            return jobImages;
        }

        public async Task<List<Image>> GetAllJobTaskImagesAsync(List<JobTask> currentJobTasks)
        {
            List<Image> jobTaskImages = new List<Image> { };
            foreach (JobTask jobTask in currentJobTasks)
            {
                var jobTaskImage = await FindByCondition(c => c.JobTaskId.Equals(jobTask.JobId)).FirstOrDefaultAsync();
                jobTaskImages.Add(jobTaskImage);
            }
            return jobTaskImages;
        }

        public async Task<Image> GetImageAsync(int imageId) =>
            await FindByCondition(c => c.ImageId.Equals(imageId)).FirstOrDefaultAsync();

        public void EditImage(Image image) => Update(image);
        public void DeleteImage(Image image) => Delete(image);
    }
}