using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ButtonScript : MonoBehaviour
{
    string filename;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void OnClick(){
        filename = this.transform.GetChild(1).GetComponent<Text>().text;
        string[] filePaths = Directory.GetFiles(Application.dataPath + "/Saves/", filename);
        QuizField.loadQSet(filePaths[0]);
        sceneSwitch.startQuestion();
    }
    void Update()
    {
        
    }
}
