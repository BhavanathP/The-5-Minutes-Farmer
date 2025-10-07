using UnityEngine;
using FiveMinutesFarmer.UI;

public class ShopInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ShopManager.Instance.ToggleShop();
    }
}
