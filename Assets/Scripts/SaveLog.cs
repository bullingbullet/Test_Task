using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLog : MonoBehaviour
{
    public static string logFile;
    public static StreamWriter sw;

    private void Awake()
    {
        logFile = "Assets/Resources/Log.txt";

        sw = new StreamWriter(logFile, true);
        sw.WriteLine("Start", true);

        if (logFile.Length > 1000)
        {
            logFile = "";
        }
    }
}
