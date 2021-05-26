using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answerbox : MonoBehaviour
{
    public string stringToEdit = "abc";
    public bool GUIEnabled = false;
    public string answer = "";
    public GameObject correctImg;
    public GameObject incorrectImg;

    // Start is called before the first frame update
    void Start()
    {
        GUIEnabled = !GUIEnabled;
        stringToEdit = "";
        GUIEnabled = !GUIEnabled;
    }


    public void spawnBox() {
        GUIEnabled = !GUIEnabled;
    }
    public static IEnumerator Countdown(float t){
        yield return new WaitForSeconds(t); 
        print("カウントダウン終了！");
    }
    

    void OnGUI(){
        if(GUIEnabled){
            GUI.skin.textField.fontSize = 50;
            stringToEdit = GUI.TextField(new Rect(100, 700, 1800, 300), stringToEdit, 25);
            if (Event.current.type == EventType.KeyDown && Event.current.character == '\n'){
                answer = stringToEdit;
                if(QuizField.correct[SpawnText.qcount]==answer){
                    print("正解！");
                    GameObject obj = Instantiate(correctImg);
                    QuizField.countUp();
                    QuizField.corCount[SpawnText.qcount] = QuizField.corCount[SpawnText.qcount]+1;
                    spawnBox();
                    Destroy(obj, 3);
                    StartCoroutine(FindObjectOfType<SpawnText>().NextQ()); //i need to deal with not using findobjecttype soon.
                }
                else{
                    print("不正解…");
                    GameObject obj = Instantiate(incorrectImg);
                    QuizField.corCount[SpawnText.qcount] = 0;
                    stringToEdit = QuizField.correct[SpawnText.qcount];
                    StartCoroutine(Countdown(3.0f));
                    Destroy(obj, 3);
                    StartCoroutine(FindObjectOfType<SpawnText>().NextQ());
                    spawnBox();
                }
            }
        }
    }
    
}
