using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public PlayerMovementController Movement { get; private set; }
    public PlayerInteractionController Interaction { get; private set; }
    public PlayerAnimationController Animation { get; private set; }
    public TileController currentTile { get; set; }
    protected override void Awake()
    {
        base.Awake();

        Movement = GetComponent<PlayerMovementController>();
        Interaction = GetComponent<PlayerInteractionController>();
        Animation = GetComponent<PlayerAnimationController>();
    }

    void Start()
    {
        InputManager.Instance.OnInteract += OnInteract;
    }

    void Update()
    {
        if (nearbyInteractables.Count > 0)
        {
            nearbyInteractables.ForEach(i => (i as TileController)?.ToggleHighlight(false));
            (nearbyInteractables[^1] as TileController)?.ToggleHighlight(true);
        }
    }

    private void OnInteract()
    {
        if (nearbyInteractables.Count > 0)
        {
            var item = nearbyInteractables[^1];
            if (item is TileController tile)
            {
                currentTile = tile;
            }
            Debug.Log("Interacting with " + item);
            item.Interact();
        }
    }

    private List<IInteractable> nearbyInteractables = new List<IInteractable>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            if (collision.TryGetComponent<IInteractable>(out var interactable) && !nearbyInteractables.Contains(interactable))
            {
                nearbyInteractables.Add(interactable);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            if (collision.TryGetComponent<IInteractable>(out var interactable))
            {
                nearbyInteractables.Remove(interactable);
                (interactable as TileController)?.ToggleHighlight(false);
            }
        }
    }
}
