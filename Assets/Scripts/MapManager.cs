using System;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    
    public int gridSize = 10;
    public float cellSpacing = 10f;
    public Transform gridParent;

    public GameObject roomPrefab;
    public GameObject centerRoomPrefab;

    private Dictionary<Vector2Int, GameObject> roomGrid = new Dictionary<Vector2Int, GameObject>();
    private Dictionary<Vector2Int, RoomCellUI> roomCellUI = new Dictionary<Vector2Int, RoomCellUI>();

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

    private void Start()
    {
        GenerateMap();
        PlaceCenterRoom();
    }

    private void PlaceCenterRoom()
    {
        Vector2Int center = new Vector2Int(0, 0);
        Vector3 worldPos = GridToWorld(center);

        var room = Instantiate(centerRoomPrefab, worldPos, Quaternion.identity, gridParent);
        roomGrid[center] = room;
    }

    public bool PlaceRoom(Vector2Int gridPos)
    {
        if(IsRoomOccupied(gridPos)) return false;

        if(!IsAdjacentRoom(gridPos)) return false;

        var room = Instantiate(roomPrefab, GridToWorld(gridPos), Quaternion.identity, gridParent);
        roomGrid[gridPos] = room;


        UpdateAdjUI(gridPos);
        
        return true;

    }

    private void UpdateAdjUI(Vector2Int gridPos)
    {
        throw new NotImplementedException();
    }

    private void GenerateMap()
    {
        for (int i = -gridSize / 2; i <= gridSize / 2; i++)
        {
            for (int j = -gridSize / 2; j<= gridSize /2; j++)
            {
                Vector2Int pos = new Vector2Int(i, j);
                roomGrid[pos] = null;
            }
        }

    }
    
    private Vector3 GridToWorld(Vector2Int gridPos)
    {
        return new Vector3(gridPos.x * cellSpacing, gridPos.y * cellSpacing, 0);
    }

    public bool IsRoomOccupied(Vector2Int gridPos)
    {
        return roomGrid.ContainsKey(gridPos) && roomGrid[gridPos] != null;
    }

    public bool IsAdjacentRoom(Vector2Int gridPos)
    {
        Vector2Int[] neighbors = {
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(-1, 0)
        };

        foreach (var neighbor in neighbors)
        {
            if (roomGrid.ContainsKey(gridPos + neighbor) && roomGrid[gridPos + neighbor] != null)
            {
                return true;
            }
        }

        return false;
    }
}
