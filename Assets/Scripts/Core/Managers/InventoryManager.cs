using System.Collections.Generic;
using UnityEngine;
using FiveMinutesFarmer.UI;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private List<Crops> crops = new List<Crops>();
    private int waterCount;
    public int WaterCount => waterCount;

    private void Start()
    {
        waterCount = 2; // Starting water amount
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.Instance.ToggleInventory();
        }
    }

    public void AddCrop(CropType type, int value)
    {
        if (crops.Exists(c => c.cropType == type))
        {
            var crop = crops.Find(c => c.cropType == type);
            crop.count += value;
            return;
        }
        else
            crops.Add(new Crops { cropType = type, count = value });
    }
    public void UseCrop(CropType type)
    {
        if (crops.Exists(c => c.cropType == type))
        {
            var crop = crops.Find(c => c.cropType == type);
            if (crop.count > 0)
                crop.count--;
            else
                Debug.LogWarning($"No {type} left in inventory!");
        }
        else
            Debug.LogWarning($"No {type} in inventory!");
    }

    public List<Crops> GetCropDetails()
    {
        return crops;
    }

    public void FetchWater(int amount)
    {
        waterCount += amount;
    }

    public void UseWater(int amount)
    {
        if (waterCount >= amount)
            waterCount -= amount;
        else
            Debug.LogWarning("Not enough water!");
    }
}

[System.Serializable]
public class Crops
{
    public CropType cropType;
    public int count;
}
