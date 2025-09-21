namespace Authentication;

public interface IUserFinder
{
    User? Validate(string email, string password);
    IEnumerable<User> ReturnUserList();
}