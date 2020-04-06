using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public static int index;
    public static int conversationLength;
    public static int index_start;
    public float typingSpeed;

    public GameObject continueButton;
    private bool startConversation = false;

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        index = -1;

    }

    // Update is called once per frame
    void Update()
    {
        if (index > -1)
        {
            if (startConversation == false)
            {
                StartCoroutine(Type());
                startConversation = true;
            }

            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < index_start + conversationLength - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            startConversation = false;
            index = -1;
            PlayerMovement.playerLocked = false;
        }
    }
}
