using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{


    #region DialogueManagerSingleton
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory found");
            return;
        }

        instance = this;
    }
    #endregion

    //public Text nameText;
    private Queue<string> sentences;
    public Text dialogueText;
    public Animator animator;
    private bool dialogueOnScreen = false;
    [SerializeField] GameObject continueButton;

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (dialogueOnScreen == true && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    //opens text box and adds sentences to queue. calls display function
    {
        //nameText.text = dialogue.name;
        animator.SetBool("isOpen", true);
        continueButton.SetActive(true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    //types out sentences. ends if queued sentences reaches 0
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        dialogueOnScreen = true;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    //animates sentences letter by letter
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    //clears text box and removes it from screen
    {
        dialogueText.text = "";
        animator.SetBool("isOpen", false);
        dialogueOnScreen = false;
        continueButton.SetActive(false);
    }



}