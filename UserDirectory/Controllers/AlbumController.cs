using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDirectory.BusinessLayer;
using UserDirectory.Infrastructure;
using UserDirectory.Models;
using UserDirectory.Models.ViewModels;

namespace UserDirectory.Controllers
{
   public class AlbumController : Controller
    {
        private readonly IAlbumService _service;
        public AlbumController(IAlbumService service)
        {
            _service = service;
        }

        // GET
        [HttpResponseException]
        public async Task<IActionResult> List(string searchString, int pageNumber = 1)
        {
            var allAlbums = await _service.SearchAlbums(searchString);

            var skipItems = (pageNumber - 1) * Constants.DefaultPageSize;
            var albumPage = allAlbums.Skip(skipItems).Take(Constants.DefaultPageSize).ToList();

            var photosOfAlbumsDictionary = await _service.GetPhotosForAlbums(albumPage.Select(t => t.Key));

            var albumUserViewModelList = new List<AlbumUserViewModel>();
            foreach (var albumItem in albumPage)
            {
                var albumUserModel = new AlbumUserViewModel()
                {
                    Id = albumItem.Key.Id,
                    AlbumTitle = albumItem.Key.Title,
                    Address = albumItem.Value?.Address ?? new Address(),
                    Email = albumItem.Value?.Email ?? string.Empty,
                    Phone = albumItem.Value?.Phone ?? string.Empty,
                    UserId = albumItem.Value?.Id ?? 0,
                    UserName = albumItem.Value?.Name ?? string.Empty,
                    ThumbnailUrl = photosOfAlbumsDictionary.ContainsKey(albumItem.Key.Id)
                        ? photosOfAlbumsDictionary[albumItem.Key.Id].FirstOrDefault()?.ThumbnailUrl : string.Empty
                };
                albumUserViewModelList.Add(albumUserModel);
            }

            var albumsViewModel = new AlbumsViewModel()
            {
                AlbumsUserViewModel = albumUserViewModelList,
                PagingData = new PagingData()
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = Constants.DefaultPageSize,
                    TotalItems = allAlbums.Count()
                }
            };

            ViewBag.searchString = searchString;

            return View(albumsViewModel);
        }
    }
}