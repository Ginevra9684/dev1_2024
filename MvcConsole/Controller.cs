class Controller{
    private Database _db;
    private View _view;

    public Controller(Database db, View view){
        _db = db;
        _view = view;
    }

    public void MainMenu(){
        while(true){
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if(input == "1"){
                AddUser();
            }else if(input == "2"){
                ShowUser();
            }else if(input == "3"){
                UpdateUser();
            }else if(input == "4"){
                DeleteUser();
            }else if(input == "5"){
                SearchUserByName();
            } else if(input == "6")
            {
                break;
            }
        }
    }
    private void DeleteUser(){
        Console.WriteLine("Enter user name u want to delete:");
        var name = _view.GetInput();
        _db.DeleteUser(name);
    }
    private void UpdateUser(){
        Console.WriteLine("Enter user name u want to update:");
        var oldName = _view.GetInput();
        var newName = _view.GetInput();
        _db.UpdateUser(oldName,newName);
    }
    private void AddUser(){
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        _db.AddUser(name);
    }
    private void ShowUser(){
        var users = _db.GetUsers();
        _view.ShowUsers(users);
    }

    private void SearchUserByName(){
        Console.WriteLine("Enter user name u want to search:");
        var name = _view.GetInput();
        var users = _db.SearchUserByName(name);
        _view.ShowUsers(users);
    }
}