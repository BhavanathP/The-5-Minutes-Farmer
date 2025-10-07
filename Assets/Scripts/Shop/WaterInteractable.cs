using FiveMinutesFarmer.UI;
using UnityEngine;

public class WaterInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        UIManager.Instance.ToggleInteractionMenu(null, true);
        Debug.Log("Fetched 3 water");
    }
}
