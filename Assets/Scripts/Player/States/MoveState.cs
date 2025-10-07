using UnityEngine;

namespace Player.States
{
    public class MoveState : IState
    {
        private readonly PlayerController _playerController;

        public MoveState(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Enter()
        {
            _playerController.Animator.Play("Move");
        }

        private Vector2 _movement;

        public void Update()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            _playerController.Animator.SetFloat("Horizontal", moveHorizontal);
            _playerController.Animator.SetFloat("Vertical", moveVertical);

            _movement = new Vector2(moveHorizontal, moveVertical);

            if (moveHorizontal != 0)
            {
                _playerController.SpriteRenderer.flipX = moveHorizontal < 0;
            }

            if (moveHorizontal == 0 && moveVertical == 0)
            {
                _playerController.StateMachine.TransitionTo(_playerController.IdleState);
            }
        }

        public void FixedUpdate()
        {
            _playerController.Rigidbody2D.linearVelocity = _movement * _playerController.moveSpeed;
        }

        public void Exit()
        {
            _playerController.Rigidbody2D.linearVelocity = Vector2.zero;
        }
    }
}
