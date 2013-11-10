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
    public partial class WhileWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.reportAlreadyRunning = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.callWorkflow1 = new CallWorkflow();
            this.workflowNotRunning = new System.Workflow.Activities.IfElseBranchActivity();
            this.workflowIsRunning = new System.Workflow.Activities.IfElseBranchActivity();
            this.DoCallWorkflowWhile = new System.Workflow.Activities.WhileActivity();
            this.ifWorkflowRunning = new System.Workflow.Activities.IfElseActivity();
            this.checkWorkflowRunning = new IsWorkflowRunning();
            this.logWhileHistory = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.codeSetLogText = new System.Workflow.Activities.CodeActivity();
            // 
            // terminateActivity1
            // 
            this.terminateActivity1.Name = "terminateActivity1";
            // 
            // reportAlreadyRunning
            // 
            this.reportAlreadyRunning.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.reportAlreadyRunning.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.reportAlreadyRunning.HistoryDescription = "Error: Workflow is already running";
            this.reportAlreadyRunning.HistoryOutcome = "";
            this.reportAlreadyRunning.Name = "reportAlreadyRunning";
            this.reportAlreadyRunning.OtherData = "";
            this.reportAlreadyRunning.UserId = -1;
            // 
            // callWorkflow1
            // 
            activitybind1.Name = "WhileWorkflow";
            activitybind1.Path = "__Context";
            activitybind2.Name = "WhileWorkflow";
            activitybind2.Path = "__ListId";
            activitybind3.Name = "WhileWorkflow";
            activitybind3.Path = "__ListItem";
            activitybind4.Name = "WhileWorkflow";
            activitybind4.Path = "WhileWorkflowName";
            this.callWorkflow1.Name = "callWorkflow1";
            this.callWorkflow1.WorkflowRunning = false;
            this.callWorkflow1.SetBinding(CallWorkflow.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.callWorkflow1.SetBinding(CallWorkflow.@__ListIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.callWorkflow1.SetBinding(CallWorkflow.@__ListItemProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.callWorkflow1.SetBinding(CallWorkflow.CallWorkflowNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            // 
            // workflowNotRunning
            // 
            this.workflowNotRunning.Name = "workflowNotRunning";
            // 
            // workflowIsRunning
            // 
            this.workflowIsRunning.Activities.Add(this.reportAlreadyRunning);
            this.workflowIsRunning.Activities.Add(this.terminateActivity1);
            ruleconditionreference1.ConditionName = "condWorkflowRunning";
            this.workflowIsRunning.Condition = ruleconditionreference1;
            this.workflowIsRunning.Name = "workflowIsRunning";
            // 
            // DoCallWorkflowWhile
            // 
            this.DoCallWorkflowWhile.Activities.Add(this.callWorkflow1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.DoCallWhileCondition);
            this.DoCallWorkflowWhile.Condition = codecondition1;
            this.DoCallWorkflowWhile.Name = "DoCallWorkflowWhile";
            // 
            // ifWorkflowRunning
            // 
            this.ifWorkflowRunning.Activities.Add(this.workflowIsRunning);
            this.ifWorkflowRunning.Activities.Add(this.workflowNotRunning);
            this.ifWorkflowRunning.Name = "ifWorkflowRunning";
            // 
            // checkWorkflowRunning
            // 
            activitybind5.Name = "WhileWorkflow";
            activitybind5.Path = "__Context";
            activitybind6.Name = "WhileWorkflow";
            activitybind6.Path = "__ListId";
            activitybind7.Name = "WhileWorkflow";
            activitybind7.Path = "__ListItem";
            this.checkWorkflowRunning.Name = "checkWorkflowRunning";
            activitybind8.Name = "WhileWorkflow";
            activitybind8.Path = "WhileWorkflowName";
            this.checkWorkflowRunning.WorkflowRunning = false;
            this.checkWorkflowRunning.SetBinding(IsWorkflowRunning.TestWorkflowNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.checkWorkflowRunning.SetBinding(IsWorkflowRunning.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.checkWorkflowRunning.SetBinding(IsWorkflowRunning.@__ListIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.checkWorkflowRunning.SetBinding(IsWorkflowRunning.@__ListItemProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            // 
            // logWhileHistory
            // 
            this.logWhileHistory.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logWhileHistory.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logWhileHistory.HistoryDescription = "";
            this.logWhileHistory.HistoryOutcome = "";
            this.logWhileHistory.Name = "logWhileHistory";
            this.logWhileHistory.OtherData = "";
            this.logWhileHistory.UserId = -1;
            // 
            // codeSetLogText
            // 
            this.codeSetLogText.Name = "codeSetLogText";
            this.codeSetLogText.ExecuteCode += new System.EventHandler(this.codeSetLogTextCode);
            // 
            // WhileWorkflow
            // 
            this.Activities.Add(this.codeSetLogText);
            this.Activities.Add(this.logWhileHistory);
            this.Activities.Add(this.checkWorkflowRunning);
            this.Activities.Add(this.ifWorkflowRunning);
            this.Activities.Add(this.DoCallWorkflowWhile);
            this.Name = "WhileWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private IfElseBranchActivity workflowNotRunning;
        private IfElseBranchActivity workflowIsRunning;
        private IfElseActivity ifWorkflowRunning;
        private IsWorkflowRunning checkWorkflowRunning;
        private TerminateActivity terminateActivity1;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity reportAlreadyRunning;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logWhileHistory;
        private CodeActivity codeSetLogText;
        private CallWorkflow callWorkflow1;
        private WhileActivity DoCallWorkflowWhile;















    }
}
