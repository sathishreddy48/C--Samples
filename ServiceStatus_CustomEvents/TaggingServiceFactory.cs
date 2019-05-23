using EC.CPLA.DELTA.CD.Model.Enum;
using EC.CPLA.DELTA.CD.Repository.Interfaces;
using EC.CPLA.DELTA.CD.Repository.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EC.CPLA.DELTA.CD.Repository.Factories
{
    public interface ITaggingServiceFactory
    {
        void TagScriptsToReleaseVehicle();

        void AddTaggingNotificationRecord();
    }
    public class TaggingServiceFactory : BaseFactory, ITaggingServiceFactory
    {
        public ILog LoggerService;
        public TaggingServiceFactory(ILog TaggingLoggerService) : base(TaggingLoggerService)
        {
            LoggerService = TaggingLoggerService;
        }
        public void TagScriptsToReleaseVehicle()
        {
            try
            {
                DataTable tagScripts = new DataTable();
                tagScripts.Columns.Add("NoSoonerThan", typeof(DateTime));
                tagScripts.Columns.Add("NoLaterThan", typeof(DateTime));
                tagScripts.Columns.Add("ReleaseID", typeof(int));
                tagScripts.Columns.Add("ReleaseName", typeof(string));
                tagScripts.Columns.Add("ReleaseStartDate", typeof(DateTime));
                tagScripts.Columns.Add("ReleaseEndDate", typeof(DateTime));
                tagScripts.Columns.Add("TechnicalSignoffID", typeof(int));
                tagScripts.Columns.Add("TechnicalSignoffstartdate", typeof(DateTime));
                tagScripts.Columns.Add("TechnicalSignoffEnddate", typeof(DateTime));
                tagScripts.Columns.Add("ReleaseType", typeof(string));
                                

                DataSet dataSet = new DataSet();
                SqlUtilities sqlHelper = new SqlUtilities(new SqlConnection(ConfigurationManager.AppSettings["DSConnectionString"]));
                dataSet = sqlHelper.GetDataSet("TaggingService_GetNotTaggedScripts");

                if (dataSet.Tables[0] != null && dataSet.Tables[0].Rows.Count > 0)
                {
                    SqlUtilities DOMOSQLHelper = new SqlUtilities(new SqlConnection(ConfigurationManager.AppSettings["DOMOAutomationConnectionString"]));
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        DataSet dsReleaseCalendarDetails = DOMOSQLHelper.GetDataSet("GetReleaseCalendarEventDates",
                                                    new List<CommandParameter> {
                                                    new CommandParameter{Name="NoSoonerDate", Type=SqlDbType.DateTime, Value = row["NoSoonerThan"].ToString()},
                                                    new CommandParameter{Name="NoLongerDate", Type=SqlDbType.DateTime, Value = row["NoLaterThan"].ToString()}
                                                    });
                        if(dsReleaseCalendarDetails != null && dsReleaseCalendarDetails.Tables[0] != null && dsReleaseCalendarDetails.Tables[0].Rows.Count > 0 && dsReleaseCalendarDetails.Tables[0].Rows[0]["ReleaseType"].ToString() != "101")
                        {
                            tagScripts.Rows.Add(row["NoSoonerThan"].ToString(),
                                            row["NoLaterThan"].ToString(),
                                            Convert.ToInt32(dsReleaseCalendarDetails.Tables[0].Rows[0]["ReleaseID"]),
                                            dsReleaseCalendarDetails.Tables[0].Rows[0]["ReleaseName"].ToString(),
                                            Convert.ToDateTime(dsReleaseCalendarDetails.Tables[0].Rows[0]["ReleaseStartDate"]),
                                            Convert.ToDateTime(dsReleaseCalendarDetails.Tables[0].Rows[0]["ReleaseEndDate"]),
                                            Convert.ToInt32(dsReleaseCalendarDetails.Tables[0].Rows[0]["TechnicalSignoffID"]),
                                            Convert.ToDateTime(dsReleaseCalendarDetails.Tables[0].Rows[0]["TechnicalSignoffstartdate"]),
                                            Convert.ToDateTime(dsReleaseCalendarDetails.Tables[0].Rows[0]["TechnicalSignoffEnddate"]),
                                            dsReleaseCalendarDetails.Tables[0].Rows[0]["ReleaseType"].ToString());
                        }
                        else
                        {

                            tagScripts.Rows.Add(row["NoSoonerThan"].ToString(),
                                            row["NoLaterThan"].ToString(),
                                            null,
                                            null,
                                            null,
                                            null,
                                            null,
                                            null,
                                            null,
                                            dsReleaseCalendarDetails != null && dsReleaseCalendarDetails.Tables[0] != null && dsReleaseCalendarDetails.Tables[0].Rows.Count > 0 
                                                        ? dsReleaseCalendarDetails.Tables[0].Rows[0]["ReleaseType"].ToString() : null);                           
                        }
                    }

                    if (tagScripts.Rows.Count > 0)
                    {
                        sqlHelper.ExecuteNonQuery("TaggingService_TagScriptsToReleaseVehicle", 
                                                    new List<CommandParameter> {
                                                        new CommandParameter { Name = "ReleaseCalendarDetails", Type = SqlDbType.Structured, Value = tagScripts } });
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        public void AddTaggingNotificationRecord()
        {
            try
            {
                SqlUtilities sqlHelper = new SqlUtilities(new SqlConnection(ConfigurationManager.AppSettings["DSConnectionString"]));
                sqlHelper.ExecuteNonQuery("TaggingService_AddTaggingNotificationDetails");
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void LogException(Exception exception)
        {
            try
            {
                SqlUtilities sqlHelper = new SqlUtilities(new SqlConnection(ConfigurationManager.AppSettings["DSConnectionString"]));
                sqlHelper.LogExceptionToDB(LogType.WindowsService, exception.Message, exception.StackTrace);
            }
            catch (Exception DBException)
            {
                try
                {
                    LoggerService.LogError("DBException: " + DBException.ToString() + Environment.NewLine);
                }
                catch
                {

                }
            }

            try
            {
                LoggerService.LogError("Exception: " + exception.ToString());
            }
            catch (Exception LoggerException)
            {
                try
                {
                    SqlUtilities sqlHelper = new SqlUtilities(new SqlConnection(ConfigurationManager.AppSettings["DSConnectionString"]));
                    sqlHelper.LogExceptionToDB(LogType.WindowsService, LoggerException.Message, LoggerException.StackTrace);
                }
                catch
                {

                }
            }
        }
    }
}
