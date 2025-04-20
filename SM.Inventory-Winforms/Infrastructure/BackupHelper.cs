using SM.Common_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure
{
    internal class BackupHelper
    {
        public static string backUpConstantInterval = "06:00:00";
        static System.Windows.Forms.Timer backupTimer;



        public static async Task SetupBackupTimerndStartItIfNecessary()
        {

            backupTimer = new System.Windows.Forms.Timer();
            backupTimer.Interval = 60000 * 15; // 15 minutes == 900000 in ms
            backupTimer.Tick += async (sender, args) => await CheckAndAutomateBackUpIfNecessar();//setup the even tick and it s logic inside
            if (BackupHelper.CheckIfAutomatedBackupIsActive())
            {
                //starting the first iteration
                await CheckAndAutomateBackUpIfNecessar();
                backupTimer.Start();
            }
        }
        public static bool CheckIfAutomatedBackupIsActive()
        {

            string backupIntervalKey = SettingsSql.EnumSettingKey.BackupInterval.ToString();
            var BackupIntervalValue = SettingsSql.GetKeyValue(backupIntervalKey);

            if (string.IsNullOrEmpty(BackupIntervalValue))
            {
                return false;
            }
            else
            {
                SettingsSql.UpdateKeyValue(SettingsSql.EnumSettingKey.BackupInterval.ToString(), BackupIntervalValue);//in order to keep the right time updated, in case ghayrto hard coded
                return true;
            }

        }


        public static async Task CheckAndAutomateBackUpIfNecessar()
        {
            if (RandomFunctions.IsInternetAvailable())
            {
                var backupIntervalSettingValue = SettingsSql.GetKeyValue(SettingsSql.EnumSettingKey.BackupInterval.ToString());
                var lastBackupTimeSetting = SettingsSql.GetKeyValue(SettingsSql.EnumSettingKey.LastBackupTime.ToString());

                TimeSpan? backupIntervalValue = null;
                DateTime? lastBackupTimeValue = null;



                if (backupIntervalSettingValue != null)
                    backupIntervalValue = TimeSpan.Parse(backupIntervalSettingValue);

                if (lastBackupTimeSetting != null)
                    lastBackupTimeValue = DateTime.Parse(lastBackupTimeSetting);


                if (backupIntervalValue != null && (lastBackupTimeValue == null || DateTime.Now >= lastBackupTimeValue + backupIntervalValue))
                {
                    await Backup();
                }
            }
        }
        public static async Task<bool> Backup()
        {
            String PreviousBackupDate = SettingsSql.GetKeyValue(SettingsSql.EnumSettingKey.LastBackupTime.ToString());//kermel yenaamal upload aal server maa the last time naamal fiya backup
            string LastBackupTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            if (await HttpRequestsClass.UploadBackupFileAsync())
            {
                SettingsSql.UpdateKeyValue(SettingsSql.EnumSettingKey.LastBackupTime.ToString(), LastBackupTime);
                return true;
            }
            else
            {
                SettingsSql.UpdateKeyValue(SettingsSql.EnumSettingKey.LastBackupTime.ToString(), PreviousBackupDate);
                return false;
            }
        }

        public static string GetLastbackUpTime()
        {

            string BackUpTime = SettingsSql.GetKeyValue(SettingsSql.EnumSettingKey.LastBackupTime.ToString());
            if (!string.IsNullOrEmpty(BackUpTime))
            {
                return RandomFunctions.SetDateFormatWithhours(BackUpTime);
            }
            else
            {
                return "N/A";
            }
        }


        //used for frontend interaction
        public static void UpdateBackupIntervalAsync(bool isBackupAutoEnabled)
        {

            string BackupIntervalValue = null;
            if (isBackupAutoEnabled)
            {
                BackupIntervalValue = backUpConstantInterval;
            }

            SettingsSql.UpdateKeyValue(SettingsSql.EnumSettingKey.BackupInterval.ToString(), BackupIntervalValue);


            if (isBackupAutoEnabled)
            {
                CheckAndAutomateBackUpIfNecessar();//first iteration
                backupTimer.Start();
            }
            else
            {
                backupTimer.Stop();
            }

        }

    }
}

