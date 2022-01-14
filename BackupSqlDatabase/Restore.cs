using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSqlDatabase
{
    public static class Restore
    {
        public static bool RestoerDatabase(string dbName, string fileAddress)
        {
            
                try
                {
                    Server myServer = new Server(@".\SQLExpress2019");

                    Database mydb = myServer.Databases[dbName];
                    if (mydb != null)
                        myServer.KillAllProcesses(mydb.Name);//detach

                    Restore restoreDB = new Restore();
                    restoreDB.Database = mydb.Name;
                    restoreDB.Action = RestoreActionType.Database;
                    restoreDB.Devices.AddDevice(fileAddress, DeviceType.File);

                    restoreDB.ReplaceDatabase = true;

                    restoreDB.NoRecovery = false;

                    restoreDB.SqlRestore(myServer);
                    return true;
                }
                catch
                {
                    return false;
                }

             
        }
    }
}
