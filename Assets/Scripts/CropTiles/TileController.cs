using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] // This renderer will be for the tile's background
public class TileController : MonoBehaviour, IInteractable
{
    [Header("References")]
    public SpriteRenderer highlightSpriteRenderer; // The SpriteRenderer used for highlighting the tile
    [Tooltip("The SpriteRenderer used to display the current crop state (seed, growing, harvestable).")]
    public SpriteRenderer cropSpriteRenderer;

    [Header("VFX")]
    public GameObject pourWaterVFX;
    public GameObject plantSeedVFX;
    public GameObject harvestCropVFX;

    public CropData CurrentCrop
    { get; private set; }
    private BaseTileState currentState;

    internal EmptyState emptyState;
    internal PlantedState plantedState;
    internal GrowingState growingState;
    internal HarvestableState harvestableState;

    private void Start()
    {
        emptyState = new EmptyState(this);
        plantedState = new PlantedState(this);
        growingState = new GrowingState(this);
        harvestableState = new HarvestableState(this);
        TransitionToState(emptyState);
    }

    private void Update()
    {
        currentState?.OnUpdate();
    }

    public void TransitionToState(BaseTileState state)
    {
        currentState?.OnExit();
        currentState = state;
        currentState.OnEnter();
    }

    public void SetCrop(CropData crop)
    {
        CurrentCrop = crop;
    }

    public void ResetTile()
    {
        CurrentCrop = null;
    }

    public void UpdateVisuals()
    {
        if (cropSpriteRenderer == null)
        {
            Debug.LogWarning("Crop Sprite Renderer is not assigned on " + gameObject.name);
            return;
        }

        if (CurrentCrop == null)
        {
            ResetTileVisuals();
            return;
        }

        if (currentState is PlantedState)
        {
            //cropSpriteRenderer.sprite = CurrentCrop.seedSprite;
            plantSeedVFX.SetActive(true);
            Invoke(nameof(DisablePlantVFX), 0.5f);
        }
        else if (currentState is GrowingState)
        {
            //cropSpriteRenderer.sprite = CurrentCrop.growingSprite;
            pourWaterVFX.SetActive(true);
            Invoke(nameof(DisableWaterVFX), 0.5f);
        }
        else if (currentState is HarvestableState)
        {
            //cropSpriteRenderer.sprite = CurrentCrop.harvestableSprite;
            harvestCropVFX.SetActive(true);
            Invoke(nameof(DisableHarvestVFX), 0.5f);
        }
    }

    private void DisablePlantVFX()
    {
        plantSeedVFX.SetActive(false);
    }
    private void DisableWaterVFX()
    {
        pourWaterVFX.SetActive(false);
    }
    private void DisableHarvestVFX()
    {
        harvestCropVFX.SetActive(false);
    }

    public void ResetTileVisuals()
    {
        if (cropSpriteRenderer != null)
        {
            cropSpriteRenderer.sprite = null;
        }
    }

    public void Interact()
    {
        currentState.Interact();
    }

    public void ToggleHighlight(bool isHighlighted)
    {
        if (highlightSpriteRenderer != null)
        {
            highlightSpriteRenderer.enabled = isHighlighted;
        }
    }

    public BaseTileState GetCurrentState()
    {
        return currentState;
    }
}
