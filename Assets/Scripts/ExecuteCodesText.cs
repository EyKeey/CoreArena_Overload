using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExecuteCodesText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private Dictionary<CodeBlockType, string> headers = new Dictionary<CodeBlockType, string>() 
    {
        {CodeBlockType.Player,  "#Player"},
        {CodeBlockType.Weapon,  "#Weapon"},
        {CodeBlockType.Environment,  "#Enviroment"},
        {CodeBlockType.Level,  "#Level"},
        {CodeBlockType.Enemy,  "#Enemy"},
    };

    private Dictionary<CodeBlockType, string> content = new Dictionary<CodeBlockType, string>()
    {
        {CodeBlockType.Player,  null},
        {CodeBlockType.Weapon,  null},
        {CodeBlockType.Environment,  null},
        {CodeBlockType.Level,  null},
        {CodeBlockType.Enemy,  null},
    };

    private string baseText = "Execute\n\n";

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
        text.text = baseText;
    }

    public void AddCodeToSlot(CodeBlockType slot, string codeLine)
    {
        if (!string.IsNullOrEmpty(content[slot]))
            content[slot] += "\n";

        content[slot] += codeLine;

        UpdateText(slot);
    }

    public void UpdateText(CodeBlockType changedCodeType)
    {
        string fullText = baseText;

        foreach (var header in headers.Keys)
        {
            if (content[header] != null)
            {
                fullText += headers[header] + "\n\n";
                fullText += content[header] + "\n\n";
            }
        }

        text.text = fullText;
        text.maxVisibleCharacters = 0;


        DOTween.To(() => text.maxVisibleCharacters,
                   x => text.maxVisibleCharacters = x,
                   fullText.Length,
                   fullText.Length * 0.015f)
               .SetEase(Ease.Linear);
    }

    

}
