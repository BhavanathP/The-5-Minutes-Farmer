using UnityEngine;

public class GrowingState : BaseTileState
{
    private float growthTimer;

    public GrowingState(TileController tileController) : base(tileController) { }

    public override void OnEnter()
    {
        tileController.UpdateVisuals();
        growthTimer = tileController.CurrentCrop.growDuration;
    }

    public override void OnUpdate()
    {
        growthTimer -= Time.deltaTime;
        tileController.cropSpriteRenderer.sprite = tileController.CurrentCrop.growingSprite[(int)((tileController.CurrentCrop.growDuration - growthTimer) / tileController.CurrentCrop.growDuration * (tileController.CurrentCrop.growingSprite.Length - 1))];
        if (growthTimer + 1 <= 0)
        {
            tileController.TransitionToState(new HarvestableState(tileController));
        }
    }
}
