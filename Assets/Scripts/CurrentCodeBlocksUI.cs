using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentCodeBlocksUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var draggedObject = eventData.pointerDrag;
        if (draggedObject != null)
        {
            var block = draggedObject.GetComponent<CodeBlockCard>();
            if (block != null)
            {
                block.GetComponent<CodeBlockCard>().isDropped = true;
                block.transform.SetParent(transform);
                block.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
    }
}
