using DelegateEventSample.Model;
using DelegateEventSample.Repository;
using DelegateEventSample.Services;

class Program
{
    public static void Main(string[] args)
    {
        var userRepository = new UserRepository();
        var userService = new UserServices(userRepository);

        var user1 = new User { Id = 1, Name = "John", Email = "john@example.com", Contact = "1234567890" };
        userService.AddUser(user1);
    }
}
