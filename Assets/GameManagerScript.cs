using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManagerScript : MonoBehaviour
{
    public string filePath = "log.txt";
    DateTime dt = new DateTime();

    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
        OnApplicationLoad();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("space"))
        {
            LogSpace();
        }
    }

    // OnApplicationQuit is called when play time ends
    void OnApplicationQuit()
    {
        dt = DateTime.Now;
        AppendFile(dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + " Application Quit!");
    }

    // Creates file
    public void CreateFile()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
    }

    // Takes in a string of text and appends to file
    public void AppendFile(string text)
    {
        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine(text);
        }
    }

    // OnApplicationLoad is called in Start() when play time starts
    public void OnApplicationLoad()
    { 
        dt = DateTime.Now;
        AppendFile(dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + " Application Load!");
    }

    // Logs Button presses
    public void LogButton()
    {
        dt = DateTime.Now;
        AppendFile(dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + " Button Clicked!");
    }

    // Logs Space Key presses
    public void LogSpace()
    {
        dt = DateTime.Now;
        AppendFile(dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + " Space Key Pressed!");
    }

}