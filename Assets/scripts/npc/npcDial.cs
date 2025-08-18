using UnityEngine;
using UnityEngine.InputSystem;

public class npcDial : MonoBehaviour
{
    public string[] lines;
    InputAction cancel;
    private float submitTimer = 0.2f;

    public Dialogue dialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cancel = InputSystem.actions.FindAction("Cancel");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        submitTimer -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        dialogue.lines = lines;
        float submitValue = cancel.ReadValue<float>();
        if (submitValue == 1 && submitTimer <= 0)
        {
            dialogue.StartDialogue();
            submitTimer = 0.2f;

        }
    }

}
