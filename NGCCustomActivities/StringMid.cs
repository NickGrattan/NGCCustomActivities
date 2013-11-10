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
	public partial class StringMid: SequenceActivity
	{
		public StringMid()
		{
			InitializeComponent();
		}
        public static DependencyProperty TheStringProperty = 
            System.Workflow.ComponentModel.DependencyProperty.Register("TheString", 
            typeof(string), typeof(StringMid));

        [Description("The string from which a mid string will be returned")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheString
        {
            get
            {
                return ((string)(base.GetValue(StringMid.TheStringProperty)));
            }
            set
            {
                base.SetValue(StringMid.TheStringProperty, value);
            }
        }

        public static DependencyProperty TheStartProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("TheStart",
            typeof(Double), typeof(StringMid));

        [Description("The start position")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Double TheStart
        {
            get
            {
                return ((Double)(base.GetValue(StringMid.TheStartProperty)));
            }
            set
            {
                base.SetValue(StringMid.TheStartProperty, value);
            }
        }

        public static DependencyProperty TheCountProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("TheCount", 
            typeof(Double), typeof(StringMid));

        [Description("The number of characters to return")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Double TheCount
        {
            get
            {
                return ((Double)(base.GetValue(StringMid.TheCountProperty)));
            }
            set
            {
                base.SetValue(StringMid.TheCountProperty, value);
            }
        }

        public static DependencyProperty TheMidStringProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("TheMidString", 
            typeof(string), typeof(StringMid));

        [Description("The returned, mid, string")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheMidString
        {
            get
            {
                return ((string)(base.GetValue(StringMid.TheMidStringProperty)));
            }
            set
            {
                base.SetValue(StringMid.TheMidStringProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                if (String.IsNullOrEmpty(TheString))
                {
                    throw new Exception("The string for 'Mid' is empty");
                }
                int len = Convert.ToInt32(TheCount);
                int start = Convert.ToInt32(TheStart);

                if (start <= 0)
                {
                    throw new Exception("The 'Start' for 'Mid' is less than or equal to zero");
                }
                if (start > TheString.Length)
                {
                    throw new Exception("The 'Start' for 'Mid' is greater than the length of the string");
                }
                if (start + len > TheString.Length)
                {
                    TheMidString = TheString.Substring(start - 1);
                }
                else
                {
                    TheMidString = TheString.Substring(start - 1, len);
                }
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                string sMsg = "Returning 'Mid' (" + TheStart.ToString() + "," +
                    TheCount.ToString() + ") of string '" + this.TheString + 
                    "' returned an exception:" + ex.Message;
                TraceProvider.TraceException("StringMid", sMsg);
                throw new Exception(sMsg);
            }
        }
    }
}
