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
    public partial class HaltWorkflow : SequenceActivity
    {
        public HaltWorkflow()
        {
            InitializeComponent();
        }

        #region Standard Dependency Properties
        public static DependencyProperty __ContextProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__Context",
            typeof(WorkflowContext), typeof(HaltWorkflow));

        [Description("Context")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public WorkflowContext __Context
        {
            get
            {
                return ((WorkflowContext)(base.GetValue(HaltWorkflow.__ContextProperty)));
            }
            set
            {
                base.SetValue(HaltWorkflow.__ContextProperty, value);
            }
        }

        public static DependencyProperty __ListIdProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListId",
            typeof(string), typeof(HaltWorkflow));

        [Description("List Id")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string __ListId
        {
            get
            {
                return ((string)(base.GetValue(HaltWorkflow.__ListIdProperty)));
            }
            set
            {
                base.SetValue(HaltWorkflow.__ListIdProperty, value);
            }
        }

        public static DependencyProperty __ListItemProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListItem",
            typeof(int), typeof(HaltWorkflow));

        [Description("List Item")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int __ListItem
        {
            get
            {
                return ((int)(base.GetValue(HaltWorkflow.__ListItemProperty)));
            }
            set
            {
                base.SetValue(HaltWorkflow.__ListItemProperty, value);
            }
        }

        #endregion

        public static DependencyProperty WorkflowNameProperty = DependencyProperty.Register("WorkflowName", typeof(string), typeof(HaltWorkflow));

        [DescriptionAttribute("The workflow name to be halted")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string WorkflowName
        {
            get
            {
                return ((string)(base.GetValue(HaltWorkflow.WorkflowNameProperty)));
            }
            set
            {
                base.SetValue(HaltWorkflow.WorkflowNameProperty, value);
            }
        }

        private bool isWorkflowRunning;

        public bool IsWorkflowRunning
        {
            get { return isWorkflowRunning; }
            set { isWorkflowRunning = value; }
        }

        private void DoHaltWorkflowCode(object sender, EventArgs e)
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
                foreach (SPWorkflow spw in workflowsForItem)
                {
                    //TraceProvider.TraceException("HaltWorkflow", "Found workflow: " + spw.ParentAssociation.Name +
                    //         " testing against " + WorkflowName);
                    if (spw.ParentAssociation.Name == WorkflowName)
                    {
                        if (!spw.IsCompleted)
                        {
                            SPWorkflowManager.CancelWorkflow(spw);
                            // TraceProvider.TraceException("HaltWorkflow", "Completed");
                            LogHalt.HistoryDescription = "HaltWorkflow cancelling '" + WorkflowName + "'";
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string sMsg;
                sMsg = "Error: Halting Workflow '" + WorkflowName + "' generated an exception:" + ex.Message;
                TraceProvider.TraceException("HaltWorkflow", sMsg);
                LogHalt.HistoryDescription = "HaltWorkflow caused an error: " + sMsg;
                throw ex;
            }
        }

        private void WarnNotRunningCode(object sender, EventArgs e)
        {
            string sMsg;
            sMsg = "Warning halting workflow; '" + WorkflowName + "' is not running";
            TraceProvider.TraceWarning("HaltWorkflow", sMsg);
            LogHalt.HistoryDescription = "HaltWorkflow: " + sMsg;
        }

    }
}
