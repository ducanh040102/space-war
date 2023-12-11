using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectMoveInScene : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public enum Move
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

    public Move move;

    private void Start()
    {
        switch (move)
        {
            case Move.DownRight:
                transform.Rotate(new Vector3(0, 0, 45)) ;
                break;
            case Move.DownLeft:
                transform.Rotate(new Vector3(0, 0, -45));
                break;

        }
    }

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
                MoveWithDirection(Vector3.left);
                MoveWithDirection(Vector3.up);
                break;
            case Move.DownLeft:
                MoveWithDirection(Vector3.left);
                MoveWithDirection(Vector3.down);
                break;
            case Move.UpRight:
                MoveWithDirection(Vector3.right);
                MoveWithDirection(Vector3.up);
                break;
            case Move.DownRight:
                MoveWithDirection(Vector3.right);
                MoveWithDirection(Vector3.down);
                break;
        }
    }

    private void MoveWithDirection(Vector3 direction)
    {
        transform.localPosition += direction * Time.deltaTime * moveSpeed;
    }
}
