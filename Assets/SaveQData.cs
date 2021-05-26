/////////////////////////////////////////////////////////////////////////////////////////////
//  This script contains quiz data that will be loaded.                                    //
//  The game will reference the current quiz and their answers from this script only.      //
//  This script also comes with a loader that will load questions from a given file dir.   //
/////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveQData
{
    // Start is called before the first frame update
    public string listTitle;
    public List<string> question = new List<string> {"日本で一番高い山は？", "手首につける飾りはブレスレットと言いますが、足首につける飾りは何という？"};
    public List<string> correct = new List<string>{"ふじさん", "あんくれっと"};
    public List<int> corCountSave= new List<int>();
    public decimal percentageSave = 0;
}
