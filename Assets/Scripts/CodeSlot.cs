using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CodeSlot : MonoBehaviour, IDropHandler
{
    public CodeBlockType acceptedType;
    public List<CodeBlockCard> assignedBlocks;


    public void OnDrop(PointerEventData eventData)
    {
        var draggedObject = eventData.pointerDrag;
        if (draggedObject != null)
        {
            var block = draggedObject.GetComponent<CodeBlockCard>();
            if (block != null && block.codeBlock.blockType == acceptedType)
            {
                assignedBlocks.Add(block);
                block.GetComponent<CodeBlockCard>().isDropped = true;
                block.transform.SetParent(transform);
                block.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
            else
            {
                Debug.Log("Invalid Code Block Type");
            }
        }
    }
}
