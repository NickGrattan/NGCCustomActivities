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
    public partial class CallWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            this.isWorkflowRunning1 = new IsWorkflowRunning();
            this.delayLoop = new System.Workflow.Activities.DelayActivity();
            this.whileSequence = new System.Workflow.Activities.SequenceActivity();
            this.logCallFinished = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.whileWaitforWorkflow = new System.Workflow.Activities.WhileActivity();
            this.SetWorkflowStatus = new System.Workflow.Activities.CodeActivity();
            this.startWorkflow1 = new StartWorkflow();
            this.logStartCall = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.codeSetLogMsg = new System.Workflow.Activities.CodeActivity();
            // 
            // isWorkflowRunning1
            // 
            activitybind1.Name = "CallWorkflow";
            activitybind1.Path = "__Context";
            activitybind2.Name = "CallWorkflow";
            activitybind2.Path = "__ListId";
            activitybind3.Name = "CallWorkflow";
            activitybind3.Path = "__ListItem";
            this.isWorkflowRunning1.Name = "isWorkflowRunning1";
            activitybind4.Name = "CallWorkflow";
            activitybind4.Path = "CallWorkflowName";
            activitybind5.Name = "CallWorkflow";
            activitybind5.Path = "WorkflowRunning";
            this.isWorkflowRunning1.SetBinding(IsWorkflowRunning.TestWorkflowNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.isWorkflowRunning1.SetBinding(IsWorkflowRunning.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.isWorkflowRunning1.SetBinding(IsWorkflowRunning.@__ListIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.isWorkflowRunning1.SetBinding(IsWorkflowRunning.@__ListItemProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.isWorkflowRunning1.SetBinding(IsWorkflowRunning.WorkflowRunningProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // delayLoop
            // 
            this.delayLoop.Name = "delayLoop";
            this.delayLoop.TimeoutDuration = System.TimeSpan.Parse("00:01:00");
            // 
            // whileSequence
            // 
            this.whileSequence.Activities.Add(this.delayLoop);
            this.whileSequence.Activities.Add(this.isWorkflowRunning1);
            this.whileSequence.Name = "whileSequence";
            // 
            // logCallFinished
            // 
            this.logCallFinished.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logCallFinished.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logCallFinished.HistoryDescription = "";
            this.logCallFinished.HistoryOutcome = "";
            this.logCallFinished.Name = "logCallFinished";
            this.logCallFinished.OtherData = "";
            this.logCallFinished.UserId = -1;
            // 
            // whileWaitforWorkflow
            // 
            this.whileWaitforWorkflow.Activities.Add(this.whileSequence);
            ruleconditionreference1.ConditionName = "waitForWorkflowCondition";
            this.whileWaitforWorkflow.Condition = ruleconditionreference1;
            this.whileWaitforWorkflow.Name = "whileWaitforWorkflow";
            // 
            // SetWorkflowStatus
            // 
            this.SetWorkflowStatus.Name = "SetWorkflowStatus";
            this.SetWorkflowStatus.ExecuteCode += new System.EventHandler(this.SetWorkflowStatusCode);
            // 
            // startWorkflow1
            // 
            activitybind6.Name = "CallWorkflow";
            activitybind6.Path = "__ActivationProperties";
            activitybind7.Name = "CallWorkflow";
            activitybind7.Path = "__Context";
            activitybind8.Name = "CallWorkflow";
            activitybind8.Path = "__ListId";
            activitybind9.Name = "CallWorkflow";
            activitybind9.Path = "__ListItem";
            this.startWorkflow1.Name = "startWorkflow1";
            activitybind10.Name = "CallWorkflow";
            activitybind10.Path = "CallWorkflowName";
            this.startWorkflow1.SetBinding(StartWorkflow.WorkflowNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.startWorkflow1.SetBinding(StartWorkflow.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.startWorkflow1.SetBinding(StartWorkflow.@__ListIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.startWorkflow1.SetBinding(StartWorkflow.@__ListItemProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            // 
            // logStartCall
            // 
            this.logStartCall.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logStartCall.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logStartCall.HistoryDescription = "";
            this.logStartCall.HistoryOutcome = "";
            this.logStartCall.Name = "logStartCall";
            this.logStartCall.OtherData = "";
            this.logStartCall.UserId = -1;
            // 
            // codeSetLogMsg
            // 
            this.codeSetLogMsg.Name = "codeSetLogMsg";
            this.codeSetLogMsg.ExecuteCode += new System.EventHandler(this.SetLogMsgCode);
            // 
            // CallWorkflow
            // 
            this.Activities.Add(this.codeSetLogMsg);
            this.Activities.Add(this.logStartCall);
            this.Activities.Add(this.startWorkflow1);
            this.Activities.Add(this.SetWorkflowStatus);
            this.Activities.Add(this.whileWaitforWorkflow);
            this.Activities.Add(this.logCallFinished);
            this.Name = "CallWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logCallFinished;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logStartCall;
        private CodeActivity codeSetLogMsg;
        private IsWorkflowRunning isWorkflowRunning1;
        private CodeActivity SetWorkflowStatus;
        private DelayActivity delayLoop;
        private SequenceActivity whileSequence;
        private WhileActivity whileWaitforWorkflow;
        private StartWorkflow startWorkflow1;
















































    }
}
