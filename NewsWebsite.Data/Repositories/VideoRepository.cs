using Microsoft.EntityFrameworkCore;
using NewsWebsite.Common;
using NewsWebsite.Data.Contracts;
using NewsWebsite.ViewModels.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace NewsWebsite.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly NewsDBContext _context;
        public VideoRepository(NewsDBContext context)
        {
            _context = context;
        }


        public async Task<List<VideoViewModel>> GetPaginateVideosAsync(int offset, int limit, string orderBy, string searchText)
        {
            var getDateTimesForSearch = searchText.GetDateTimeForSearch();
            List<VideoViewModel> videos= await _context.Videos.Where(c => c.Title.Contains(searchText) || (c.PublishDateTime >= getDateTimesForSearch.First() && c.PublishDateTime <= getDateTimesForSearch.Last()))
                                    .OrderBy(orderBy).Skip(offset).Take(limit)
                                    .Select(c => new VideoViewModel { VideoId = c.VideoId, Title = c.Title, Url = c.Url, Poster=c.Poster,PersianPublishDateTime=c.PublishDateTime.ConvertMiladiToShamsi("yyyy/MM/dd ساعت HH:mm:ss"),PublishDateTime=c.PublishDateTime}).AsNoTracking().ToListAsync();

            foreach (var item in videos)
                item.Row = ++offset;

            return videos;
        }

        public string CheckVideoFileName(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            int fileNameCount = _context.Videos.Where(f => f.Poster == fileName).Count();
            int j = 1;
            while (fileNameCount != 0)
            {
                fileName = fileName.Replace(fileExtension, "") + j + fileExtension;
                fileNameCount = _context.Videos.Where(f => f.Poster == fileName).Count();
                j++;
            }

            return fileName;
        }
    }
}
