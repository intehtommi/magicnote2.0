using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScrollbarCanvas : MonoBehaviour
{
    public GameObject CellPrefab;
    void Start()
    {
        string[] filePaths = Directory.GetFiles(Application.dataPath + "/Saves/", "*.json");
        int i = 1;
        foreach(var filename in filePaths){
            GameObject obj = Instantiate(CellPrefab);
            obj.transform.SetParent(this.gameObject.transform, false);
            obj.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            obj.transform.GetChild(1).GetComponent<Text>().text = Path.GetFileName(filename);
            obj.transform.GetChild(2).GetComponent<Text>().text = "150/150";
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
