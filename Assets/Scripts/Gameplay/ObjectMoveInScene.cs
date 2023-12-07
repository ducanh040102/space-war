using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveInScene : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private enum Move
    {
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        DownLeft,
        UpRight,
        DownRight,
        Still
    }

    [SerializeField] private Move move;

    private void Update()
    {
        switch (move)
        {
            case Move.Left:
                MoveWithDirection(Vector3.left);
                break;
            case Move.Right:
                MoveWithDirection(Vector3.right);
                break;
            case Move.Up:
                MoveWithDirection(Vector3.up);
                break;
            case Move.Down:
                MoveWithDirection(Vector3.down);
                break;
            case Move.UpLeft:
                MoveWithDirection(Vector3.up);
                MoveWithDirection(Vector3.left);
                break;
            case Move.DownLeft:
                MoveWithDirection(Vector3.left);
                MoveWithDirection(Vector3.down);
                break;
            case Move.UpRight:
                MoveWithDirection(Vector3.up);
                MoveWithDirection(Vector3.right); 
                break;
            case Move.DownRight:
                MoveWithDirection(Vector3.down);
                MoveWithDirection(Vector3.right);
                break;
        }
    }

    private void MoveWithDirection(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * moveSpeed;
    }
}
