using FiveMinutesFarmer.UI;
using UnityEngine;
public class EmptyState : BaseTileState
{
    public EmptyState(TileController tileController) : base(tileController) { }

    public override void OnEnter()
    {
        tileController.ResetTileVisuals();
    }

    public override void OnUpdate()
    {

    }
    public override void Interact()
    {
        base.Interact();
        UIManager.Instance.ToggleInteractionMenu(tileController);
    }
}
