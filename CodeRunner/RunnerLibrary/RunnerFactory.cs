using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerLibrary
{
    public static class RunnerFactory
    {
        public static Runner GetRunnerByExtension(string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension)
            {
                case ".jar": return new Runner
                {
                    ExecutableName = "java",
                    CommandLineArguments = "-jar",
                    RunFileFullPath = filename
                };
                case ".exe": return new Runner
                {
                    ExecutableName = filename
                };
                default : return new NullRunner();
            }
        }
    }
}
