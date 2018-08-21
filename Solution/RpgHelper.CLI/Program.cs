using CommandAndConquer.CLI.Core;

namespace DndHelper.CLI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Processor.ProcessArguments(args);
        }
    }
}
