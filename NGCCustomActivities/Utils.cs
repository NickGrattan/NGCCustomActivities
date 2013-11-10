using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace NGCCustomActivities
{
	class Utils
	{

        public static void WriteToHistory(SPWorkflowActivationProperties ap, string note)
        {
            SPWorkflow.CreateHistoryEvent(ap.Web,
                        ap.WorkflowId, 0,
                        ap.OriginatorUser,
                        new TimeSpan(0), "", note, "");
        }
	}
}
