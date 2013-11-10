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
    public partial class StringUCase : SequenceActivity
    {
        public StringUCase()
        {
            InitializeComponent();
        }

        public static DependencyProperty TheStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheString", typeof(string), typeof(StringUCase));

        [Description("The string to be converted to upper case")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheString
        {
            get
            {
                return ((string)(base.GetValue(StringUCase.TheStringProperty)));
            }
            set
            {
                base.SetValue(StringUCase.TheStringProperty, value);
            }
        }
        public static DependencyProperty TheUCaseStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheUCaseString", typeof(string), typeof(StringUCase));

        [Description("The Upper Case version of the string")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheUCaseString
        {
            get
            {
                return ((string)(base.GetValue(StringUCase.TheUCaseStringProperty)));
            }
            set
            {
                base.SetValue(StringUCase.TheUCaseStringProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                if (TheString == null)
                {
                    TheUCaseString = null;
                }
                else
                {
                    TheUCaseString = TheString.ToUpper();
                }
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                string sMsg = "Returning the upper case of string '" + this.TheString + "' returned an exception:" + ex.Message;
                TraceProvider.TraceException("StringUCase", sMsg);
                throw new Exception(sMsg);
            }
        }
    }
}
