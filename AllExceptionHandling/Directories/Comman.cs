namespace AllExceptionHandling.Directories
{
    public static class Common
    {
        public static void WriteToLogFile(Exception ex, string errorMessage)
        {
            string logMessage = $"Exception: {ex.GetType().FullName}" +
                                $"\nMessage: {ex.Message}" +
                                $"\nStack Trace: {ex.StackTrace}" +
                                $"\nError Message: {errorMessage}" +
                                $"\nTime: {DateTime.Now}\n";

            string filePath = WriteLog();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("File write Error");
            }
        }

        public static string WriteLog()
        {
            string logFilePath = "E:\\Git\\Api\\AllExceptionHandling\\AllExceptionHandling\\ErrorHandling\\" + System.DateTime.Today.ToString("dd MMM yyyy") + ".txt";
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            return logFilePath;
        }
    }
}