using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace NGCCustomActivities
{
    public partial class RestartThisWorkflow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.doRestart = new System.Workflow.Activities.CodeActivity();
            this.waitLittleWhile = new System.Workflow.Activities.DelayActivity();
            this.logReportWait = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            // 
            // doRestart
            // 
            this.doRestart.Name = "doRestart";
            this.doRestart.ExecuteCode += new System.EventHandler(this.doRestartCode);
            // 
            // waitLittleWhile
            // 
            this.waitLittleWhile.Name = "waitLittleWhile";
            this.waitLittleWhile.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
            // 
            // logReportWait
            // 
            this.logReportWait.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logReportWait.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logReportWait.HistoryDescription = "Waiting a minute or so to restart this workflow...";
            this.logReportWait.HistoryOutcome = "";
            this.logReportWait.Name = "logReportWait";
            this.logReportWait.OtherData = "";
            this.logReportWait.UserId = -1;
            // 
            // RestartThisWorkflow
            // 
            this.Activities.Add(this.logReportWait);
            this.Activities.Add(this.waitLittleWhile);
            this.Activities.Add(this.doRestart);
            this.Name = "RestartThisWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private DelayActivity waitLittleWhile;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logReportWait;
        private CodeActivity doRestart;






    }
}
