using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveProgress : MonoBehaviour
{
    //static public string name="nitay";
    public int level;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        // level = JsonUtility.FromJson<SaveProgress>("C:\\Users\\nitay\\Documents\\GitHub\\NitayAndGuy\\NitayAndGuy\\hiii.json").level;
        //name = JsonUtility.FromJson<SaveProgress>("C:\\Users\\nitay\\Documents\\GitHub\\NitayAndGuy\\NitayAndGuy\\hiii.json").name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateData(int _level)
    {
        level = _level;
        //Debug.Log("name: " + name);
        Debug.Log("level: " + level);
        SaveToJson();
    
    }
    private void SaveToJson()
    {
        string data = JsonUtility.ToJson(this);
        File.WriteAllText( "C:\\Users\\nitay\\Documents\\GitHub\\NitayAndGuy\\NitayAndGuy\\hiii.json", data);
    
    }
}
