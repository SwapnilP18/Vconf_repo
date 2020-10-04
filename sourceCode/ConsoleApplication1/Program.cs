using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigBlueButtonLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.Net;


class Program
{


    static void Main(string[] args)
    {

        DataTable dt = new DataTable();
        var serverConfig = new ServerConfig() { ServerUrl = "https://meetnxt.com/bigbluebutton/api", ServerSecret = "LW428BJRRGlXa4HNeCST4ydjwGiBHczcCWpLKsaE" };
        var ObjBigBlueButton = new BigBlueButton(serverConfig);
        //Console.WriteLine(ClsData.getSha1("createname=Test+Meeting&meetingID=abc123&attendeePW=111222&moderatorPW=33344404f3591a48c820cebfe5096e6cffd0b3"));
        dt = ObjBigBlueButton.CreateMeeting("random-3166867", "random-3166867", "ap", "mp");
        ObjBigBlueButton.JoinMeeting("User1", "random-3166867", "ap", true);
        //ObjBigBlueButton.JoinMeeting("Mkalaiselvi", "a2b", "selvi", true);
        //dt = ObjBigBlueButton.IsMeetingRunning("a2b");
        //dt =ObjBigBlueButton.getMeetings();
        //dt = ObjBigBlueButton.GetMeetingInfo("a2b", "kalai");
        //dt = ObjBigBlueButton.EndMeeting("a2b", "kalai");
        //dt =ObjBigBlueButton.IsMeetingRunning("aaa");          
        Console.ReadLine();

    }

}

