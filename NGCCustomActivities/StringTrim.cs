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
    public partial class StringTrim : SequenceActivity
    {
        public StringTrim()
        {
            InitializeComponent();
        }

        public static DependencyProperty TheStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheString", typeof(string), typeof(StringTrim));

        [Description("The string to be trimmed")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheString
        {
            get
            {
                return ((string)(base.GetValue(StringTrim.TheStringProperty)));
            }
            set
            {
                base.SetValue(StringTrim.TheStringProperty, value);
            }
        }
        public static DependencyProperty TheTrimStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheTrimString", typeof(string), typeof(StringTrim));

        [Description("The Lower Case version of the string")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheTrimString
        {
            get
            {
                return ((string)(base.GetValue(StringTrim.TheTrimStringProperty)));
            }
            set
            {
                base.SetValue(StringTrim.TheTrimStringProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                if (TheString == null)
                {
                    TheTrimString = null;
                }
                else
                {
                    TheTrimString = TheString.Trim();
                }
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                string sMsg = "Returning a trimmed string '" + this.TheString + "' returned an exception:" + ex.Message;
                TraceProvider.TraceException("StringTrim", sMsg);
                throw new Exception(sMsg);
            }
        }
    }
}
