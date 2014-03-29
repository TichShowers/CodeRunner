namespace RunnerLibrary
{
    public class BinaryRunner : Runner
    {
        public override void Run()
        {
            ExecutableName = RunFileFullPath;
            base.Run();
        }
    }
}
