using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectMoveInScene : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector3 direction;
    private Vector3 playerPosition;
    private Transform player;

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
        Still,
        FlyToPlayer,
    }

    [SerializeField] private Move move;

    private void Start()
    {
        playerPosition = Player.instance.transform.position;

        UpdateMoveType(move);
    }
    
    

    private void Update()
    {
        if (move != Move.Still)
        {
            MoveWithDirection(direction.normalized);
        }

    }

    public void UpdateMoveType(Move _move)
    {
        move = _move;

        switch (move)
        {
            case Move.Still:
                direction = Vector3.down;
                break;
            case Move.Left:
                direction = Vector3.left;
                break;
            case Move.Right:
                direction = Vector3.right;
                break;
            case Move.Up:
                direction = Vector3.up;
                break;
            case Move.Down:
                direction = Vector3.down;
                break;
            case Move.UpLeft:
                direction = new Vector3(-1, 1, 0);
                break;
            case Move.UpRight:
                direction = new Vector3(1, 1, 0);
                break;
            case Move.DownRight:
                direction = new Vector3(1, -1, 0);
                break;
            case Move.DownLeft:
                direction = new Vector3(-1, -1, 0);
                break;
            case Move.FlyToPlayer:
                direction = playerPosition - transform.position;
                break;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    private void MoveWithDirection(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * moveSpeed;
    }
}
