using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.CPLS.DELTA.CD.DELTA_Health_Scheduler
{
    //class Program
    //{
    //    private static object lockObject = new object();
    //    public enum notifier
    //    {
    //        Attributes, CreationTime,
    //        DirectoryName, FileName,
    //        LastAccess, LastWrite,
    //        Security, Size,
    //    }
    //    public delegate void ServiceChangerAlert(Object sender, ServiceChangeStatus e);

    //    //static void Main(string[] args)
    //    //{

    //    //    ServiceChanged();
    //    //    ServiceChanged();
    //    //    ServiceChanged();
    //    //    ServiceChanged();
    //    //    Console.WriteLine("***** Simple  Directory Watcher *****\n");
    //    //    // Establish the path to the directory to watch.
    //    //    FileSystemWatcher watcher = new FileSystemWatcher();
    //    //    try
    //    //    {
    //    //        watcher.Path = @"D:\Delta2.0_Sample_Logs\Dev";
    //    //    }
    //    //    catch (ArgumentException ex)
    //    //    {
    //    //        Console.WriteLine(ex.Message);
    //    //        return;
    //    //    }
    //    //    // Set up the things to be on the lookout for.
    //    //    watcher.NotifyFilter = NotifyFilters.LastAccess
    //    //    | NotifyFilters.LastWrite
    //    //    | NotifyFilters.FileName
    //    //    | NotifyFilters.DirectoryName;
    //    //    // watch all types of files
    //    //    watcher.Filter = "*.txt";
    //    //    // Add event handlers.
    //    //    watcher.Changed += new FileSystemEventHandler(OnDirChanged);
    //    //    watcher.Created += new FileSystemEventHandler(OnDirChanged);
    //    //    watcher.Deleted += new FileSystemEventHandler(OnDirChanged);
    //    //    watcher.Renamed += new RenamedEventHandler(OnDirRenamed);

    //    //    // Begin watching the directory.
    //    //    watcher.EnableRaisingEvents = true;
    //    //    // Wait for the user to quit the program.
    //    //    Console.WriteLine(@"Press 'q' to quit app.");
    //    //    while (Console.Read() != 'q') ;
    //    //}
    //    //The two event handlers simply print out the current file modification:
    //    static void OnDirChanged(object source, FileSystemEventArgs e)
    //    {
    //        // Specify what is done when a file is changed, created, or deleted.
    //        Console.WriteLine("File: {0} {1}! {2}", e.FullPath, e.ChangeType, source.ToString());
    //        List<string> RecentLines = ReadTail(e.FullPath, 5);
    //        if (RecentLines != null)
    //        {
    //            foreach (var line in RecentLines)
    //            {
    //                Console.WriteLine(" $" + line);
    //                if (line.Contains("Error"))
    //                {
    //                    using (var smtpClient = new SmtpClient())
    //                    {
    //                        NetworkCredential networkCredential;
    //                        smtpClient.Host = "smtp-mail.outlook.com";
    //                        smtpClient.Port = 587;
    //                        smtpClient.UseDefaultCredentials = false;
    //                        networkCredential = new NetworkCredential("cpla-tra@microsoft.com", "Tr@c345ucc355!!");
    //                        smtpClient.EnableSsl = true;
    //                        smtpClient.Credentials = networkCredential;
    //                        MailAddress frommailAddress = new MailAddress("cpla-tra@microsoft.com", "DELTA Team");
    //                        MailMessage mailMessage = new MailMessage()
    //                        {
    //                            SubjectEncoding = Encoding.UTF8,
    //                            Body = "Error Occured",
    //                            BodyEncoding = Encoding.UTF8,
    //                            IsBodyHtml = true
    //                        };
    //                        mailMessage.From = frommailAddress;
    //                        mailMessage.Subject = "DELTA 2.0 Health";
    //                        mailMessage.To.Add("v-satheg@microsoft.com");
    //                        smtpClient.Send(mailMessage);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    static void OnDirRenamed(object source, RenamedEventArgs e)
    //    {
    //        // Specify what is done when a file is renamed.
    //        Console.WriteLine("File: {0} renamed to\n{1}", e.OldFullPath, e.FullPath);
    //    }

    //    private static List<string> ReadTail(String FilePath, int NoofLines)
    //    {
    //       List<string> mostRecentLines = null;
    //        //try
    //        //{
    //        //    lock (lockObject)
    //        //    {
    //                mostRecentLines = File.ReadLines(FilePath).Reverse().Take(NoofLines).ToList();
    //        //    }
    //        //}
    //        //catch
    //        //{
    //        //    lockObject = null;
    //        //}
    //        return mostRecentLines;
    //    }

    //    public static void ServiceChanged()
    //    {
    //        ServiceController sc = new ServiceController("PlugPlay");
    //        var Fax_Service_ctrl = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == "PlugPlay");
    //        Console.WriteLine(Fax_Service_ctrl.Status);
    //    }

    //    static void OnstatusChange()
    //    {

    //    }
    //}

}
