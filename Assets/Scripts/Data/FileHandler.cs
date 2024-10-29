
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
//using UnityEditor.Playables;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;



public class FileHandler
{
    private string dataDIrPath = "";
    private string dataFileName = "";
    public DataPersistenceManager dataPersistenceManager;

    public FileHandler(string dataDirPath, string dataFileName)
    {
        this.dataDIrPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDIrPath, dataFileName);
        //string fullPathWithFrontSlash = Path.Combine(dataDIrPath, dataFileName);
        //string fullPath = fullPathWithFrontSlash.Replace("/", @"\");
        Debug.Log(fullPath);

        GameData loadedData = null;
        

        if (File.Exists(fullPath))
        {

            try
            {
                string dataToLoad = "";

                using (FileStream fileStream = new FileStream(fullPath, FileMode.Open))
                {
                    
                    using (StreamReader readfile = new StreamReader(fileStream))
                    {
                        dataToLoad = readfile.ReadToEnd();
                        
                    }
                }
                //string curren = dataToLoad;

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            } 
            catch (Exception e)
            {
                Debug.Log("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDIrPath, dataFileName);

        try
        {

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data,true);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writefile = new StreamWriter(fileStream))
                {
                    writefile.Write(dataToStore);
                }
            }
        }
        catch (Exception e) 
        {
            Debug.Log("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }

    }
}
