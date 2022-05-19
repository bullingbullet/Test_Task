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
        logFile = File.ReadAllText(logPath);
        LogClean();
        SaveLine("Start");
    }

    private void LogClean()
    {
        Debug.LogWarning(logFile.Length);
        if (logFile.Length >= maxLengthLog)
        {
            Debug.LogWarning("amogus");
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
