using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour, IDataPersistence
{
    public int levelNumber;
    public InstantiateAlongLine insta;

    private void Awake()
    {
        insta.number = levelNumber;
    }

    void Start()
    {
        insta = GetComponent<InstantiateAlongLine>();
    }

    public void LoadData(GameData data)
    {
        this.levelNumber = data.level;
        SetLevel();
    }

    public void SaveData(ref GameData data)
    {
        data.level = this.levelNumber;
        //Debug.Log(data.level);
    }

    public void SetLevel()
    {
        switch (levelNumber)
        {
            case 0: insta.number = 1; break;
            case 1: insta.number = 2; break;
            case 2: insta.number = 3; break;
            case 3: insta.number = 3; break;
            case 4: insta.number = 3; break;
            case 5: insta.number = 3; break;
            case 6: insta.number = 3; break;
            case 7: insta.number = 3; break;
            case 8: insta.number = 4; break;
            case 9: insta.number = 4; break;
            case 10: insta.number = 4; break;
            default: insta.number = 5; 
            break;
        }
    }

}
