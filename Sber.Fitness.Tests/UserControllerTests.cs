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

                // �� ���� ��� ��� � ����, �������� ������ ��, ��� ��� ������ � �� ���-�� ��������
                Assert.True(result.Count() > 0);
            }
            finally
            {
                // ������ �� ����� ���� � ������, ���� �� ��������
                File.Delete("c:\\temp\\errors.log");
            }
        }
    }
}