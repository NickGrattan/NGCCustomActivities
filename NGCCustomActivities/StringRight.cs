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
    public partial class StringRight : SequenceActivity
    {
        public StringRight()
        {
            InitializeComponent();
        }

        public static DependencyProperty TheStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheString", typeof(string), typeof(StringRight));

        [Description("The string from which right 'n' chars will be returned")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheString
        {
            get
            {
                return ((string)(base.GetValue(StringRight.TheStringProperty)));
            }
            set
            {
                base.SetValue(StringRight.TheStringProperty, value);
            }
        }

        public static DependencyProperty TheCountProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheCount", typeof(Double), typeof(StringRight));

        [Description("The number of characters to return")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Double TheCount
        {
            get
            {
                return ((Double)(base.GetValue(StringRight.TheCountProperty)));
            }
            set
            {
                base.SetValue(StringRight.TheCountProperty, value);
            }
        }

        public static DependencyProperty TheRightStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheRightString", typeof(string), typeof(StringRight));

        [Description("The returned, right, string")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheRightString
        {
            get
            {
                return ((string)(base.GetValue(StringRight.TheRightStringProperty)));
            }
            set
            {
                base.SetValue(StringRight.TheRightStringProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                if (String.IsNullOrEmpty(TheString))
                {
                    throw new Exception("The string for 'Right' is empty");
                }
                int len = Convert.ToInt32(TheCount);
                if (len <= 0)
                {
                    throw new Exception("The 'Count' for 'Right' is less than or equal to zero");
                }
                if (len > TheString.Length)
                {
                    TheRightString = TheString;
                }
                else
                {
                    TheRightString = TheString.Substring(TheString.Length - len, len);
                }
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                string sMsg = "Returning 'Right' (" + TheCount.ToString() + ") of string '" + this.TheString + "' returned an exception:" + ex.Message;
                TraceProvider.TraceException("StringRight", sMsg);
                throw new Exception(sMsg);
            }
        }
    }
}
