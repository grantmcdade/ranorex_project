using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Ranorex;

namespace aqua
{
    /// <summary>
    /// This class is used by aqua to execute the whole test, constructed out of 
    /// individual test steps. You should not change this file as it will be regenerated automatically.
    /// </summary>
    public class Runner
    {
    	private static Dictionary<string, string> DataSheet = new Dictionary<string, string>();
    	private static Dictionary<string, object> Context = new Dictionary<string, object>();

        /// <summary>
        /// Starting point for a test execution
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
			Report.Setup(ReportLevel.Info, @"C:\Users\gmcda\Documents\aqua Automation Projects\TC003204.001\aquaProject.csproj.rxlog", true);
            Report.Start();

            

             // Setting variables for step: Enter name (step index: 0)
             DataSheet.Clear();

             ReportVariables("Enter name");

            try 
            {    
            
                System.GC.Collect();  // forced garbage collection
            
                aqua.IScript script =  GetScriptClass("0a3a3eb4-c30a-46a7-aaac-fabf97003718");
            
                SetTestParams(script);
                script.Start();    
            } 
            catch (RanorexException ex) 
            {    
            	Report.Error(ex.ToString());	
            	Report.Screenshot();
            	Report.End();
            	return;
            } 
            catch (Exception ex) 
            {
                
            	Report.Error("Unexpected exception occured" + ex.ToString());
            	Report.End();
            	return;
            }
            finally
            {
                System.GC.Collect();  // forced garbage collection
            }
            
            Report.End();
        }


        private static IScript GetScriptClass(string code)
        {
        	foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
        	{
        		foreach(Attribute at in t.GetCustomAttributes(true))
        		{
        			if (at is ScriptAttribute && (at as ScriptAttribute).Code == code)
        			{
        				ConstructorInfo ci = t.GetConstructor(new Type[] {});
        				return ci.Invoke(new object[] {}) as IScript;        				
        			}        		
        		}        	
        	}
        	return null;
        }

        private static void SetTestParams(object Test)
        {
            if (Test is IRanorexScript)
            {
                IRanorexScript ranorexScript = Test as IRanorexScript;
                ranorexScript.Parameters = DataSheet; 
                ranorexScript.Context = Context; 
            }        	
        }

        private static void ReportVariables(string _stepName)
        {
            StringBuilder variables = new StringBuilder(); 

            if (_stepName != null && _stepName != "")
                variables.AppendFormat("Variables for step '{0}': ", _stepName);
            else
                variables.Append("Variables: ");

            foreach (KeyValuePair<string, string> kvp in DataSheet)
            {
                variables.Append('(');
                variables.Append(kvp.Key);
            	variables.Append('=');
                variables.Append(kvp.Value);
            	variables.Append(')');
            }

            Report.Info(variables.ToString());        
        }
    }

    public class ScriptAttribute:Attribute
    {
        private string _Code;

        public ScriptAttribute(string _code)
        {
            _Code = _code;
        }

        public string Code
        {
            get
            {
                return _Code;
            }
        }
    }


    /// <summary>
    /// Starting point for a single ranorex-aqua script.
    /// </summary>
    public interface IScript
    {
        /// <summary>
        /// Main script method. Called by the framework when script is to be executed. 
        /// </summary>
        /// <returns>Execution status</returns>
        ScriptExecutionStatus Start();
    }


    /// <summary>
    /// Starting point for a single ranorex-aqua script that uses variables.
    /// </summary>
    public interface IRanorexScript : IScript
    {
        /// <summary>
        /// Map of script parameters. Setter is called by framework (before script starts) with actual values of variables received from aqua. 
        /// </summary>
        IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// General-purpose map intended to store information passed between scripts. 
        /// Setter is called by framework before script execution start 
        /// (passed map is singletone - is shared by all scripts being executed). 
        /// 
        /// </summary>
        IDictionary<string, object> Context { get; set; }
    }

    public enum ScriptExecutionStatus
    {
        Undefined,
        Successful,
        Failed,
        Blocked,
    }

    
    public class VariablesHelper
    {
        public static VariablesHelper Instance { get; private set; }

        static VariablesHelper()
        {
            Instance = new VariablesHelper();
        }

        protected VariablesHelper()
        {
        }

        public void SetVariablesInRecordingAuto(IScript script, object recording)
        {
            IDictionary<string, string> mapping = new Dictionary<string, string>();
            IDictionary<string, string> variables = new Dictionary<string, string>();

            if (script is IRanorexScript)
            {
                variables = (script as IRanorexScript).Parameters;
            }

            IDictionary<string, PropertyInfo> recordingProperties = GetRecordingProperties(recording);

            if (variables != null && variables.Count > 0)
            {
                foreach (string varName in variables.Keys)
                {
                    string varValue = variables[varName];

                    string propertyName = varName;

                    if (mapping.ContainsKey(propertyName))
                        propertyName = mapping[propertyName];

                    if (recordingProperties.ContainsKey(propertyName))
                    {
                        PropertyInfo prop = recordingProperties[propertyName];
                        prop.SetValue(recording, varValue, null);
                    }
                }
            }

        }

        public IDictionary<string, PropertyInfo> GetRecordingProperties(object recording)
        {
            IDictionary<string, PropertyInfo> result = new Dictionary<string, PropertyInfo>();

            if (recording == null)
                return result;

            foreach (PropertyInfo p in recording.GetType().GetProperties())
            {
                if (Attribute.IsDefined(p, typeof(Ranorex.Core.Testing.TestVariableAttribute)))
                {
                    result.Add(p.Name, p);
                }
            }

            return result;
        }

    }


}