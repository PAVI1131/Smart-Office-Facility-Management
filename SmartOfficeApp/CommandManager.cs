public static class CommandManager
{
    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }
}
