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
    public partial class StringLength : SequenceActivity
    {
        public StringLength()
        {
            InitializeComponent();
        }

        public static DependencyProperty TheStringProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheString", typeof(string), typeof(StringLength));

        [Description("The string whose length will be returned")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheString
        {
            get
            {
                return ((string)(base.GetValue(StringLength.TheStringProperty)));
            }
            set
            {
                base.SetValue(StringLength.TheStringProperty, value);
            }
        }

        public static DependencyProperty TheLengthProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TheLength", typeof(Double), typeof(StringLength));

        [Description("The returned length of the string")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Double TheLength
        {
            get
            {
                return ((Double)(base.GetValue(StringLength.TheLengthProperty)));
            }
            set
            {
                base.SetValue(StringLength.TheLengthProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                if (String.IsNullOrEmpty(TheString))
                {
                    TheLength = 0.0;
                }
                else
                {
                    TheLength = (Double)TheString.Length;
                }
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                string sMsg = "Returning the length of string '" + this.TheString + "' returned an exception:" + ex.Message;
                TraceProvider.TraceException("StringLength", sMsg);
                throw new Exception(sMsg);
            }
        }
    }
}
