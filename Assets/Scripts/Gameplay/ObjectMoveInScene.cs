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
        }
    }

    private void MoveWithDirection(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * moveSpeed;
    }
}
