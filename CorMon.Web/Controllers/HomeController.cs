﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using CorMon.Application.Posts;
using CorMon.Core.Enums;

namespace CorMon.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Fields

        private readonly IPostService _postService;
        private int recordsPerPage;

        #endregion

        #region Ctor

        public HomeController(IPostService postService)
        {
            _postService = postService;
            recordsPerPage = 5;
        }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.SearchAsync(page:0,recordsPerPage:recordsPerPage,term: "",isTrashed:false, publishStatus: PublishStatus.Publish, sortOrder: SortOrder.Desc);

            return View(posts);
        }


        


        #endregion

    }
}
