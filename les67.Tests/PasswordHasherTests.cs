using WebApplication3.Services;

namespace les67.Tests;

public class PasswordHasherTests
{
    [Fact]
    public void Md5HashPasswordTest()
    {
        var hasher = new PasswordHasher();
        var pwd = hasher.Md5HashPassword("qwerty123");
        Assert.Equal(16, pwd.Length);
        Assert.True(pwd != null);
        Assert.Equal(63, pwd[0]);
        Assert.Equal(240, pwd[4]);
        Assert.Equal(2331, pwd.Sum(p => p));
        Assert.Contains("0a7ac", hasher.ToHex(pwd));
        Assert.EndsWith("4b8b1", hasher.ToHex(pwd));
        Assert.Equal(32, hasher.ToHex(pwd).Length);
        Assert.Equal('0', hasher.ToHex(pwd)[3]);
    }
}