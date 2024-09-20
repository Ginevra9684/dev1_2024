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
                _db.CloseConnection();
            }
            else if(input == "7")
            {
                break;
            }
        }
    }
    private void DeleteUser(){
        Console.WriteLine("Enter user name u want to delete:");
        do
        {
            var name = _view.GetInput();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("invalid input, try again");
                continue;
            }
            else
            {
                _db.DeleteUser(name);
                return;
            }
        }while (true);
    }
    private void UpdateUser(){
        Console.WriteLine("Enter user name u want to update and both new name and surname:");
        do
        {
            var active = true;
            var oldName = _view.GetInput();
            var newName = _view.GetInput();
            var newSurname = _view.GetInput();
            var choice = _view.GetInput();
                if (choice == "0") active = false;
                else if (choice == "1") active = true;
                else Console.WriteLine("invalid input, try again");
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newSurname))
            {
                Console.WriteLine("invalid input, try again");
                continue;
            }
            else
            {
                _db.UpdateUser(oldName,newName,newSurname,active);
                return;
            }
        }while (true);
    }
    private void AddUser(){
        Console.WriteLine("Enter user name and surname:");
        do
        {
            var active = true;
            var name = _view.GetInput();
            var surname = _view.GetInput();
            Console.WriteLine("Enter 0 for inactive state or 1 for active state");
            var choice = _view.GetInput();
                if (choice == "0") active = false;
                else if (choice == "1") active = true;
                else Console.WriteLine("invalid input, try again");

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("invalid input, try again");
                continue;
            }
            else
            {
                _db.AddUser(name, surname, active);
                return;
            }
        }while (true);
    }
    private void ShowUser(){
        var users = _db.GetUsers();
        _view.ShowUsers(users);
    }

    private void SearchUserByName(){
        Console.WriteLine("Enter user name u want to search:");
        do
        {
            var name = _view.GetInput();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("invalid input, try again");
                continue;
            }
            else
            {
                var users = _db.SearchUserByName(name);
                _view.ShowUsers(users);
                return;
            }
        }while (true);
    }
}