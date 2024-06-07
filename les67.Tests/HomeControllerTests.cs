using Microsoft.AspNetCore.Mvc;
using WebApplication3;
using WebApplication3.Controllers;
using WebApplication3.Models;

public class HomeControllerTests
{
    [Fact]
    public void IndexTest()
    {
        HomeController controller = new HomeController();
        ViewResult result = controller.Index() as ViewResult;
        Assert.NotNull(result);
        Assert.Equal("Main", result.ViewName);
        Assert.Equal(typeof(IndexViewModel), result.Model.GetType());
        Assert.NotNull(result.Model);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Добрый день, это тестовый текст на главной странице", result?.ViewData["Message"]);
    }
        
    [Fact]
    public void PrivacyTest()
    {
        HomeController controller = new HomeController();
        ViewResult result = controller.Privacy() as ViewResult;
        Assert.Contains("Текст политики конфидециальности", (string)result?.ViewData["Policy"]);
        Assert.Equal("Privacy", result?.ViewName);
        Assert.True(result?.Model is null);
        Assert.EndsWith("сайта.", result?.ViewData["Policy"] as string);
        Assert.Equal(39, (result?.ViewData["Policy"] as string).Length);
    }

    [Fact]
    public void TestPageTest() { 
        HomeController controller = new HomeController();
        ViewResult result = controller.TestPage(2) as ViewResult;
        var model = result.Model as TestPageViewModel;
        Assert.NotNull(result);
        Assert.NotNull(model);
        Assert.True(result.ViewData.ContainsKey("PageIncrement"));
        Assert.Equal(13, "PageIncrement".Length);
        Assert.Equal(3, result.ViewData["PageIncrement"]);
    }

}