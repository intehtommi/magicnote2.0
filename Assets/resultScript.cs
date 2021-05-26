using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Text;

public class resultScript : MonoBehaviour
{
    public GameObject score_object = null;
    public decimal percentage = (decimal)QuizField.totalCorCount / (decimal)QuizField.maxQuestions *100;

    string genText(int totalCor, int total, decimal percentage){
        Debug.Log((double)QuizField.totalCorCount / (double)QuizField.maxQuestions);
        string textout="";
        Debug.Log(percentage);
        textout = "正解数:" + totalCor.ToString() + " / " + total.ToString() + "\n正解率:" + percentage.ToString() + "%";
        return textout;
    }

    private SaveQData CreateSaveQDataObject(){
        SaveQData save = new SaveQData();
        foreach(int i in QuizField.corCount){
            save.corCountSave.Add(i);
        }
        save.percentageSave = percentage;
        return save;
    }
    public string GetSaveFilePath(){
        return "Assets/Saves/savefile.json";   
    }

    public void SaveAsJSON()
    {
        SaveQData save = CreateSaveQDataObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
        File.WriteAllText(GetSaveFilePath(), json);
    }

        // Start is called before the first frame update
    void Start(){
        Text result_text = score_object.GetComponent<Text> ();
        result_text.text = genText(QuizField.totalCorCount, QuizField.maxQuestions, percentage);
        SaveAsJSON();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
