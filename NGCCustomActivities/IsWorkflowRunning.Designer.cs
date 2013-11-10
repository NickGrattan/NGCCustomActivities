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
    public partial class IsWorkflowRunning
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.logWorkflow = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.errorEmpty = new System.Workflow.Activities.IfElseBranchActivity();
            this.errorNotEmpty = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifReportError = new System.Workflow.Activities.IfElseActivity();
            this.TestWorkflowRunning = new System.Workflow.Activities.CodeActivity();
            // 
            // logWorkflow
            // 
            this.logWorkflow.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logWorkflow.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logWorkflow.HistoryDescription = "";
            this.logWorkflow.HistoryOutcome = "";
            this.logWorkflow.Name = "logWorkflow";
            this.logWorkflow.OtherData = "";
            this.logWorkflow.UserId = -1;
            // 
            // errorEmpty
            // 
            this.errorEmpty.Name = "errorEmpty";
            // 
            // errorNotEmpty
            // 
            this.errorNotEmpty.Activities.Add(this.logWorkflow);
            ruleconditionreference1.ConditionName = "errorDescriptionEmpty";
            this.errorNotEmpty.Condition = ruleconditionreference1;
            this.errorNotEmpty.Name = "errorNotEmpty";
            // 
            // ifReportError
            // 
            this.ifReportError.Activities.Add(this.errorNotEmpty);
            this.ifReportError.Activities.Add(this.errorEmpty);
            this.ifReportError.Name = "ifReportError";
            // 
            // TestWorkflowRunning
            // 
            this.TestWorkflowRunning.Name = "TestWorkflowRunning";
            this.TestWorkflowRunning.ExecuteCode += new System.EventHandler(this.CodeTestWorkflowRunning);
            // 
            // IsWorkflowRunning
            // 
            this.Activities.Add(this.TestWorkflowRunning);
            this.Activities.Add(this.ifReportError);
            this.Name = "IsWorkflowRunning";
            this.CanModifyActivities = false;

        }

        #endregion

        private IfElseBranchActivity errorEmpty;
        private IfElseBranchActivity errorNotEmpty;
        private IfElseActivity ifReportError;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logWorkflow;
        private CodeActivity TestWorkflowRunning;








    }
}
