using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class qloadScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject qloadUI = null;
    void Start()
    {
        Text qload_text = qloadUI.GetComponent<Text> ();
        qload_text.text = "問題集の選択";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
