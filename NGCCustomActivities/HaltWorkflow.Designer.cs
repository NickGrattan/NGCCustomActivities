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
    public partial class HaltWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            this.WarnNotRunning = new System.Workflow.Activities.CodeActivity();
            this.DoHaltWorkflow = new System.Workflow.Activities.CodeActivity();
            this.NotRunning = new System.Workflow.Activities.IfElseBranchActivity();
            this.Running = new System.Workflow.Activities.IfElseBranchActivity();
            this.LogHalt = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.HaltIfRunning = new System.Workflow.Activities.IfElseActivity();
            this.isWorkflowRunning1 = new NGCCustomActivities.IsWorkflowRunning();
            // 
            // WarnNotRunning
            // 
            this.WarnNotRunning.Name = "WarnNotRunning";
            this.WarnNotRunning.ExecuteCode += new System.EventHandler(this.WarnNotRunningCode);
            // 
            // DoHaltWorkflow
            // 
            this.DoHaltWorkflow.Name = "DoHaltWorkflow";
            this.DoHaltWorkflow.ExecuteCode += new System.EventHandler(this.DoHaltWorkflowCode);
            // 
            // NotRunning
            // 
            this.NotRunning.Activities.Add(this.WarnNotRunning);
            this.NotRunning.Name = "NotRunning";
            // 
            // Running
            // 
            this.Running.Activities.Add(this.DoHaltWorkflow);
            ruleconditionreference1.ConditionName = "ifRunning";
            this.Running.Condition = ruleconditionreference1;
            this.Running.Name = "Running";
            // 
            // LogHalt
            // 
            this.LogHalt.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.LogHalt.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.LogHalt.HistoryDescription = "";
            this.LogHalt.HistoryOutcome = "";
            this.LogHalt.Name = "LogHalt";
            this.LogHalt.OtherData = "";
            this.LogHalt.UserId = -1;
            // 
            // HaltIfRunning
            // 
            this.HaltIfRunning.Activities.Add(this.Running);
            this.HaltIfRunning.Activities.Add(this.NotRunning);
            this.HaltIfRunning.Name = "HaltIfRunning";
            // 
            // isWorkflowRunning1
            // 
            activitybind1.Name = "HaltWorkflow";
            activitybind1.Path = "__Context";
            activitybind2.Name = "HaltWorkflow";
            activitybind2.Path = "__ListId";
            activitybind3.Name = "HaltWorkflow";
            activitybind3.Path = "__ListItem";
            this.isWorkflowRunning1.Name = "isWorkflowRunning1";
            activitybind4.Name = "HaltWorkflow";
            activitybind4.Path = "WorkflowName";
            activitybind5.Name = "HaltWorkflow";
            activitybind5.Path = "IsWorkflowRunning";
            this.isWorkflowRunning1.SetBinding(NGCCustomActivities.IsWorkflowRunning.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.isWorkflowRunning1.SetBinding(NGCCustomActivities.IsWorkflowRunning.@__ListIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.isWorkflowRunning1.SetBinding(NGCCustomActivities.IsWorkflowRunning.@__ListItemProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.isWorkflowRunning1.SetBinding(NGCCustomActivities.IsWorkflowRunning.WorkflowRunningProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.isWorkflowRunning1.SetBinding(NGCCustomActivities.IsWorkflowRunning.TestWorkflowNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            // 
            // HaltWorkflow
            // 
            this.Activities.Add(this.isWorkflowRunning1);
            this.Activities.Add(this.HaltIfRunning);
            this.Activities.Add(this.LogHalt);
            this.Name = "HaltWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity LogHalt;
        private CodeActivity WarnNotRunning;
        private CodeActivity DoHaltWorkflow;
        private IfElseBranchActivity NotRunning;
        private IfElseBranchActivity Running;
        private IfElseActivity HaltIfRunning;
        private IsWorkflowRunning isWorkflowRunning1;













    }
}
