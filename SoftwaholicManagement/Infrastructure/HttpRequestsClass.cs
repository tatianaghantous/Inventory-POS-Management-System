using Microsoft.Identity.Client;
using SM;
using SM.Common_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure
{
    public class HttpRequestsClass
    {
        static string BaseAddress = "http://localhost:5117";
        static string BaseAddressProd = "https://api.softwaholic.com/admin";


        //BackUP
        public static async Task<bool> UploadBackupFileAsync()
        {

                bool result;

                string ticketID = EncryptionService.GetDecryptedKeyValue(SettingsSql.EnumSettingKey.TicketId.ToString());

                if (ticketID == null)
                    return false;

                string dbPath = ApplicationCache.DatabasePath;
                string NewBackFile = "SoftwaholicBackUp.db";
                string BackUpDBPath = $"{ApplicationCache.DirectoryFolder}\\{NewBackFile}";

                if (!string.IsNullOrEmpty(dbPath) && File.Exists(dbPath))
                {
                    File.Copy(dbPath, BackUpDBPath, true);
                }

                using (var client = new HttpClient())
                {
                    // Create Multipart Content
                    using (var content = new MultipartFormDataContent())
                    {
                        //string requestUri = $"{AppConfig.Configuration["api-url"]}?TicketId=123&branchName={AppConfig.GetBucketName()}";
                        string requestUri = $"{BaseAddress}/Backup/Backup()?TicketId={ticketID}&branchName={AppConfig.GetBucketName()}";


                        var fileContent = new StreamContent(File.OpenRead(BackUpDBPath));
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        content.Add(fileContent, "backupFile", NewBackFile);

                        // Send POST request6
                        var response = await client.PostAsync(requestUri, content);

                        // Check if the response is successful
                        if (response.IsSuccessStatusCode)
                        {
                            // Optionally read the response
                            await response.Content.ReadAsStringAsync();
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                File.Delete(BackUpDBPath);
                return result;
        }



        //logs
        public static async Task CheckAndProcessLogs()
        {
            if (RandomFunctions.IsInternetAvailable())
            {
                string ticketID = EncryptionService.GetDecryptedKeyValue(SettingsSql.EnumSettingKey.TicketId.ToString());

                if (ticketID == null)
                    return;


                string logDirectoryPath = ApplicationCache.DirectoryFolder;

                // Ensure the directory exists to avoid runtime exceptions
                if (Directory.Exists(logDirectoryPath))
                {
                    // Get all .json files in the directory
                    string[] logFiles = Directory.GetFiles(logDirectoryPath, "*.json");

                    // Process each file
                    foreach (string filePath in logFiles)
                    {
                        HttpResponseMessage response = null;
                        using (var client = new HttpClient())
                        {
                            Thread.Sleep(190000); // 50,000 milliseconds = 50 seconds
                            // Create Multipart Content
                            using (var content = new MultipartFormDataContent())
                            {
                                //string requestUri = $"{AppConfig.Configuration["api-url"]}?TicketId=123&branchName={AppConfig.GetBucketName()}";
                                string requestUri = $"{BaseAddress}/Backup/Log()?TicketId={ticketID}&branchName={AppConfig.GetBucketName()}";
                                try
                                {

                                    // Load the file data
                                    var fileContent = new StreamContent(File.OpenRead(filePath));
                                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                                    // 'logFile' is the parameter name that the server expects
                                    content.Add(fileContent, "logFile", Path.GetFileName(filePath));
                                    // handle if it cant connect to the api if there is an internet connection
                                    response = await client.PostAsync(requestUri, content);
                                }
                                catch (Exception ex)
                                {
                                }

                            }
                        }

                        // Check if the response is successful then delete the log file
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            try
                            {
                                Thread.Sleep(50000); // 50,000 milliseconds = 50 seconds
                                File.Delete(filePath);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
        }

        public static string GetMotherboardSerialNumber()
        {
            try
            {
                string serialNumber = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    serialNumber = queryObj["SerialNumber"].ToString();
                    break; // Assuming only one motherboard
                }
                return serialNumber;
            }
            catch
            {
                return "MACNOTFOUND";
            }
        }

    }
}

