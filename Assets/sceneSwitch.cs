using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void viewResult(){
        SceneManager.LoadScene ("resultScene");
    }
    public static void startQuestion(){
        SceneManager.LoadScene("quizScene");
    }
    
}