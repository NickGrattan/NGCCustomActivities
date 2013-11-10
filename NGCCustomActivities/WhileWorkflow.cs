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
    public partial class WhileWorkflow : SequenceActivity
    {
        public WhileWorkflow()
        {
            InitializeComponent();
        }

        #region Standard Dependency Properties
        public static DependencyProperty __ContextProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__Context",
            typeof(WorkflowContext), typeof(WhileWorkflow));

        [Description("Context")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public WorkflowContext __Context
        {
            get
            {
                return ((WorkflowContext)(base.GetValue(WhileWorkflow.__ContextProperty)));
            }
            set
            {
                base.SetValue(WhileWorkflow.__ContextProperty, value);
            }
        }

        public static DependencyProperty __ListIdProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListId",
            typeof(string), typeof(WhileWorkflow));

        [Description("List Id")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string __ListId
        {
            get
            {
                return ((string)(base.GetValue(WhileWorkflow.__ListIdProperty)));
            }
            set
            {
                base.SetValue(WhileWorkflow.__ListIdProperty, value);
            }
        }

        public static DependencyProperty __ListItemProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("__ListItem",
            typeof(int), typeof(WhileWorkflow));

        [Description("List Item")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int __ListItem
        {
            get
            {
                return ((int)(base.GetValue(WhileWorkflow.__ListItemProperty)));
            }
            set
            {
                base.SetValue(WhileWorkflow.__ListItemProperty, value);
            }
        }

        #endregion

        public static DependencyProperty WorkflowRunningProperty = DependencyProperty.Register("WorkflowRunning", typeof(bool), typeof(WhileWorkflow));

        [DescriptionAttribute("WorkflowRunning")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public bool WorkflowRunning
        {
            get
            {
                return ((bool)(base.GetValue(WhileWorkflow.WorkflowRunningProperty)));
            }
            set
            {
                base.SetValue(WhileWorkflow.WorkflowRunningProperty, value);
            }
        }

        public static DependencyProperty WhileWorkflowNameProperty =
            DependencyProperty.Register("WhileWorkflowName", typeof(string), typeof(WhileWorkflow));

        [DescriptionAttribute("The workflow name to be called")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string WhileWorkflowName
        {
            get
            {
                return ((string)(base.GetValue(WhileWorkflow.WhileWorkflowNameProperty)));
            }
            set
            {
                base.SetValue(WhileWorkflow.WhileWorkflowNameProperty, value);
            }
        }

        public static DependencyProperty WhileFieldProperty =
            DependencyProperty.Register("WhileField", typeof(string), typeof(WhileWorkflow));

        [DescriptionAttribute("The field to test")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string WhileField
        {
            get
            {
                return ((string)(base.GetValue(WhileWorkflow.WhileFieldProperty)));
            }
            set
            {
                base.SetValue(WhileWorkflow.WhileFieldProperty, value);
            }
        }

        public static DependencyProperty OperatorProperty =
            DependencyProperty.Register("Operator", typeof(string), typeof(WhileWorkflow));

        [DescriptionAttribute("The operator to use")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string Operator
        {
            get
            {
                return ((string)(base.GetValue(WhileWorkflow.OperatorProperty)));
            }
            set
            {
                base.SetValue(WhileWorkflow.OperatorProperty, value);
            }
        }

        public static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(Object), typeof(WhileWorkflow));

        [DescriptionAttribute("The value to test")]
        [CategoryAttribute("NGC Custom Activities")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public Object Value
        {
            get
            {
                return ((Object)(base.GetValue(WhileWorkflow.ValueProperty)));
            }
            set
            {
                base.SetValue(WhileWorkflow.ValueProperty, value);
            }
        }

        private void DoCallWhileCondition(object sender, ConditionalEventArgs e)
        {
            try
            {
                WorkflowContext wfc = __Context;
                SPWeb web = wfc.Web;
                SPList list = web.Lists[new Guid(__ListId)];
                SPListItem item = wfc.GetListItem(list, __ListItem);

                TestCondition tc = new TestCondition(item, WhileField, Operator, Value);
                e.Result = tc.Test();
            }
            catch (Exception ex)
            {
                string sMsg = "Error in 'While Workflow':" + ex.Message;
                TraceProvider.TraceException("WhileWorkflow", sMsg);
                throw new Exception(sMsg);
            }
        }

        private void codeSetLogTextCode(object sender, EventArgs e)
        {
            logWhileHistory.HistoryDescription = "WhileWorkflow called on '" + WhileWorkflowName + "'";
        }

    }
}
