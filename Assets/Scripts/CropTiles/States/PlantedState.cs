using FiveMinutesFarmer.UI;
using UnityEngine;

public class PlantedState : BaseTileState
{
    public PlantedState(TileController tileController) : base(tileController) { }
    private float timer;
    public override void OnEnter()
    {
        tileController.UpdateVisuals();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        tileController.cropSpriteRenderer.sprite = tileController.CurrentCrop.seedSprite[0];
    }

    public override void Interact()
    {
        base.Interact();
        UIManager.Instance.ToggleInteractionMenu(tileController);
    }
}
