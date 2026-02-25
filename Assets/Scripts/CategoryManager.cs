using UnityEngine;

public class CategoryManager : MonoBehaviour
{
    public GameObject chiikawa;
    public GameObject hachiware;
    
    // iet uz pirmo sekciju
    public string currentCategory = "Outfit";

    void Start()
    {
        // outfits
        ShowCategory(currentCategory);
    }

    public void ShowCategory(string categoryName)
    {
        // saglabaa sekciju
        currentCategory = categoryName;

        GameObject activeChar = chiikawa.activeSelf ? chiikawa : hachiware;
        ClothingDrag[] items = activeChar.GetComponentsInChildren<ClothingDrag>(true);

        foreach (ClothingDrag item in items)
        {
            // parbauda vai piepiests pie chara
            bool isEquipped = Vector2.Distance((Vector2)item.transform.localPosition, item.characterPosition) < 1f;

            if (isEquipped || item.category == categoryName)
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    public void RefreshCategory()
{
    ShowCategory(currentCategory);
}

public void ResetCharacter()
{
    // atrod kas aktivs
    GameObject activeChar = chiikawa.activeSelf ? chiikawa : hachiware;
    
    // visas drebes uz chara
    ClothingDrag[] items = activeChar.GetComponentsInChildren<ClothingDrag>(true);

    foreach (ClothingDrag item in items)
    {
        item.transform.localPosition = (Vector3)item.boardPosition;

        // paslepj
        if (item.category != currentCategory)
        {
            item.gameObject.SetActive(false);
        }
        else
        {
            item.gameObject.SetActive(true);
        }
    }
}
}