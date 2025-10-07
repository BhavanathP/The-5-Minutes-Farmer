using FiveMinutesFarmer.UI;
using UnityEngine;

public class HarvestableState : BaseTileState
{
    public HarvestableState(TileController tileController) : base(tileController) { }

    public override void OnEnter()
    {
        tileController.UpdateVisuals();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        tileController.cropSpriteRenderer.sprite = tileController.CurrentCrop.harvestableSprite[0];
    }
    public override void Interact()
    {
        base.Interact();
        UIManager.Instance.ToggleInteractionMenu(tileController);
    }
}
