using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gamedata;
    private FileHandler fileHandler;

    public static DataPersistenceManager Instance { get; private set; }
    public List<IDataPersistence> dataPersistences;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene");
        }

        Instance = this;

    }

    public void Start()
    {
        this.fileHandler = new FileHandler(Application.persistentDataPath, fileName);
        this.dataPersistences = FinaAllIDataPersistenecObject();
        LoadGame();
    }

    public void NewGame()
    {
        this.gamedata = new GameData();
    }

    public void LoadGame()
    {
        this.gamedata = fileHandler.Load();

        if (this.gamedata == null)
        {
            Debug.Log("No data found. Initalizing data to defaulting");
            NewGame();
        }

        foreach (IDataPersistence dataPersistence in dataPersistences)
        {
            dataPersistence.LoadData(gamedata);
        }

        //Debug.Log("Loaded death count = " + gamedata.death);
        //Debug.Log("Loaded score count = " + gamedata.score);

    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistence in dataPersistences)
        {
            dataPersistence.SaveData(ref gamedata);
        }
                
        fileHandler.Save(gamedata);

        //Debug.Log("Save death count = " + gamedata.death);
        //Debug.Log("Save score count = " + gamedata.score);
        
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FinaAllIDataPersistenecObject()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }
}
