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
    public partial class RestartThisWorkflow : SequenceActivity
    {
        public RestartThisWorkflow()
        {
            InitializeComponent();
        }

        #region Standard Dependency Properties

        public static DependencyProperty __ActivationPropertiesProperty =
                    DependencyProperty.Register("__ActivationProperties",
                    typeof(Microsoft.SharePoint.Workflow.SPWorkflowActivationProperties),
                    typeof(RestartThisWorkflow));

        [Description("Activation Properties")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public SPWorkflowActivationProperties __ActivationProperties
        {
            get
            {
                return (SPWorkflowActivationProperties)base.GetValue(__ActivationPropertiesProperty);
            }

            set
            {
                base.SetValue(__ActivationPropertiesProperty, value);
            }
        }

        #endregion

        private void doRestartCode(object sender, EventArgs e)
        {
            try
            {
                SPWorkflowActivationProperties ap = __ActivationProperties;
                string name = ap.Workflow.ParentAssociation.Name;
                SPWorkflow wf = ap.Workflow;

                SPWorkflowManager workflowManager = ap.Site.WorkflowManager;
                Utils.WriteToHistory(ap, "This workflow is now being restarted by 'RestartThisWorkflow'");
                SPWorkflowManager.CancelWorkflow(wf);

                SPWorkflowAssociation workflow = ap.List.WorkflowAssociations.GetAssociationByName(name,
                                System.Globalization.CultureInfo.CurrentCulture);
                if (workflow == null)
                {
                    string sMsg = "Workflow '" + name + "' does not exist or could not be loaded.";
                    throw new Exception(sMsg);
                }
                SPWorkflow startedWorkflow = workflowManager.StartWorkflow(ap.Item, workflow, workflow.AssociationData);
                if (startedWorkflow == null)
                {
                    string sMsg = "Workflow '" + name + "' could not be started.";
                    throw new Exception(sMsg);
                }
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message;
                TraceProvider.TraceException("RestartThisWorkflow", sMsg);
                Utils.WriteToHistory(__ActivationProperties, "RestartThisWorkflow has generate an exception: " + sMsg);
                throw ex;
            }
        }

    }
}
