using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answerbox : MonoBehaviour
{
    public string stringToEdit = "abc";
    public bool GUIEnabled = false;
    public string answer = "";
    

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void spawnBox() {
    // Random Index
        // Spawn Group at current Position
        GUIEnabled = !GUIEnabled;
    }
    

    void OnGUI(){
        if(GUIEnabled){
            GUI.skin.textField.fontSize = 50;
            stringToEdit = GUI.TextField(new Rect(100, 700, 1800, 300), stringToEdit, 25);
            if (Event.current.type == EventType.KeyDown && Event.current.character == '\n'){
                answer = stringToEdit;
                if(QuizField.correct[SpawnText.qcount]==answer){
                    print("正解！");
                    QuizField.corCount[SpawnText.qcount] = QuizField.corCount[SpawnText.qcount]+1;
                    spawnBox();
                    StartCoroutine(FindObjectOfType<SpawnText>().NextQ()); //i need to deal with not using findobjecttype soon.
                }
                else{
                    print("不正解…");
                    QuizField.corCount[SpawnText.qcount] = 0;
                    spawnBox();
                    StartCoroutine(QuizField.Countdown(3.0f));
                    StartCoroutine(FindObjectOfType<SpawnText>().NextQ());
                }
            }
        }
    }
    
}
