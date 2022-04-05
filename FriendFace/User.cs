namespace FriendFace;

public class User
{
    public string Name { get; private set;}
    public int BirthYear { get; private set;}
    public string Gender { get; private set;}
    public int Height { get; private set;}
    public List<User> Friends = new();

    public User(string name, int birthYear, string gender, int height, List<User> userList)
    {
        Name = name;
        BirthYear = birthYear;
        Gender = gender;
        Height = height;
        userList.Add(this);
    }

    public void ShowUserData()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Year of birth: " + BirthYear);
        Console.WriteLine("Gender: " + Gender);
        Console.WriteLine("Height: " + Height);
        ShowFriends();
    }
    
    public void ShowFriends()
    {
        if (Friends.Count == 0) return;
        Console.Write("Friends: ");
        for (var index = 0; index < Friends.Count; index++)
        {
            var friend = Friends[index];
            if (index + 1 != Friends.Count) Console.Write(friend.Name + ", ");
            else Console.WriteLine(friend.Name);
        }
    }
    public void AddFriend(User newFriend)
    {
        Friends.Add(newFriend);
        newFriend.Friends.Add(this);
    }
    public void RemoveFriend(User friend)
    {
        Friends.Remove(friend);
        friend.Friends.Remove(this);
    }
    public List<User> GenerateFriendOptions(List<User> userList, bool inFriendList)
    {
        var availableUsers = new List<User>();
        foreach (var user in userList)
        {
            if (!inFriendList)
            {
                if (user != this && !Friends.Contains(user)) availableUsers.Add(user);
            }
            else if (Friends.Contains(user)) availableUsers.Add(user);
        }
        return availableUsers;
    }
}

