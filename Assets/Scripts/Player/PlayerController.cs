using Player;
using Player.States;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public StateMachine StateMachine;
    public IdleState IdleState;
    public MoveState MoveState;

    public Rigidbody2D Rigidbody2D;
    public CapsuleCollider2D CapsuleCollider2D;
    public Grid Grid;
    public Animator Animator;
    public SpriteRenderer SpriteRenderer;


    private void Awake()
    {
        StateMachine = new StateMachine();

        IdleState = new IdleState(this);
        MoveState = new MoveState(this);

    }

    private void Start()
    {
        // if (Grid != null)
        // {
        //     // Snap player to the center of the nearest cell on start
        //     Vector3Int cell = Grid.WorldToCell(transform.position);
        //     transform.position = Grid.GetCellCenterWorld(cell);
        // }
        StateMachine.TransitionTo(IdleState);
    }

    private void Update()
    {
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }
}
