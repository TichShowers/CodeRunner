using System;

namespace RunnerLibrary
{
    public class CompileAndRunner : Runner, IRunner
    {
        public IRunner Runner { get; set; }
        public string CompiledRunnableFullPath { get; set; }
        public new string Input { set { Runner.Input = value; } }
        public new string Output
        {
            get { return Runner.Output; }
        }
        public new string Error
        {
            get { return Runner.Error; }
        }

        public override void Run()
        {
            InsertRunnableIntoArguments();
            base.Run();
            Runner.RunFileFullPath = CompiledRunnableFullPath;
            Runner.Run();
        }

        private void InsertRunnableIntoArguments()
        {
            CommandLineArguments = String.Format(CommandLineArguments, CompiledRunnableFullPath);
        }
    }
}
