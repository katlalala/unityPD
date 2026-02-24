using UnityEngine;
using UnityEngine.UI; // Required for the Image component

public class CharacterSwitcher : MonoBehaviour
{
    // These are the "slots" where you will drag your character objects
    public GameObject character1; 
    public GameObject character2;

    // This function runs when the Dropdown changes
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