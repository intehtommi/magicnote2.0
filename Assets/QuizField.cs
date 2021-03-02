using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizField : MonoBehaviour
{
    
    public static string[] question = new string[] {"日本で一番高い山は？", "日本で一番かわいいキャラクターは？"};
    public static string[] correct = new string[]{"ふじさん", "瀬笈葉"};
    public static int[] corCount = new int[]{0,0};
    public static int maxQuestions = question.Length;

    public static void loadQSet(){
        print("loadQSet");
    }
    public static void saveQSet(){
        print("loadQSet");
    }
    /*
    public static string getQuestion(){
        print("getQuestion");
    }

    public string getCorrect(){
        print("getCorrect");
    }
    */
    public static IEnumerator Countdown(float t){
        yield return new WaitForSeconds(t); 
        print("カウントダウン終了！");
    }

    public static int endProcess(){
        for(int i=0; i<maxQuestions; i++){
            print(corCount[i]);
        }
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
