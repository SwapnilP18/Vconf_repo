using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.IO;
using System.Diagnostics;


namespace BigBlueButtonLibrary
{
    public class BigBlueButton
    {
        clsLog objclsLog = new clsLog(AppDomain.CurrentDomain.BaseDirectory + "log.txt", 1000);

        protected ServerConfig config;
        public BigBlueButton(ServerConfig config)
        {
            this.config = config;
        }

        #region "CreateMeeting"      
        /// <summary>
        /// Creates the Meeting
        /// </summary>
        /// <param name="MeetingName">Creates the Meeting with the Specified MeetingName</param>
        /// <param name="MeetingId">Creates the Meeting with the Specified MeetingId</param>
        /// <param name="AttendeePW">Creates the Meeting with the Specified AttendeeePassword</param>
        /// <param name="moderatorPW">Creates the Meeting with the Specified ModeratorPassword</param>
        /// <returns></returns>
        public DataTable CreateMeeting(string MeetingName, string MeetingId)//, string AttendeePW, string moderatorPW)
        {
            try
            {
                string StrServerUrl = this.config.ServerUrl;
                string StrSalt = this.config.ServerSecret;
                string StrParameters = "name=" + MeetingName + "&meetingID=" + MeetingId;// + "&attendeePW=" + AttendeePW + "&moderatorPW=" + moderatorPW;
                string StrSHA1_CheckSum = ClsData.getSha1("create" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StrServerUrl + "/create?" + StrParameters + "&checksum=" + StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }
        #endregion


        #region "JoinMeeting"
        /// <summary>
        /// To Join in the Existing Meeting
        /// </summary>
        /// <param name="MeetingName">To Join in the ExistingMeeting with the Specified MeetingName</param>
        /// <param name="MeetingId">To Join in the ExistingMeeting with the Specified MeetingId</param>
        /// <param name="Password">To Join in the ExistingMeeting with the Specified ModeratorPW/AttendeePW</param>
        /// <param name="ShowInBrowser">If its true,will Show the Meeting UI inatt the Browser </param>
        /// <returns></returns>
        public string JoinMeeting(string UserName, string MeetingId, bool ShowInBrowser = true)//, string Password, bool ShowInBrowser = false)
        {
            try
            {
                string StrServerUrl = this.config.ServerUrl;
                string StrSalt = this.config.ServerSecret;
                string StrParameters = "fullName=" + UserName + "&meetingID=" + MeetingId + "&redirect=true"; //"&password=" + Password + "&redirect=true";
                string StrSHA1_CheckSum =  ClsData.getSha1("join" + StrParameters + StrSalt);
                if (!ShowInBrowser)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StrServerUrl + "/bigbluebutton/api/join?" + StrParameters + "&checksum=" + StrSHA1_CheckSum);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    return sr.ReadToEnd();
                }
                else
                {
                    return StrServerUrl + "/join?" + StrParameters + "&checksum=" + StrSHA1_CheckSum;
                }
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }
        #endregion


        #region "IsMeetingRunning"
        /// <summary>
        /// To find the Status of the Existing Meeting
        /// </summary>
        /// <param name="MeetingId">To find the Status of the Existing Meeting with the Specified MeetingId</param>
        /// <returns></returns>
        public DataTable IsMeetingRunning(string MeetingId)
        {
            try
            {
                string StrServerUrl = this.config.ServerUrl;
                string StrSalt = this.config.ServerSecret;
                string StrParameters = "meetingID=" + MeetingId;
                string StrSHA1_CheckSum = ClsData.getSha1("isMeetingRunning" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StrServerUrl + "/bigbluebutton/api/isMeetingRunning?" + StrParameters + "&checksum=" + StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }
        #endregion


        #region "GetMeetingInfo"
        /// <summary>
        /// To Get the relavant information about the Meeting
        /// </summary>
        /// <param name="MeetingId">To Get the relavant information about the Meeting with the Specified MeetingId</param>
        /// <param name="ModeratorPassword">To Get the relavant information about the Meeting with the Specified ModeratorPW</param>
        /// <returns></returns>
        public DataTable GetMeetingInfo(string MeetingId, string ModeratorPassword)
        {
            try
            {
                string StrServerUrl = this.config.ServerUrl;
                string StrSalt = this.config.ServerSecret;
                string StrParameters = "meetingID=" + MeetingId + "&password=" + ModeratorPassword;
                string StrSHA1_CheckSum = ClsData.getSha1("getMeetingInfo" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StrServerUrl + "/bigbluebutton/api/getMeetingInfo?" + StrParameters + "&checksum=" + StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }
        #endregion


        #region "EndMeeting"
        /// <summary>
        /// To End the Meeting
        /// </summary>
        /// <param name="MeetingId">To End the Meeting with the Specified MeetingId</param>
        /// <param name="ModeratorPassword">To End the Meeting with the Specified ModeratorPW</param>
        /// <returns></returns>
        public DataTable EndMeeting(string MeetingId, string ModeratorPassword)
        {
            try
            {
                string StrServerUrl = this.config.ServerUrl;
                string StrSalt = this.config.ServerSecret;
                string StrParameters = "meetingID=" + MeetingId + "&password=" + ModeratorPassword;
                string StrSHA1_CheckSum = ClsData.getSha1("end" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StrServerUrl + "/bigbluebutton/api/end?" + StrParameters + "&checksum=" + StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }
        #endregion


        #region "getMeetings"
        /// <summary>
        /// To Get all the Meeting's Information running in the Server
        /// </summary>
        /// <returns></returns>
        public DataTable getMeetings()
        {
            try
            {
                string StrServerUrl = this.config.ServerUrl;
                string StrSalt = this.config.ServerSecret;
                Random r = new Random(0);
                string StrParameters = "random=" + r.Next(100).ToString();
                string StrSHA1_CheckSum = ClsData.getSha1("getMeetings" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StrServerUrl + "/bigbluebutton/api/getMeetings?" + StrParameters + "&checksum=" + StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }
        #endregion

    }
}
