using UnityEngine;

[CreateAssetMenu(fileName = "NarationLine", menuName = "Scriptable Objects/Narration/Line")]
public class NarationLine : ScriptableObject
{
    [SerializeField]
    private NarrationCharacter m_speaker;
    [SerializeField]
    private string m_line;

    public NarrationCharacter Speaker => m_speaker;
    public string Line => m_line;

}
