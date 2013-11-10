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
	public partial class StringPosition: SequenceActivity
	{
		public StringPosition()
		{
			InitializeComponent();
		}
        public static DependencyProperty TheStringProperty = 
            System.Workflow.ComponentModel.DependencyProperty.Register("TheString", 
            typeof(string), typeof(StringPosition));

        [Description("The string from the position of another string will be returned")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheString
        {
            get
            {
                return ((string)(base.GetValue(StringPosition.TheStringProperty)));
            }
            set
            {
                base.SetValue(StringPosition.TheStringProperty, value);
            }
        }

        public static DependencyProperty ThePositionProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("ThePosition", 
            typeof(Double), typeof(StringPosition));

        [Description("The returned string position")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Double ThePosition
        {
            get
            {
                return ((Double)(base.GetValue(StringPosition.ThePositionProperty)));
            }
            set
            {
                base.SetValue(StringPosition.ThePositionProperty, value);
            }
        }

        public static DependencyProperty TheStringToFindProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("TheStringToFind", 
            typeof(string), typeof(StringPosition));

        [Description("The string to be found")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TheStringToFind
        {
            get
            {
                return ((string)(base.GetValue(StringPosition.TheStringToFindProperty)));
            }
            set
            {
                base.SetValue(StringPosition.TheStringToFindProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                if (String.IsNullOrEmpty(TheString))
                {
                    ThePosition = -1;
                }
                if (String.IsNullOrEmpty(TheStringToFind))
                {
                    ThePosition = -1;
                }
                if (TheStringToFind.Length > TheString.Length)
                {
                    ThePosition = -1;
                }
                else 
                {
                    ThePosition = TheString.ToUpper().IndexOf(TheStringToFind.ToUpper()) + 1;
                }
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                string sMsg = "Returning Position of '" + TheStringToFind + "' in string '" + TheString 
                    + "' returned an exception:" + ex.Message;
                TraceProvider.TraceException("StringPostion", sMsg);
                throw new Exception(sMsg);
            }
        }
    }
}
