using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CodeBlockCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CodeBlock codeBlock;
    public bool isDropped=false;

    public TextMeshProUGUI codeSnippetText;
    private Canvas canvas;
    private RectTransform rectTransform;
    private Transform originalParent;
    private CanvasGroup canvasGroup;


    private void Start()
    {
        canvas = FindAnyObjectByType<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        codeSnippetText = GetComponentInChildren<TextMeshProUGUI>();
        codeSnippetText.text = codeBlock.codeSnippet;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(isDropped)
        {
            return;
        }

        transform.SetParent(originalParent);
        canvasGroup.blocksRaycasts = true;
    }
}
