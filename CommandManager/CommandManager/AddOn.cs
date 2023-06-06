using Rhino.Commands;
using System;
using System.IO;
using System.Reflection;

namespace CommandManager
{
    internal class AddOn
    {
        public string Path { get; private set; }
        private Assembly assembly;
        public string NamespaceName { get; private set; }
        public string CommandClassName { get; private set; }
        public MethodInfo RunCMDMethod { get; private set; }
        public Command CommandInstance { get; private set; }

        public AddOn(string path)
        {
            Path = path;
            LoadAssembly();
            ParseName();
            LoadCommand();
        }

        private void LoadAssembly()
        {
            try
            {
                assembly = Assembly.Load(File.ReadAllBytes(Path)); ;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading assembly:" + e.Message);
            }
        }

        private void ParseName()
        {
            var types = assembly.GetTypes();
            NamespaceName = types[0].Namespace;
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Command)))
                {
                    CommandClassName = type.Name;
                }
            }
        }

        public void LoadCommand()
        {
            Type commandType = assembly.GetType($"{NamespaceName}.{CommandClassName}");
            if (commandType != null)
            {
                CommandInstance = (Command)Activator.CreateInstance(commandType);

                RunCMDMethod = commandType.GetMethod("RunCommand", BindingFlags.NonPublic | BindingFlags.Instance);
                //CMD = () => runCMDMethod.Invoke(command, new object[] { doc, mode });
            }
        }
    }
}