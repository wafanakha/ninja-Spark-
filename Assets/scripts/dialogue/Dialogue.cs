using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    InputAction submit;
    InputAction cancel;

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private float submitTimer = 0.2f;
    private bool Dialogueon;
    void Start()
    {
        // init input 
        submit = InputSystem.actions.FindAction("Submit");
        cancel = InputSystem.actions.FindAction("Cancel");
        // init text
        textComponent.text = string.Empty;
    }

    void FixedUpdate()
    {
        // read the input 
        float submitValue = submit.ReadValue<float>();
        if (submitValue == 1 && submitTimer <= 0 && Dialogueon)
        {
            if (textComponent.text == lines[index])
            {
                nextLine();
                // reset timer
                submitTimer = 0.2f;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                submitTimer = 0.2f;
            }
        }
        submitTimer -= Time.deltaTime;

    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
        Dialogueon = true;
    }
    IEnumerator TypeLine()
    {
        // produce every letter on a line
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine()
    {
        if (index < lines.Length - 1)
        {
            // update line and reset text
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // stop dialogue
            gameObject.SetActive(false);
            textComponent.text = string.Empty;
            Dialogueon = false;
        }
    }
}
