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
	public sealed partial class SendToRecordCenter: SequenceActivity
	{
		public SendToRecordCenter()
		{
			InitializeComponent();
		}

        #region Standard Dependency Properties

        public static DependencyProperty __ActivationPropertiesProperty =
                    DependencyProperty.Register("__ActivationProperties",
                    typeof(Microsoft.SharePoint.Workflow.SPWorkflowActivationProperties),
                    typeof(SendToRecordCenter));

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

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            SPWorkflowActivationProperties ap = __ActivationProperties;
            try
            {
                string name = ap.Workflow.ParentAssociation.Name;
                SPWorkflow wf = ap.Workflow;

                Utils.WriteToHistory(ap, "Sending item to records center");
                SPListItem item = ap.Item;
                SPFile file = ap.Web.GetFile(item.Url);

                string recordSeries = item.ContentType.Name;
                string additionalInformation;
                OfficialFileResult fileResult = file.SendToOfficialFile(recordSeries, out additionalInformation);

                Utils.WriteToHistory(ap, "Sent item to records center:" + additionalInformation);
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message;
                
                Utils.WriteToHistory(ap, "Send item to records center error:" + sMsg);

                TraceProvider.TraceException("SentToRecordCenter", sMsg);
                Utils.WriteToHistory(__ActivationProperties, "SentToRecordsCenter has generate an exception: " + sMsg);
                throw ex;
            }
            return ActivityExecutionStatus.Closed;
        }
	}

}
