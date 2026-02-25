using UnityEngine;
using UnityEngine.EventSystems;

public class ClothingDrag : MonoBehaviour, IDragHandler, IEndDragHandler {

    // CATEGORIES
    public string category; 

    // POSITIONS
    public Vector2 boardPosition;     
    public Vector2 characterPosition; 

    public float snapThreshold = 80f;

    public void OnDrag(PointerEventData eventData)
    {
        // seko pelei
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
{
    float distance = Vector2.Distance((Vector2)transform.localPosition, characterPosition);

    if (distance <= snapThreshold)
    {
        SwapWithExisting();
        transform.localPosition = (Vector3)characterPosition;
    }
    else
    {
        transform.localPosition = (Vector3)boardPosition;
    }

    CheckVisibilityAfterDrop();
}

private void CheckVisibilityAfterDrop()
{
    CategoryManager catManager = Object.FindFirstObjectByType<CategoryManager>();
    if (catManager != null)
    {
        bool isEquipped = Vector2.Distance((Vector2)transform.localPosition, characterPosition) < 1f;
        
        if (!isEquipped && category != catManager.currentCategory)
        {
            gameObject.SetActive(false);
        }
    }
}

private void SwapWithExisting()
{
    if (this.category == "Accessory") return; 

    ClothingDrag[] allClothes = transform.parent.GetComponentsInChildren<ClothingDrag>(true);
    foreach (ClothingDrag otherItem in allClothes)
    {
        if (otherItem != this)
        {
            bool isSameCategory = otherItem.category == this.category;
            bool isOnesieConflict = (this.category == "Onesie" && otherItem.category == "Outfit") || 
                                     (this.category == "Outfit" && otherItem.category == "Onesie");

            if (isSameCategory || isOnesieConflict)
            {
                if (Vector2.Distance((Vector2)otherItem.transform.localPosition, otherItem.characterPosition) < 1f)
                {
                    otherItem.transform.localPosition = (Vector3)otherItem.boardPosition;

                    UpdateVisibilityAfterKick(otherItem);
                }
            }
        }
    }
}

private void UpdateVisibilityAfterKick(ClothingDrag item)
{
    CategoryManager catManager = Object.FindFirstObjectByType<CategoryManager>();
    if (catManager != null)
    {   
        if (item.category != catManager.currentCategory)
        {
            item.gameObject.SetActive(false);
        }
    }
}
}