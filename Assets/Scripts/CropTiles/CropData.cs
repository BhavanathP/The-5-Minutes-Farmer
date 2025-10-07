using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CropData")]
public class CropData : ScriptableObject
{
    public CropType cropType;
    public float growDuration = 60f; // total time in seconds
    public int value = 10; // Score value when harvested
    public int buyPrice;
    public int sellValue;

    [Header("Visuals")]
    public Sprite[] seedSprite;
    public Sprite[] growingSprite;
    public Sprite[] harvestableSprite;
}
