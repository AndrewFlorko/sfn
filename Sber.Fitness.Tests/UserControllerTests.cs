using Sber.Fitness.Controllers;
using Sber.Fitness.DTOs;

namespace Sber.Fitness.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void GetTest()
        {
            try
            {
                var controller = new UserController();

                IEnumerable<User> result = controller.Get(null);
                Assert.NotNull(result);

                // не знаю что там в базе, проверяю только то, что нет ошибок и мы что-то получили
                Assert.True(result.Count() > 0);
            }
            finally
            {
                // удаляю за собой файл с логами, если он появился
                File.Delete("c:\\temp\\errors.log");
            }
        }
    }
}