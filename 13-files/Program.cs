using System.Security.AccessControl;
using static System.Environment;

WriteSystemInfo();
ManagingPaths();

void WriteSystemInfo() {
  Console.WriteLine("{0,-33} {1}", "Path.PathSeparator", Path.PathSeparator);
  Console.WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar",Path.DirectorySeparatorChar);
  Console.WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()", Directory.GetCurrentDirectory());
  Console.WriteLine("{0,-33} {1}", "Environment.CurrentDirectory", Environment.CurrentDirectory);
  Console.WriteLine("{0,-33} {1}", "Environment.CommandLine", Environment.CommandLine);
  Console.WriteLine("{0,-33} {1}", "Environment.SystemDirectory", Environment.SystemDirectory);
  Console.WriteLine("{0,-33} {1}", "Environment.UserName", Environment.UserName);
  Console.WriteLine("{0,-33} {1}", "Environment.OSVersion", Environment.OSVersion);
  Console.WriteLine("{0,-33} {1}", "Environment.MachineName", Environment.MachineName);
  Console.WriteLine("{0,-33} {1}", "Path.GetRandomFileName()", Path.GetRandomFileName());
  Console.WriteLine("{0,-33} {1}", "Path.GetTempPath()", Path.GetTempPath());
  Console.WriteLine("{0,-33} {1}", "Environment.GetFolderPath(SpecialFolder.Desktop)",Environment.GetFolderPath(SpecialFolder.Desktop));
  Console.WriteLine("{0,-33} {1}", "SpecialFolder.System", Environment.GetFolderPath(SpecialFolder.System));
  Console.WriteLine("{0,-33} {1}", "SpecialFolder.ApplicationData", Environment.GetFolderPath(SpecialFolder.ApplicationData));
  Console.WriteLine("{0,-33} {1}", "SpecialFolder.CommonProgramFiles", Environment.GetFolderPath(SpecialFolder.CommonProgramFiles));
  Console.WriteLine("{0,-33} {1}", "SpecialFolder.Windows", Environment.GetFolderPath(SpecialFolder.Windows));
}
void ManagingPaths() {
  string textFile = Path.Combine(Directory.GetCurrentDirectory(), "test", "dummy.txt");
  Console.WriteLine("{0,-33} {1}", "Folder Name", Path.GetDirectoryName(textFile));
  Console.WriteLine("{0,-33} {1}", "File Name", Path.GetFileName(textFile));
  Console.WriteLine("{0,-33} {1}", "File Name without extension", Path.GetFileNameWithoutExtension(textFile));
  Console.WriteLine("{0,-33} {1}", "File extension", Path.GetExtension(textFile));
  Console.WriteLine("{0,-33} {1}", "Temporary file name", Path.GetTempFileName());
}

