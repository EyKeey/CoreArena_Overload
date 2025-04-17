using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExecutePanel : MonoBehaviour, IDropHandler
{
    private ExecuteCodesText executeCodesText;

    private void Start()
    {
        executeCodesText = FindAnyObjectByType<ExecuteCodesText>();
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject obj = eventData.pointerDrag;
        CodeBlock codeBlock = obj.GetComponent<CodeBlockCard>().codeBlock;

        if (CodeManager.instance.AddCodeBlock(codeBlock))
        {
            executeCodesText.AddCodeToSlot(codeBlock.blockType, codeBlock.codeSnippet);
            Destroy(obj);
        }
    }
}
