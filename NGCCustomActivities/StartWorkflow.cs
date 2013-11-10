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
    public partial class StartWorkflow : SequenceActivity
    {
        public StartWorkflow()
        {
            InitializeComponent();
        }

        #region Standard Dependency Properties
        public static DependencyProperty __ContextProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__Context",
            typeof(WorkflowContext), typeof(StartWorkflow));

        [Description("Context")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public WorkflowContext __Context
        {
            get
            {
                return ((WorkflowContext)(base.GetValue(StartWorkflow.__ContextProperty)));
            }
            set
            {
                base.SetValue(StartWorkflow.__ContextProperty, value);
            }
        }

        public static DependencyProperty __ListIdProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListId",
            typeof(string), typeof(StartWorkflow));

        [Description("List Id")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string __ListId
        {
            get
            {
                return ((string)(base.GetValue(StartWorkflow.__ListIdProperty)));
            }
            set
            {
                base.SetValue(StartWorkflow.__ListIdProperty, value);
            }
        }

        public static DependencyProperty __ListItemProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListItem",
            typeof(int), typeof(StartWorkflow));

        [Description("List Item")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int __ListItem
        {
            get
            {
                return ((int)(base.GetValue(StartWorkflow.__ListItemProperty)));
            }
            set
            {
                base.SetValue(StartWorkflow.__ListItemProperty, value);
            }
        }

        #endregion

        public static DependencyProperty WorkflowNameProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("WorkflowName",
            typeof(string), typeof(StartWorkflow));

        [Description("The WorkFlow started by this Action")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string WorkflowName
        {
            get
            {
                return ((string)(base.GetValue(StartWorkflow.WorkflowNameProperty)));
            }
            set
            {
                base.SetValue(StartWorkflow.WorkflowNameProperty, value);
            }
        }

        private void DoStartWorfklowCode(object sender, EventArgs e)
        {
            try
            {
                WorkflowContext wfc = __Context;
                SPSite site = wfc.Site;
                SPWeb web = wfc.Web;
                SPList list = web.Lists[new Guid(__ListId)];
                SPWorkflowAssociation workflow = list.WorkflowAssociations.GetAssociationByName(this.WorkflowName, System.Globalization.CultureInfo.CurrentCulture);
                if (workflow == null)
                {
                    string sMsg = "Workflow '" + this.WorkflowName + "' does not exist or could not be loaded.";
                    throw new Exception(sMsg);
                }
                SPListItem item = wfc.GetListItem(list, __ListItem);
                SPWorkflowManager workflowManager = site.WorkflowManager;

                SPWorkflow startedWorkflow = workflowManager.StartWorkflow(item, workflow, workflow.AssociationData);
                if (startedWorkflow == null)
                {
                    string sMsg = "Workflow '" + this.WorkflowName + "' could not be started.";
                    throw new Exception(sMsg);
                }
                LogFinished.HistoryDescription = "Workflow '" + this.WorkflowName + "' started successfully";
            }
            catch (Exception ex)
            {
                string sMsg;
                if (ex.Message.Contains("0x8102009B"))
                    sMsg = "The Workflow is already running. Note a Workflow cannot start itself. Workflow:'" + this.WorkflowName + "' Exception: " + ex.Message;
                else
                    sMsg = "Workflow '" + this.WorkflowName + "' generated an exception:" + ex.Message;
                TraceProvider.TraceException("StartWorkflow", sMsg);
                LogFinished.HistoryDescription = "Error starting workflow with 'StartWorkflow': " + sMsg;
            }
        }

        private void InitStartCode(object sender, EventArgs e)
        {
            LogStart.HistoryDescription = "Starting workflow '" + this.WorkflowName + "'";
        }
    }
}
