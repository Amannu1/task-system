using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("To-do")]
        Todo = 1,
        [Description("In progress")]
        InProgress = 2,
        [Description("Done")]
        Done = 3

    }
}
