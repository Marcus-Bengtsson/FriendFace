using FriendFace;
var userList = new List<User>();
var user1 = new User("Marcus", 1999, "Male", 183, userList);
var user2 = new User("Marius", 1988, "Male", 190, userList);
var user3 = new User("Linn", 1998, "Female", 168, userList);
var user4 = new User("Anders", 1996, "Male", 186, userList);
var currentUser = user1;
currentUser.AddFriend(user2);
currentUser.AddFriend(user4);

ShowOptions();


void ShowOptions()
{
    while (true)
    {
        Console.WriteLine("Logged in as: " + currentUser.Name);
        Console.WriteLine(@"   Options: 
      (1) View Profile
      (2) View Friends
      (3) Add Friend
      (4) Remove Friend");
        var choice = Console.ReadLine()!.ToLower();
        if (choice is "1" or "profile")
        {
            currentUser.ShowUserData();
            Console.ReadLine();
        }
        else if (choice is "2" or "friends")
        {
            var chosenFriend = ChooseFriend(true);
            chosenFriend.ShowUserData();
            Console.ReadLine();
        }
        else if (choice is "3" or "add")
        {
            var chosenFriend = ChooseFriend(false);
            currentUser.AddFriend(chosenFriend);
            currentUser.ShowFriends();
        }
        else if (choice is "4" or "remove")
        {
            var chosenFriend = ChooseFriend(true);
            currentUser.RemoveFriend(chosenFriend);
            currentUser.ShowFriends();
        }
    }
}

User ChooseFriend(bool inFriendList)
{
    var availableUsers = currentUser.GenerateFriendOptions(userList, inFriendList);
    ShowUserOptions(availableUsers);
    try
    {
        var choice = Console.ReadLine();
        if (choice == "") ShowOptions();
        foreach (var user in availableUsers.Where(user => choice!.ToLower() == user.Name.ToLower()))
        {
            return user;
        }

        int choiceInt = Convert.ToInt32(choice);
        return availableUsers[choiceInt - 1];
    }
    catch (Exception)
    {
        Console.WriteLine("invalid choice, please choose a name or number from the list below or press enter to exit:");
        ChooseFriend(inFriendList);
        return null!;
    }
}

void ShowUserOptions(List<User> users)
{
    if(users.Count == 0)
    {
        Console.WriteLine("No options available");
        ShowOptions();
        return;
    }
    for (var i = 0; i < users.Count; i++)
    {
        Console.WriteLine($"({i + 1}) {users[i].Name}");
    }
}