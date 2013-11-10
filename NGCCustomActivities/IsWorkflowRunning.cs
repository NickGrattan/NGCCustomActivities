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
    public partial class IsWorkflowRunning : SequenceActivity
    {
        public IsWorkflowRunning()
        {
            InitializeComponent();
        }


        #region Standard Dependency Properties
        public static DependencyProperty __ContextProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__Context",
            typeof(WorkflowContext), typeof(IsWorkflowRunning));

        [Description("Context")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public WorkflowContext __Context
        {
            get
            {
                return ((WorkflowContext)(base.GetValue(IsWorkflowRunning.__ContextProperty)));
            }
            set
            {
                base.SetValue(IsWorkflowRunning.__ContextProperty, value);
            }
        }

        public static DependencyProperty __ListIdProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListId",
            typeof(string), typeof(IsWorkflowRunning));

        [Description("List Id")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string __ListId
        {
            get
            {
                return ((string)(base.GetValue(IsWorkflowRunning.__ListIdProperty)));
            }
            set
            {
                base.SetValue(IsWorkflowRunning.__ListIdProperty, value);
            }
        }

        public static DependencyProperty __ListItemProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListItem",
            typeof(int), typeof(IsWorkflowRunning));

        [Description("List Item")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int __ListItem
        {
            get
            {
                return ((int)(base.GetValue(IsWorkflowRunning.__ListItemProperty)));
            }
            set
            {
                base.SetValue(IsWorkflowRunning.__ListItemProperty, value);
            }
        }

        #endregion

        public static DependencyProperty WorkflowRunningProperty = DependencyProperty.Register("WorkflowRunning",
                        typeof(Boolean), typeof(IsWorkflowRunning));

        [DescriptionAttribute("WorkflowRunning")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public Boolean WorkflowRunning
        {
            get
            {
                return ((Boolean)(base.GetValue(IsWorkflowRunning.WorkflowRunningProperty)));
            }
            set
            {
                base.SetValue(IsWorkflowRunning.WorkflowRunningProperty, value);
            }
        }

        public static DependencyProperty TestWorkflowNameProperty = DependencyProperty.Register("TestWorkflowName", typeof(string), typeof(IsWorkflowRunning));

        [DescriptionAttribute("The workflow name being tested")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string TestWorkflowName
        {
            get
            {
                return ((string)(base.GetValue(IsWorkflowRunning.TestWorkflowNameProperty)));
            }
            set
            {
                base.SetValue(IsWorkflowRunning.TestWorkflowNameProperty, value);
            }
        }

        private void CodeTestWorkflowRunning(object sender, EventArgs e)
        {
            try
            {
                WorkflowContext wfc = __Context;
                SPSite site = wfc.Site;
                SPWeb web = wfc.Web;
                SPList list = web.Lists[new Guid(__ListId)];
                SPListItem item = wfc.GetListItem(list, __ListItem);

                SPWorkflowManager workflowManager = site.WorkflowManager;
                SPWorkflowCollection workflowsForItem = workflowManager.GetItemActiveWorkflows(item);
                WorkflowRunning = false;
                foreach (SPWorkflow spw in workflowsForItem)
                {
                    //TraceProvider.TraceException("IsWorkflowRunning", "Found workflow: " + spw.ParentAssociation.Name +
                    //         " testing against " + TestWorkflowName);
                    if (spw.ParentAssociation != null && spw.ParentAssociation.Name == TestWorkflowName)
                    {
                        if (spw.IsCompleted)
                        {
                            //TraceProvider.TraceException("IsWorkflowRunning", "Completed");
                            WorkflowRunning = false;
                        }
                        else
                        {
                            //TraceProvider.TraceException("IsWorkflowRunning", "Still running");
                            WorkflowRunning = true;
                        }
                        break;
                    }
                }
                logWorkflow.HistoryDescription = "IsWorkflowRunning testing '" + TestWorkflowName +
                    "'. Workflow running = " + WorkflowRunning.ToString();
            }
            catch (Exception ex)
            {
                string sMsg;
                sMsg = "Error checking if Workflow '" + TestWorkflowName + "' is running; generated an exception:" + ex.Message;
                TraceProvider.TraceException("IsWorkflowRunning", sMsg);
                logWorkflow.HistoryDescription = "IsWorkflowRunning caused an error: " + sMsg;
                throw ex;
            }
        }
    }
}
