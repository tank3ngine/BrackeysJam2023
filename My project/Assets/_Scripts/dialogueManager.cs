using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class dialogueManager : MonoBehaviour
{
    [SerializeField] private string dialogueAssigner;

    [SerializeField] public List<TMP_Text> Dialogue = new List<TMP_Text>();
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private Image charon1;
    [SerializeField] private Image charon2;
    

    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject nextSceneButton;

    [SerializeField] private bool lastText = false;

    [SerializeField] private int nextDialogueIndex = 0;


     void Start()
    {
        dialogueText.text = "...";
       // ExampleImage.SetActive(true);

       // if (dialogueAssigner != "intro")
       // {
            //ExampleImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            //ExampleImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
       // }
    }

    public void ContinueButton()
    {
        Debug.Log("continueButton Pressed");
        
        dialogueText.text = Dialogue[nextDialogueIndex].text;
        nextDialogueIndex++;
        Debug.Log("index is: " + nextDialogueIndex);
        if (nextDialogueIndex >= Dialogue.Count)

        {
            continueButton.SetActive(false);
            nextSceneButton.SetActive(true);
         //Debug.Log("End of dialogue at index: " + nextDialoueIndex);

        }

        //checks dialogue sequence and what scene as 
        //intro scene

        if(dialogueAssigner == "intro")
        {
            if (nextDialogueIndex == 6)
            {
                // charon1.enabled = false;
                // charon2.enabled = true; 
            }
            
        }

        if (dialogueAssigner == "secondDialogue")
        {
            //  if nextDialogueIndex == 2)

        }
           if (dialogueAssigner == "thirdDialogue")
        {
             if (nextDialogueIndex == 6)
            {
              
            }

        }
            


     
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    private void Update()
    {
        
    }
}

