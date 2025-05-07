using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCellUIContainer : MonoBehaviour
{
    public GameObject cellPrefab;
    public RectTransform gridParent;
    public int gridSize = 7;

    private GridLayoutGroup gridLayoutGroup;

    private void Start()
    {
        gridLayoutGroup = gridParent.GetComponent<GridLayoutGroup>();
        gridLayoutGroup.constraintCount = gridSize;
        GenerateRoomGridUI();
    }

    private void GenerateRoomGridUI()
    {
        int half = gridSize / 2;

        for (int row = 0; row < gridSize; row++)
        {
            int y = half - row;
            for (int col = 0; col < gridSize; col++)
            {
                int x = col - half;
                GameObject cell = Instantiate(cellPrefab, gridParent);
                RoomCellUI cellUI = cell.GetComponent<RoomCellUI>();
                cellUI.roomPos = new Vector2Int(x, y);
            }
        }


    }
}
