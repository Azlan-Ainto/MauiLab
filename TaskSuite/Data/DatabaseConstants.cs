using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSuite.Data
{
    public static class DatabaseConstants
    {
        public const string DatabaseFilename = "ToDoSQLite.db3";

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
