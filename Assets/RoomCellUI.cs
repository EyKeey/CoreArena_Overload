using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomCellUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private Sprite fullRoomSprite;
    [SerializeField] private Sprite emptyRoomSprite;
    [SerializeField] private Sprite notAvailableSprite;

    public Vector2Int roomPos;
    private bool isOccupied = false;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        
        UpdateUI();
    }

    public void UpdateUI()
    {
        isOccupied = MapManager.instance.IsRoomOccupied(roomPos);

        // Update the UI based on the room's state
        if (isOccupied)
        {
            Color color = image.color;
            color.a = 1;
            image.color = color;


            image.sprite = fullRoomSprite;
        }
        else if (MapManager.instance.IsAdjacentRoom(roomPos))
        {
            Color color = image.color;
            color.a = 1;
            image.color = color;


            image.sprite = emptyRoomSprite;
        }
        else
        {
            Color color = image.color;
            color.a = 0;
            image.color = color;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (MapManager.instance.PlaceRoom(roomPos))
        {
            Debug.Log("Room placed at: " + roomPos);
            Destroy(eventData.pointerDrag); // Destroy the dragged room prefab
        }
        else
        {
            Debug.Log("Failed to place room at: " + roomPos);
        }

        UpdateUI();
    }
}
