using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace NGCCustomActivities
{
    public partial class CallWorkflow : SequenceActivity
    {
        public CallWorkflow()
        {
            InitializeComponent();
        }

        #region Standard Dependency Properties
        public static DependencyProperty __ContextProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__Context",
            typeof(WorkflowContext), typeof(CallWorkflow));

        [Description("Context")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public WorkflowContext __Context
        {
            get
            {
                return ((WorkflowContext)(base.GetValue(CallWorkflow.__ContextProperty)));
            }
            set
            {
                base.SetValue(CallWorkflow.__ContextProperty, value);
            }
        }

        public static DependencyProperty __ListIdProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListId",
            typeof(string), typeof(CallWorkflow));

        [Description("List Id")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string __ListId
        {
            get
            {
                return ((string)(base.GetValue(CallWorkflow.__ListIdProperty)));
            }
            set
            {
                base.SetValue(CallWorkflow.__ListIdProperty, value);
            }
        }

        public static DependencyProperty __ListItemProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListItem",
            typeof(int), typeof(CallWorkflow));

        [Description("List Item")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int __ListItem
        {
            get
            {
                return ((int)(base.GetValue(CallWorkflow.__ListItemProperty)));
            }
            set
            {
                base.SetValue(CallWorkflow.__ListItemProperty, value);
            }
        }

        #endregion

        public static DependencyProperty WorkflowRunningProperty = DependencyProperty.Register("WorkflowRunning", typeof(bool), typeof(CallWorkflow));

        [DescriptionAttribute("WorkflowRunning")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public bool WorkflowRunning
        {
            get
            {
                return ((bool)(base.GetValue(CallWorkflow.WorkflowRunningProperty)));
            }
            set
            {
                base.SetValue(CallWorkflow.WorkflowRunningProperty, value);
            }
        }

        public static DependencyProperty CallWorkflowNameProperty = DependencyProperty.Register("CallWorkflowName", typeof(string), typeof(CallWorkflow));

        [DescriptionAttribute("The workflow name to be called")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string CallWorkflowName
        {
            get
            {
                return ((string)(base.GetValue(CallWorkflow.CallWorkflowNameProperty)));
            }
            set
            {
                base.SetValue(CallWorkflow.CallWorkflowNameProperty, value);
            }
        }

        private void SetWorkflowStatusCode(object sender, EventArgs e)
        {
            WorkflowRunning = true;
        }

        private void SetLogMsgCode(object sender, EventArgs e)
        {
            logStartCall.HistoryDescription = "'CallWorkflow' starting on '" + CallWorkflowName + "'";
            logCallFinished.HistoryDescription = "'CallWorkflow finished. Workflow '" + CallWorkflowName + "' has finished";
        }
    }
}
