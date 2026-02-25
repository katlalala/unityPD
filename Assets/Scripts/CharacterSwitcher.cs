using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject character1; 
    public GameObject character2;
    public CategoryManager categoryManager;

    public Slider widthSlider;
    public Slider heightSlider;

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

        if (categoryManager != null)
        {
            categoryManager.ShowCategory(categoryManager.currentCategory);
        }

        // ludzu nosaujiet mani sis neiet
        if(widthSlider != null) widthSlider.value = 1f;
        if(heightSlider != null) heightSlider.value = 1f;
    }

public void AdjustWidth(float value)
{
    GameObject activeChar = character1.activeSelf ? character1 : character2;
    activeChar.transform.localScale = new Vector3(value, activeChar.transform.localScale.y, 1f);
}
    
public void AdjustHeight(float value)
{
    GameObject activeChar = character1.activeSelf ? character1 : character2;
    activeChar.transform.localScale = new Vector3(activeChar.transform.localScale.x, value, 1f);
}
}