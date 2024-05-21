

bool condition = true;
List<string> todos = new List<string>();
do
{
    
    Console.WriteLine("\nHello!\r\nWhat do you want to do?\r\n[S]ee all TODOs\r\n[A]dd a TODO\r\n[R]emove a TODO\r\n[E]xit\r");

    string choise = Console.ReadLine();
    switch (choise.ToLower())
    {
        case "s":
            {
                showToDos();
                break;
            }
        case "a":
            {
                addToDo();
                break;
            }
        case "r":
            {
                removeToDo();
                break;
            }
        case "e":
            {
                condition = false;
                break;
            }
        default: { Console.WriteLine("Invalid input"); break; }
    }
} while (condition);


void showToDos()
{
    if(todos.Count > 0)
    {
        for(int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todos[i]}");
        }
    }
    else
    {
        Console.WriteLine("List empty.");
    }
}
void addToDo()
{
    Console.WriteLine("Enter item to do: ");
    string todo = Console.ReadLine();
    if(todos.Contains(todo))
    {
        Console.WriteLine("Item alredy added!");
    }
    else if(todo == "")
    {
        Console.WriteLine("The description cannot be empty");
    }else
    {
        Console.WriteLine($"TODO successfully added: {todo}");
        todos.Add(todo);
    }
}
void removeToDo()
{
    
    if (todos.Count == 0)
    {
        Console.WriteLine("List is empty");
    }
    else
    {
        Console.WriteLine("Insert index of item to remove: ");
        string input = Console.ReadLine();
        int index;
        int.TryParse(input, out index);
        if (index < 0 || index > todos.Count)
        {
            Console.WriteLine("Index out of range! ");
        }
        else
        {
            todos.RemoveAt(index - 1);
        }
    }
        
}
