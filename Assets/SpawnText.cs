using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KoganeUnityLib;
public class SpawnText : MonoBehaviour
{
    TMP_Typewriter m_typewriter;
    float m_speed = 10F;
    // Start is called before the first frame update
    void Start()
    {
        m_typewriter = gameObject.GetComponent<TMP_Typewriter>();
        m_typewriter.Play
        (
            text        : "めっちゃ強いクイズプレイヤーは誰？",
            speed       : m_speed,
            onComplete  : () => Debug.Log( "完了" )
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            m_typewriter.Pause();
        }
    }
}
