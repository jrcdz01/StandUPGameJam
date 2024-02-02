using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JokeText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private int indexDialogue;
    private int indexDialogueLine;
    private string currentDialogueLine;
    [SerializeField] private DialogueLine[] jokeText;
    [SerializeField] private GameObject optionsButtons;
    [SerializeField] private float textSpeed;
    [SerializeField] private AudioSource audioDialogue;
    [SerializeField] private TextMeshProUGUI[] alternativas;
    private Toggle alternativa;
    // [SerializeField] private GameObject playbleDirector;
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        optionsButtons.SetActive(false);
        contador++;
        indexDialogue = 0;
        StartDialogue( jokeText[indexDialogue].dialogueLine );
        Debug.Log(contador);
    }   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J)){
           
            if (textComponent.text == currentDialogueLine){
                NextLine();
            }else{
                StopAllCoroutines(); 
                textComponent.text = currentDialogueLine;
                int contTemp = 0;
                foreach( TextMeshProUGUI alternativa in alternativas){
                    alternativa.text = jokeText[indexDialogue].awnsers[contTemp];
                    contTemp++;
                }
                optionsButtons.SetActive(true);
            }
        }
    }

    void StartDialogue(string[] lines){
        indexDialogueLine = 0;
        currentDialogueLine = jokeText[indexDialogue].dialogueLine[indexDialogueLine];
        StartCoroutine(TypeLine(currentDialogueLine));
    }

    IEnumerator TypeLine( string textLine ){
        textComponent.text = string.Empty;
        bool temp = true;

        foreach(char charactere in textLine.ToCharArray() ){
            textComponent.text += charactere;
            if(temp == true){
                audioDialogue.Play();
                temp = false;
            }else{
                temp = true;
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if( indexDialogueLine < jokeText[indexDialogue].dialogueLine.Length -1){
            // Debug.Log("Fala"+indexFalas+" - Linha "+indexLinhaDeDialogo);
            indexDialogueLine++;
            // textComponent.text = string.Empty;
            currentDialogueLine = jokeText[indexDialogue].dialogueLine[indexDialogueLine];
            StartCoroutine(TypeLine(currentDialogueLine));
        }else if(indexDialogue < jokeText.Length - 1){
            indexDialogue++;
            StartDialogue(jokeText[indexDialogue].dialogueLine);
        }
        else{
            optionsButtons.SetActive(false);

            // if(playbleDirector)
                // Destroy(playbleDirector);

            // cutsceneFinalizada.RuntimeValue = true;

            // this.gameObject.SetActive(false);      
        }
    }
}
