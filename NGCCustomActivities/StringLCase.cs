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

namespace NGCCustomActivities
{
	public partial class StringLCase: SequenceActivity
	{
		public StringLCase()
		{
			InitializeComponent();
		}

        public static DependencyProperty TheStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheString", typeof(string), typeof(StringLCase));

        [Description("The string to be converted to lower case")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheString
        {
            get
            {
                return ((string)(base.GetValue(StringLCase.TheStringProperty)));
            }
            set
            {
                base.SetValue(StringLCase.TheStringProperty, value);
            }
        }
        public static DependencyProperty TheLCaseStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheLCaseString", typeof(string), typeof(StringLCase));

        [Description("The Lower Case version of the string")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheLCaseString
        {
            get
            {
                return ((string)(base.GetValue(StringLCase.TheLCaseStringProperty)));
            }
            set
            {
                base.SetValue(StringLCase.TheLCaseStringProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                if (TheString == null)
                {
                    TheLCaseString = null;
                }
                else
                {
                    TheLCaseString = TheString.ToLower();
                }
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                string sMsg = "Returning the upper case of string '" + this.TheString + "' returned an exception:" + ex.Message;
                TraceProvider.TraceException("StringLCase", sMsg);
                throw new Exception(sMsg);
            }
        }
	}
}
