using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace RunnerLibrary
{
    public interface IRunner
    {
        string ExecutableName { get; set; }
        string RunFileFullPath { get; set; }
        string CommandLineArguments { get; set; }
        Process Process { get; }
        string Input { set; }
        string Output { get; }
        string Error { get; }
        bool Finished { get; }
        StreamWriter BaseInputStream { get; }
        StreamReader BaseOutputStream { get; }
        StreamReader BaseErrorStream { get; }

        Task RunAsync();
        void Run();
        void End();
    }
}
