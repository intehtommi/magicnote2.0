/////////////////////////////////////////////////////////////////////////////////////////////
//  This script contains methods for loading quiz and ending processes.                    //
//  The game will reference the current quiz and their answers from this script only.      //
//  This script also comes with a loader that will load questions from a given file dir.   //
/////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Text;

public class QuizField : MonoBehaviour
{
    
    public static List<string> question = new List<string> {"日本で一番高い山は？", "手首につける飾りはブレスレットと言いますが、足首につける飾りは何という？"};
    public static List<string> correct = new List<string>{"ふじさん", "あんくれっと"};
    public static List<int> corCount = new List<int>{0,0};
    public static int totalCorCount = 0;
    public static int maxQuestions = question.Count;
    public static string fileName = "Assets/Saves/savefile.json";

    public static void loadQSet(string fileName){
        string json = File.ReadAllText(fileName);
        SaveQData save = JsonUtility.FromJson<SaveQData>(json);
        question = save.question;
        correct = save.correct;
        corCount = save.corCountSave;
        maxQuestions = save.question.Count;
    }
    public static void countUp(){
        totalCorCount++;
    }
    public static void endProcess(){
        sceneSwitch.viewResult();
    }

    // Start is called before the first frame update
    // We are going to move this to SpawnText or find a way to instantiate SpawnText.
    void Start()
    {
    }
}
