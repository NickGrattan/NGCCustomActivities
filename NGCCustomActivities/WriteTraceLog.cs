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
    public partial class WriteTraceLog : SequenceActivity
    {
        public WriteTraceLog()
        {
            InitializeComponent();
        }

        public static DependencyProperty ProcessProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("Process",
            typeof(string), typeof(WriteTraceLog));

        [Description("The process owning the workflow")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Process
        {
            get
            {
                return ((string)(base.GetValue(WriteTraceLog.ProcessProperty)));
            }
            set
            {
                base.SetValue(WriteTraceLog.ProcessProperty, value);
            }
        }

        public static DependencyProperty AreaProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("Area",
            typeof(string), typeof(WriteTraceLog));

        [Description("The functional area performing the log")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Area
        {
            get
            {
                return ((string)(base.GetValue(WriteTraceLog.AreaProperty)));
            }
            set
            {
                base.SetValue(WriteTraceLog.AreaProperty, value);
            }
        }

        public static DependencyProperty CategoryProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("Category",
            typeof(string), typeof(WriteTraceLog));

        [Description("Logging category")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Category
        {
            get
            {
                return ((string)(base.GetValue(WriteTraceLog.CategoryProperty)));
            }
            set
            {
                base.SetValue(WriteTraceLog.CategoryProperty, value);
            }
        }

        public static DependencyProperty MessageProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("Message",
            typeof(string), typeof(WriteTraceLog));

        [Description("Logging category")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Message
        {
            get
            {
                return ((string)(base.GetValue(WriteTraceLog.MessageProperty)));
            }
            set
            {
                base.SetValue(WriteTraceLog.MessageProperty, value);
            }
        }

        public static DependencyProperty LevelProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("Level",
            typeof(string), typeof(WriteTraceLog));

        [Description("The process owning the workflow")]
        [Category("NGC Custom Activities")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Level
        {
            get
            {
                return ((string)(base.GetValue(WriteTraceLog.LevelProperty)));
            }
            set
            {
                base.SetValue(WriteTraceLog.LevelProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                TraceProvider.RegisterTraceProvider();
                TraceProvider.TraceSeverity tc;
                switch (this.Level)
                {
                    case "0":
                        tc = TraceProvider.TraceSeverity.Unassigned;
                        break;
                    case "1":
                        tc = TraceProvider.TraceSeverity.CriticalEvent;
                        break;
                    case "2":
                        tc = TraceProvider.TraceSeverity.WarningEvent;
                        break;
                    case "3":
                        tc = TraceProvider.TraceSeverity.InformationEvent;
                        break;
                    case "4":
                        tc = TraceProvider.TraceSeverity.Exception;
                        break;
                    case "7":
                        tc = TraceProvider.TraceSeverity.Assert;
                        break;
                    case "10":
                        tc = TraceProvider.TraceSeverity.Unexpected;
                        break;
                    case "15":
                        tc = TraceProvider.TraceSeverity.Monitorable;
                        break;
                    case "20":
                        tc = TraceProvider.TraceSeverity.High;
                        break;
                    case "50":
                        tc = TraceProvider.TraceSeverity.Medium;
                        break;
                    case "100":
                        tc = TraceProvider.TraceSeverity.Verbose;
                        break;
                    default:
                        tc = TraceProvider.TraceSeverity.Medium;
                        break;
                }
                TraceProvider.WriteTrace(0, tc, Guid.Empty, 
                    this.Process, this.Area, this.Category, this.Message);
                TraceProvider.UnregisterTraceProvider();
                return ActivityExecutionStatus.Closed;
            }
            catch (Exception ex)
            {
                TraceProvider.TraceException("WriteTraceLog", "Error writing to tracelog: " + ex.Message);
                throw ex;
            }
        }
    }
}
