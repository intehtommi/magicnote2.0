using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KoganeUnityLib;
public class SpawnText : MonoBehaviour
{
    TMP_Typewriter m_typewriter;
    float m_speed = 10F;
    bool qstop = false;
    string question = "";
    public static int qcount = 0;
    
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
            int exitcode = QuizField.endProcess();
            if (exitcode==0){
                Destroy(gameObject);//Change to switch scene later
            }
        }
        else{
            DisplayQuestion(QuizField.question[qcount]);
        }
    }

    public void Start()
    {
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
