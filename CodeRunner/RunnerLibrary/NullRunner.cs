using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerLibrary
{
    public class NullRunner : Runner
    {
        public override Task RunAsync()
        {
            return new Task(() => { });
        }
        public override void Run()
        {
        }
        public override void End()
        {
        }
    }
}
