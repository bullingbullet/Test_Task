using UnityEngine;
using System.IO;

public class SaveLog : MonoBehaviour
{
    [SerializeField] private int maxLengthLog = 1000;

    public static StreamWriter logWriter;

    private string logFile;

    private static readonly string logPath = "Assets/Resources/Log.txt";

    private void Start()
    {
        LogClean();

        SaveLine("Start");
    }

    private void LogClean()
    {
        logFile = File.ReadAllText(logPath);

        if (logFile.Length >= maxLengthLog)
        {
            File.WriteAllText(logPath, string.Empty);
        }
    }

    public static void SaveLine(string Line)
    {
        using (StreamWriter logWriter = File.AppendText(logPath))
        {
            logWriter.WriteLine(Line);
        }
        print("sds");
    }
}
