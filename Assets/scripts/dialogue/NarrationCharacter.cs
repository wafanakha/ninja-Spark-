using UnityEngine;

[CreateAssetMenu(fileName = "NarrationCharacter", menuName = "Scriptable Objects/Narration/Character")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField]
    private string m_CharacterName;

    public string CharacterName => m_CharacterName;

}
