using UnityEngine;
using UnityEngine.SceneManagement;

public class logic : MonoBehaviour
{
    GameObject dialoguebox = GameObject.FindGameObjectWithTag("dialogueBox");
    Dialogue dialouge_script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialouge_script = dialoguebox.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
