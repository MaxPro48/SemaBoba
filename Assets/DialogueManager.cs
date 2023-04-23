using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
//using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public Text npcText;
    public Text answerText;
    public Canvas dialogCanvas;

    private Story currentStory;
    public bool isInDialog;

    private static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogCanvas.enabled = false;
        answerText.text = string.Empty;
        isInDialog = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInDialog)
        {
            return;
        }

    }

    public void EnterDialogue(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        isInDialog = true;
        dialogCanvas.enabled = true;

        ContinueStory();
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            npcText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        isInDialog = false;
        dialogCanvas.enabled = false;
        npcText.text = string.Empty;
    }

    public void DisplayChoices()
    {
        answerText.text = string.Empty;
        var choices = currentStory.currentChoices;
        var index = 1;
        foreach (var choice in choices)
        {
            answerText.text += $"{index}) {choice.text} \n";
            index++;
        }
    }

    public void MakeChoice(int index)
    {
        currentStory.ChooseChoiceIndex(index);
        while (currentStory.canContinue)
        {
            ContinueStory();
        }
        DisplayChoices();
    }
}
