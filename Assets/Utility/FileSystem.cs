using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileSystem
{
    public struct Extensions
    {
        public static string fileExtension;
        public static string objectFileExtension;
        public static string binaryFileExtension;
        public static string logFileExtension;
        public static string assetsDirectExtension;
    }

    private void AssignExtensions()
    {
        Extensions.fileExtension = ".ibxn";
        Extensions.objectFileExtension = ".ibxon";
        Extensions.binaryFileExtension = ".ibxbin";
        Extensions.logFileExtension = ".ibxwtf";
        Extensions.assetsDirectExtension = "/assets/";
    }

    public virtual void WriteRaw(string data, string relPath)
    {
        string path = Application.persistentDataPath + relPath + Extensions.fileExtension;
        
        if(File.Exists(relPath))
        {
            int response = NativeWinAlert.Alert("Confirm Overwrite", Application.productName + " isabout to overwrite a file at path\n\n" + path + "\n\nIs this ok?", NativeWinAlert.Options.yesNo, NativeWinAlert.Icons.querry);
            Debug.Log("response");

            if (response == 1) { return; }
        }

        Debug.Log("Writing Raw File: " + relPath);
        File.WriteAllText(path, data);
    }
}
