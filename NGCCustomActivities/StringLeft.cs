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
	public partial class StringLeft: SequenceActivity
	{
		public StringLeft()
		{
			InitializeComponent();
		}

        public static DependencyProperty TheStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheString", typeof(string), typeof(StringLeft));

        [Description("The string from which left 'n' chars will be returned")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheString
        {
            get
            {
                return ((string)(base.GetValue(StringLeft.TheStringProperty)));
            }
            set
            {
                base.SetValue(StringLeft.TheStringProperty, value);
            }
        }

        public static DependencyProperty TheCountProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheCount", typeof(Double), typeof(StringLeft));

        [Description("The number of characters to return")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Double TheCount
        {
            get
            {
                return ((Double)(base.GetValue(StringLeft.TheCountProperty)));
            }
            set
            {
                base.SetValue(StringLeft.TheCountProperty, value);
            }
        }

        public static DependencyProperty TheLeftStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheLeftString", typeof(string), typeof(StringLeft));

        [Description("The returned, left, string")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheLeftString
        {
            get
            {
                return ((string)(base.GetValue(StringLeft.TheLeftStringProperty)));
            }
            set
            {
                base.SetValue(StringLeft.TheLeftStringProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                int len = (int)TheCount;
                if (String.IsNullOrEmpty(TheString))
                {
                    throw new Exception("The string for 'Left' is empty");
                }
                if (len <= 0)
                {
                    throw new Exception("The 'Count' for 'Left' is less than or equal to zero");
                }
                if (len > TheString.Length)
                {
                    TheLeftString = TheString;
                }
                else
                {
                    TheLeftString = TheString.Substring(0, len);
                }
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                string sMsg = "Returning 'Left' (" + TheCount.ToString() + ") of string '" + this.TheString + "' returned an exception:" + ex.Message;
                TraceProvider.TraceException("StringLeft", sMsg);
                throw new Exception(sMsg);
            }
        }
    }
}
