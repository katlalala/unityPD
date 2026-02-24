using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject character1; 
    public GameObject character2;

    public void ChangeCharacter(int index)
    {
        if (index == 0) 
        {
            character1.SetActive(true);
            character2.SetActive(false);
        }
        else if (index == 1)
        {
            character1.SetActive(false);
            character2.SetActive(true);
        }
    }
}