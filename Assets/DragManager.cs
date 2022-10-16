using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragManager : MonoBehaviour
{
    public UnityEvent<Vector2Int> onMove;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Move(Vector2Int.up);
        if (Input.GetKeyDown(KeyCode.S)) Move(Vector2Int.down);
        if (Input.GetKeyDown(KeyCode.A)) Move(Vector2Int.left);
        if (Input.GetKeyDown(KeyCode.D)) Move(Vector2Int.right);
    }

    private void Move(Vector2Int direction)
    {
        //print(direction);
        onMove?.Invoke(direction);  
    }
    public void OnChangeDirection(Vector2 vector)
    {
        //print(vector);
        if(Math.Abs(vector.x) > Math .Abs( vector.y))
        {
            if (vector.x > 0)
                Move(Vector2Int.right);
            else
                Move(Vector2Int.right);
        }
        else
        {
            if (vector.y > 0)
                Move(Vector2Int.up);
            else
                Move(Vector2Int.down);
        }
    }
}
