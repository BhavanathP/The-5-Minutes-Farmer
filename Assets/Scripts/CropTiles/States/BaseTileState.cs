using UnityEngine;

public abstract class BaseTileState
{
    protected readonly TileController tileController;

    public BaseTileState(TileController tileController)
    {
        this.tileController = tileController;
    }

    public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
    public virtual void Interact() { }
}
