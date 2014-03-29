using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace RunnerLibrary
{
    public class Runner : IRunner
    {
        public string ExecutableName { get; set; }
        public string RunFileFullPath { get; set; }
        public string CommandLineArguments { get; set; }
        public Process Process { get; private set; }
        public string Input
        {
            set { BaseInputStream.WriteLineAsync(value); }
        }
        public string Output 
        {
            get { return BaseOutputStream.ReadToEnd(); }
        }
        public string Error
        {
            get { return BaseErrorStream.ReadToEnd(); }
        }
        public bool Finished
        {
            get { return Process.HasExited; }
        }
        public virtual StreamWriter BaseInputStream
        {
            get { return Process.StandardInput; }
        }

        public virtual StreamReader BaseOutputStream
        {
            get { return Process.StandardOutput; }
        }
        public virtual StreamReader BaseErrorStream
        {
            get { return Process.StandardError; }
        }
        public async virtual Task RunAsync()
        {
            await Task.Run(()=> Run());
        }
        public virtual void Run()
        {
            Process = new Process
            {
                StartInfo =
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    FileName = ExecutableName,
                    UseShellExecute = true,
                    Arguments = CommandLineArguments + ' ' + ExecutableName,
                    CreateNoWindow = true
                }
            };

            Process.Start();
        }

        public virtual void End()
        {
            Process.Close();
            Process.Kill();
        }
    }
}
