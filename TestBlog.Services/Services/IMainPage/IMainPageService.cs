using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBlog.Services.DTOs.MainPage;

namespace TestBlog.Services.Services.IMainPage
{
    public interface IMainPageService
    {
        MainPageDto GetData();
    }
}
