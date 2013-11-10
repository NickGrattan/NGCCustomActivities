using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace NGCCustomActivities
{
    class NGCCustomActivitiesER : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            try
            {
                TraceProvider.TraceWarning("NGCCustomActivities", "Feature Installing");
                UpdateWebConfig(properties, false);
            }
            catch (Exception ex)
            {
                TraceProvider.TraceException("NGCActivities", "Exception installing feature: " + ex.Message);
                throw ex;
            }
        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
            try
            {
                TraceProvider.TraceWarning("NGCCustomActivities", "Feature Uninstalling");
                UpdateWebConfig(properties, true);
            }
            catch (Exception ex)
            {
                TraceProvider.TraceException("NGCActivities", "Exception uninstalling feature: " + ex.Message);
                throw ex;
            }
        }

        private void UpdateWebConfig(SPFeatureReceiverProperties properties, bool remove)
        {
            try
            {
                SPWebServiceCollection webServices = new SPWebServiceCollection(SPFarm.Local);
                foreach (SPWebService webService in webServices)
                {
                    foreach (SPWebApplication webApp in webService.WebApplications)
                    {
                        if (webApp.IsAdministrationWebApplication)
                            continue;       // don't install on central administration
                        if(!remove)
                            TraceProvider.TraceWarning("NGCCustomActivities", "Adding 'authorizedType' for NGCCustomActivities to " + webApp.Name);
                        else
                            TraceProvider.TraceWarning("NGCCustomActivities", "Removing 'authorizedType' for NGCCustomActivities to " + webApp.Name);

                        SPWebConfigModification authorizedTypeActivity = GetAuthorizedTypeConfigNode(
                            "NGCCustomActivities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=55285224b77190ba",
                            "NGCCustomActivities");
                        if (authorizedTypeActivity != null)
                        {
                            if (remove)
                                webApp.WebConfigModifications.Remove(authorizedTypeActivity);   // Remove from web.config
                            else
                                webApp.WebConfigModifications.Add(authorizedTypeActivity);      // Add to web.config
                            webApp.Update(true);
                            webApp.WebService.ApplyWebConfigModifications();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TraceProvider.TraceException("NGCActivities", "Exception Updating web.config: " + ex.Message);
                throw ex;
            }
        }

        private SPWebConfigModification GetAuthorizedTypeConfigNode(string assembly, string assemblyNamespace)
        {
            SPWebConfigModification newAuthorizedType = null;

            newAuthorizedType = new SPWebConfigModification();

            newAuthorizedType.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode;
            newAuthorizedType.Name = string.Format("authorizedType[@Assembly='{0}'][@Namespace='{1}'][@TypeName='*'][@Authorized='True']", 
                            assembly, 
                            assemblyNamespace);
            newAuthorizedType.Path = "configuration/System.Workflow.ComponentModel.WorkflowCompiler/authorizedTypes";
            newAuthorizedType.Owner = assemblyNamespace;
            newAuthorizedType.Sequence = 0;
            newAuthorizedType.Value = 
                            string.Format("<authorizedType Assembly='{0}' Namespace='{1}' TypeName='*' Authorized='True' />",
                            assembly, assemblyNamespace);
            return newAuthorizedType;
        }
    }
}
