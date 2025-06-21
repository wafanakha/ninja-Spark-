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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        submit = InputSystem.actions.FindAction("Submit");
        cancel = InputSystem.actions.FindAction("Cancel");
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float submitValue = submit.ReadValue<float>();
        // Debug.Log(submitTimer);
        if (submitValue == 1 && submitTimer <= 0)
        {
            Debug.Log("HIT");
            if (textComponent.text == lines[index])
            {
                nextLine();
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

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
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
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
