using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class logic : MonoBehaviour
{
    InputAction cancel;
    InputAction submit;

    GameObject dialoguebox;
    private float submitTimer = 0.2f;

    public Dialogue dialouge_script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialoguebox = GameObject.FindGameObjectWithTag("dialogueBox");
        cancel = InputSystem.actions.FindAction("Cancel");
        submit = InputSystem.actions.FindAction("Submit");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float submitValue = cancel.ReadValue<float>();
        if (submitValue == 1 && submitTimer <= 0)
        {
            dialouge_script.StartDialogue();
            submitTimer = 0.2f;
        }
        submitTimer -= Time.deltaTime;
    }
}
