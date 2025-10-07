using UnityEngine;

public enum CropState { Empty, Growing, Harvestable }

public class FarmTile : MonoBehaviour
{
    public CropState state = CropState.Empty;
    private CropData cropData;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void PlantCrop(CropData data)
    {
        cropData = data;
        state = CropState.Growing;
       // sr.sprite = cropData.seedSprite;

        // Start crop growth timer
        var manager = TimerManager.Instance;
        var timer = manager.StartTimer(cropData.growDuration);
        timer.OnCompleted += OnGrowthComplete;
    }

    private void OnGrowthComplete()
    {
        state = CropState.Harvestable;
       // sr.sprite = cropData.harvestableSprite;
    }

    /// <summary>
    /// Harvest the crop and reset the tile.
    /// Returns cropId if harvested, or -1 if nothing to harvest.
    /// </summary>
    public CropType Harvest()
    {
        if (state != CropState.Harvestable || cropData == null)
            return CropType.None;

        string harvestedName = nameof(cropData.cropType);
        CropType harvestedCropType = cropData.cropType;

        Debug.Log($"Harvested: {harvestedName} (type: {harvestedCropType})");

        // Reset tile
        state = CropState.Empty;
        sr.sprite = null;
        cropData = null;

        // TODO: Future - send harvestedCropId to inventory system
        return harvestedCropType;
    }
}
