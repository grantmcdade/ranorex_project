using System;
using System.Collections.Generic;
using System.Text;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace aqua.UntitledNamespace2961
{
    /// <summary>
    /// This is the main class of your script.
    /// </summary>
    [aqua.Script("0a3a3eb4-c30a-46a7-aaac-fabf97003718")]
    [TestModule("0a3a3eb4-c30a-46a7-aaac-fabf97003718", ModuleType.UserCode, 1)]
    public class Main : aqua.IRanorexScript, ITestModule
    {
        public IDictionary<string, string> Parameters { get; set; }
        public IDictionary<string, object> Context { get; set; }

        /// <summary>
        /// This is the entry point for executing this script. When invoked from aqua, this
        /// method will be started during script execution.
        /// </summary>
        public ScriptExecutionStatus Start()
        {
            try{
                VariablesHelper.Instance.SetVariablesInRecordingAuto(this, MainRecording.Instance); 
            	MainRecording.Start();
            	return ScriptExecutionStatus.Successful;
            }
            catch(ValidationException){
            	return ScriptExecutionStatus.Failed;
            }
        }

        public void Run(){
            Start();
        }

    }
}