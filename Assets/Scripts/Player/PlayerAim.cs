using System;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public Transform cursor;


    private void Update()
    {
        UpdateCursorPos();

        Aim();
    }

    private void Aim()
    {
        
    }

    private void UpdateCursorPos()
    {
        Vector2 lookPos = InputManager.Instance.lookInput;
        Vector2 lookWorldPos = Camera.main.ScreenToWorldPoint(lookPos);
        
        cursor.position = new Vector3(lookWorldPos.x, lookWorldPos.y, 0);
    }
}
