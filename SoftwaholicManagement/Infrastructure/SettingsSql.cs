using SMDataLayer.Models;

namespace SM.Infrastructure
{
    public class SettingsSql
    {
        public enum EnumSettingKey
        {
            TicketId,
            DueDateMembership,
            BackupInterval,
            LastBackupTime,
            IsMainDevice
        }

        //WHERE IT BEING CALLED
        public static void EnsureSettingsExist()
        {

            foreach (EnumSettingKey key in Enum.GetValues(typeof(EnumSettingKey)))
            {
                string keyName = key.ToString();
                string? keyValue = GetDefaultValueForKey(key);

                if (key == EnumSettingKey.TicketId || key == EnumSettingKey.DueDateMembership || key == EnumSettingKey.IsMainDevice)
                {
                    keyName = EncryptionService.EncryptString(keyName);
                    keyValue = keyValue != null ? EncryptionService.EncryptString(keyValue) : null;
                }


                //ejbare hone , after encyption
                if (!SettingsSql.IsKeyExists(keyName))
                {
                    SettingsSql.InsertKey(keyName, keyValue);
                }
            }
        }
        private static string GetDefaultValueForKey(EnumSettingKey key)
        {
            switch (key)
            {
                case EnumSettingKey.TicketId:
                    return "1";
                case EnumSettingKey.DueDateMembership:
                    return null;
                case EnumSettingKey.BackupInterval:
                    return null;
                case EnumSettingKey.LastBackupTime:
                    return null;
                case EnumSettingKey.IsMainDevice:
                    return "false";
                default:
                    return "";
            }
        }



        //SqlRowQueries for SetingsTable
        public static string GetKeyValue(string key)
        {
            using (var context = new ClothingStoreContext())
            {
                var setting = context.Settings
                                     .FirstOrDefault(s => s.SettingKey == key);
                return setting?.SettingValue;
            }
        }


        public static void InsertKey(string key, string KeyValue)
        {
            using (var context = new ClothingStoreContext())
            {
                var setting = new Setting
                {
                    SettingKey = key,
                    SettingValue = KeyValue
                };
                context.Settings.Add(setting);
                context.SaveChanges();
            }
        }
        public static void UpdateKeyValue(string key, string? keyValue)
        {
            using (var context = new ClothingStoreContext())
            {
                var setting = context.Settings
                                 .FirstOrDefault(s => s.SettingKey == key);
                if (setting != null)
                {
                    setting.SettingValue = keyValue;
                    context.SaveChanges();
                }
            }
        }
        public static bool IsKeyExists(string key)
        {
            using (var context = new ClothingStoreContext())
            {
                return context.Settings
                          .Any(s => s.SettingKey == key);
            }
        }
    }
}

