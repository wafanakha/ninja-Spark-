using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class logic : MonoBehaviour
{
    InputAction cancel;


    public GameObject DialogueBox;

    public Dialogue dialouge_script;
    public PlayerMove player_script;
    public enemy enemy_script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cancel = InputSystem.actions.FindAction("Cancel");
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (DialogueBox.activeInHierarchy == true)
        {
            player_script.enabled = false;
            enemy_script.enabled = false;
        }
        else
        {
            player_script.enabled = true;
            enemy_script.enabled = true;
        }
    }
}
