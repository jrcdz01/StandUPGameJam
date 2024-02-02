using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Line", menuName = "Dialogue Line")]
public class DialogueLine : ScriptableObject
{
    public string[] dialogueLine;
    public string[] awnsers;
    public DialogueLine(string[] dialogueLine, string[] awnsers){
        this.dialogueLine = dialogueLine;
        this.awnsers = awnsers;
    }
}
