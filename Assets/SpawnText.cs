//////////////////////////////////////////////////////////////////////////////////////////////////
//  This script contains stuff about the quiz text.                                             //
//  The game screen will instantiate this text and displays the quiz.                           //
//  This script also comes with some IEnumerator functions that deal with Throughs and NextQs.  //
//////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KoganeUnityLib;
public class SpawnText : MonoBehaviour
{
    public static int totalCorCount = 0;
    TMP_Typewriter m_typewriter;
    float m_speed = 10F;
    bool qstop = false;
    public static int qcount = 0;
    public static string fileName = "Assets/Saves/savefile.json";
    public GameObject incorrectImg;
    
    // Start is called before the first frame update
    public void DisplayQuestion(string q){
        m_typewriter.Play
            (
                text        : q,
                speed       : m_speed,
                onComplete  : () => ThroughProcess()
            );
    }

    public IEnumerator Throughcount(){
        print("Throughcount");
        yield return new WaitForSeconds(5.0f);
        if (qstop){
            yield break;
        }
        else{
            print("時間切れ！！");
            GameObject obj = Instantiate(incorrectImg);
            QuizField.corCount[SpawnText.qcount] = 0;
            StartCoroutine(Answerbox.Countdown(3.0f));
            Destroy(obj, 3);
            StartCoroutine(NextQ());
        }
    }

    public void ThroughProcess(){
        if (!qstop){
            StartCoroutine(Throughcount());
        }
        
    }

    public IEnumerator NextQ(){
        print("NextQ");
        yield return new WaitForSeconds(3.0f);
        qcount = qcount+1;
        qstop = false;
        if (qcount >= QuizField.maxQuestions){
            QuizField.endProcess();
        }
        else{
            DisplayQuestion(QuizField.question[qcount]);
        }
    }
    public void Start()
    {
        Debug.Log("StartQuiz!");
        totalCorCount =0;
        m_typewriter = gameObject.GetComponent<TMP_Typewriter>();
        DisplayQuestion(QuizField.question[qcount]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            m_typewriter.Pause();
            qstop = true;
            FindObjectOfType<Answerbox>().spawnBox();
        }
    }
}
