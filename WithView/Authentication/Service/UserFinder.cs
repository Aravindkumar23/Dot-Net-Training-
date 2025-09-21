using Utility;

namespace Authentication;

public class UserFinder : IUserFinder
{
      // public List<User> users;
      //  public UserService() { 
      //    users = new List<User>();
      //    users.Add(new User { Email="ravi.tambade@transflower.in", Password="seed" });
      //    users.Add(new User { Email = "shubhangi.tambade@gmail.com", Password = "transflower" });
      //  }  

      private readonly string jsonUserFilePath = FileConstants.UserDataFilePath;
      private readonly JSONHelperService _jsonHelperService = new JSONHelperService();

      public User? Validate(string email, string password)
      {
            return ReturnUserList().FirstOrDefault(user => user.Email == email && user.Password == password);
      }

      public IEnumerable<User> ReturnUserList()
      {
            return _jsonHelperService.LoadFromJsonFile<List<User>>(jsonUserFilePath);
      }
}
