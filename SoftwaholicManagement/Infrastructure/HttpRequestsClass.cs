using Azure;
using Microsoft.Identity.Client;
using SM;
using SM.Common_Functions;
using SMDataLayer.Models;
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
            string dbDir = ApplicationCache.DirectoryFolder;
            if (Directory.Exists(dbDir))
            {
                if (RandomFunctions.IsInternetAvailable())
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
                    HttpResponseMessage response = null;
                    using (var client = new HttpClient())
                    {
                        // Create Multipart Content
                        using (var content = new MultipartFormDataContent())
                        {
                            //string requestUri = $"{AppConfig.Configuration["api-url"]}?TicketId=123&branchName={AppConfig.GetBucketName()}";
                            string requestUri = $"{BaseAddress}/Backup/Backup()?TicketId={ticketID}&branchName={AppConfig.GetBucketName()}";
                            try
                            {

                                var fileContent = new StreamContent(File.OpenRead(BackUpDBPath));
                            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            content.Add(fileContent, "backupFile", NewBackFile);

                            // Send POST request6
                            response = await client.PostAsync(requestUri, content);

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
                            catch (Exception ex)
                            {
                                result = false;
                               // LogHelper.logException(ex);
                            }
                        }

                    }
                    // Check if the response is successful then delete the log file
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        try
                        {
                            File.Delete(BackUpDBPath);
                        }
                        catch
                        {
                        }
                    }
                    return result;
                }
            }
            return false;
        }

        public static async Task CheckAndProcessLogs()
        {
            string logDirectoryPath = ApplicationCache.DirectoryFolder;

            // Ensure the directory exists to avoid runtime exceptions
            if (Directory.Exists(logDirectoryPath))
            {
                // Get all .json files in the directory
                string[] logFiles = Directory.GetFiles(logDirectoryPath, "*.json");
                if (logFiles.Count() > 0)
                {

                    if (RandomFunctions.IsInternetAvailable())
                    {
                        string ticketID = EncryptionService.GetDecryptedKeyValue(SettingsSql.EnumSettingKey.TicketId.ToString());

                        if (ticketID == null)
                            return;

                        // Process each file
                        foreach (string filePath in logFiles)
                        {
                            HttpResponseMessage response = null;
                            using (var client = new HttpClient())
                            {
                                // Create Multipart Content
                                using (var content = new MultipartFormDataContent())
                                {
                                    //string requestUri = $"{AppConfig.Configuration["api-url"]}?TicketId=123&branchName={AppConfig.GetBucketName()}";
                                    string requestUri = $"{BaseAddress}/Backup/Log()?TicketId={ticketID}&branchName={AppConfig.GetBucketName()}";


                                    try
                                    {
                                        // Load the file data
                                        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                                        {
                                            var fileContent = new StreamContent(fileStream);
                                            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                                            // 'logFile' is the parameter name that the server expects
                                            content.Add(fileContent, "logFile", Path.GetFileName(filePath));

                                            response = await client.PostAsync(requestUri, content);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                       // LogHelper.logException(ex);
                                    }
                                }
                            }

                            // Check if the response is successful then delete the log file
                            if (response != null && response.IsSuccessStatusCode)
                            {
                                try
                                {
                                    File.Delete(filePath);
                                }
                                catch
                                {
                                }
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

