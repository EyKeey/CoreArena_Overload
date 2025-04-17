using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//******************************************************************//
// <summary>
// CodeManager is a manager for chosen code blocks.
// It is responsible for executing the code blocks and managing the list of current codes.
// </summary>
//******************************************************************//

public class CodeManager : MonoBehaviour
{
    public static CodeManager instance;

    public List<CodeBlock> currentCodes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartExecution()
    {
        foreach (var code in currentCodes)
        {
            code.Execute();
        }
    }

    public bool AddCodeBlock(CodeBlock codeBlock)
    {
        if (currentCodes == null)
        {
            currentCodes = new List<CodeBlock>();
        }

        if(currentCodes.Contains(codeBlock))
        {
            Debug.LogWarning("Code block already exists in the list.");
            return false;
        }
        else
        {
            currentCodes.Add(codeBlock);
            return true;
        }
    }

    public void RemoveCodeBlock(CodeBlock codeBlock)
    {
        if (currentCodes == null || !currentCodes.Contains(codeBlock))
        {
            Debug.LogWarning("Code block not found in the list.");
            return;
        }
        else
        {
            currentCodes.Remove(codeBlock);
        }
    }
}
