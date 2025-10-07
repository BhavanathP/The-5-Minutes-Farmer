using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private float interactRange = 1f;
    [SerializeField] private LayerMask interactableLayer;

    private Vector2 lastMoveDir = Vector2.down;

    private void OnEnable()
    {
        // InputManager.Instance.OnMove += UpdateFacing;
        // InputManager.Instance.OnInteract += TryInteract;
    }

    private void OnDisable()
    {
        // InputManager.Instance.OnMove -= UpdateFacing;
        // InputManager.Instance.OnInteract -= TryInteract;
    }

    private void UpdateFacing(Vector2 moveInput)
    {
        if (moveInput.sqrMagnitude > 0.1f)
        {
            lastMoveDir = moveInput.normalized;
        }
    }

    private void TryInteract()
    {
        Vector2 pos = (Vector2)transform.position;
        Vector2 target = pos + lastMoveDir * interactRange;

        RaycastHit2D hit = Physics2D.Raycast(pos, lastMoveDir, interactRange, interactableLayer);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact();
            }
        }
    }
}
