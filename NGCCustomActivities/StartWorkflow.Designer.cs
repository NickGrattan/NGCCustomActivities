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
    public partial class StartWorkflow
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
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.noError = new System.Workflow.Activities.IfElseBranchActivity();
            this.error = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifError = new System.Workflow.Activities.IfElseActivity();
            this.LogFinished = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.DoStartWorkflow = new System.Workflow.Activities.CodeActivity();
            this.LogStart = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.InitStart = new System.Workflow.Activities.CodeActivity();
            // 
            // terminateActivity1
            // 
            this.terminateActivity1.Name = "terminateActivity1";
            // 
            // noError
            // 
            this.noError.Name = "noError";
            // 
            // error
            // 
            this.error.Activities.Add(this.terminateActivity1);
            ruleconditionreference1.ConditionName = "TestErrorHistoryDescription";
            this.error.Condition = ruleconditionreference1;
            this.error.Name = "error";
            // 
            // ifError
            // 
            this.ifError.Activities.Add(this.error);
            this.ifError.Activities.Add(this.noError);
            this.ifError.Name = "ifError";
            // 
            // LogFinished
            // 
            this.LogFinished.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.LogFinished.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.LogFinished.HistoryDescription = "";
            this.LogFinished.HistoryOutcome = "";
            this.LogFinished.Name = "LogFinished";
            this.LogFinished.OtherData = "";
            this.LogFinished.UserId = -1;
            // 
            // DoStartWorkflow
            // 
            this.DoStartWorkflow.Name = "DoStartWorkflow";
            this.DoStartWorkflow.ExecuteCode += new System.EventHandler(this.DoStartWorfklowCode);
            // 
            // LogStart
            // 
            this.LogStart.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.LogStart.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.LogStart.HistoryDescription = "";
            this.LogStart.HistoryOutcome = "";
            this.LogStart.Name = "LogStart";
            this.LogStart.OtherData = "";
            this.LogStart.UserId = -1;
            // 
            // InitStart
            // 
            this.InitStart.Name = "InitStart";
            this.InitStart.ExecuteCode += new System.EventHandler(this.InitStartCode);
            // 
            // StartWorkflow
            // 
            this.Activities.Add(this.InitStart);
            this.Activities.Add(this.LogStart);
            this.Activities.Add(this.DoStartWorkflow);
            this.Activities.Add(this.LogFinished);
            this.Activities.Add(this.ifError);
            this.Name = "StartWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private IfElseBranchActivity noError;
        private IfElseBranchActivity error;
        private IfElseActivity ifError;
        private TerminateActivity terminateActivity1;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity LogStart;
        private CodeActivity InitStart;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity LogFinished;
        private CodeActivity DoStartWorkflow;










    }
}
