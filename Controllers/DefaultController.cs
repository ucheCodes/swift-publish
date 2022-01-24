using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Gitless_api.Models;

namespace Gitless_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private List<Users> _users;
        public DefaultController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            _users = new List<Users>();
        }
        [HttpGet]
        public JsonResult Get()
        {
            _users = new List<Users>(){
                new Users(){Lastname = "Matt", Firstname = "Wilipp", UserId = Guid.NewGuid().ToString(), Date = DateTime.UtcNow.ToString()},
                new Users(){Lastname = "Mattew", Firstname = "Ada Philip", UserId = Guid.NewGuid().ToString(), Date = DateTime.UtcNow.ToString()},
                new Users(){Lastname = "Donna", Firstname = "Ada", UserId = Guid.NewGuid().ToString(), Date = DateTime.UtcNow.ToString()},
            };
            return new JsonResult(_users);
        }
        [HttpPost]
        public JsonResult Update(Users u)
        {
            _users.Add(u);
            return new JsonResult(_users);
        }

                [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                List<string> fileList = new List<string>();
                var files = Request.Form.Files;
                if (files.Count == 1)
                {
                    var extension = Path.GetExtension(files[0].FileName);
                    var filename = Guid.NewGuid().ToString()+extension;
                    var physicalPath = _env.ContentRootPath + "/Photos/" + filename;
                    using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    return new JsonResult(filename); 
                }
                else if (files.Count > 1)
                {
                    foreach (var file in files)
                    {
                        var extension = Path.GetExtension(file.FileName);
                        var filename = Guid.NewGuid().ToString()+extension;
                        var physicalPath = _env.ContentRootPath + "/Photos/" + filename;
                        using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            fileList.Add(filename);
                        }
                    }
                    return new JsonResult(fileList);
                }
                else// git pull command
                { //git pull 'https://github.com/ucheCodes/swift-publish.git' main
                    return new JsonResult("img.jpg");
                }
            }
            catch (System.Exception)
            {
                
               return new JsonResult ("img.jpg");//git push -u origin main
            }
        }
    }
}