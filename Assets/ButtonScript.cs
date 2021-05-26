using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    public string qsetname;
    public string questioncount;
    void Start()
    {
        qsetname = this.transform.GetChild(1).GetComponent<Text>().text;
        questioncount = this.transform.GetChild(2).GetComponent<Text>().text;
    }

    // Update is called once per frame
    void onClick(){
        Debug.Log("you did it!!");
    }
    void Update()
    {
        
    }
}
