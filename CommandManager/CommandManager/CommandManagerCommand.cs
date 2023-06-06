using Rhino;
using Rhino.Commands;
using System.Windows;

namespace CommandManager
{
    public class CommandManagerCommand : Command
    {
        public CommandManagerCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static CommandManagerCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "CommandManager";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            Window commandManagerWindow = new Windows.CommandManagerWindow(doc, mode);
            commandManagerWindow.Show();
            return Result.Success;
        }
    }
}