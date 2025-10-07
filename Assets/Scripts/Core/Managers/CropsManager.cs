using System.Collections.Generic;
using UnityEngine;

public class CropsManager : Singleton<CropsManager>
{
    [SerializeField] private List<CropData> crops = new List<CropData>();

    public CropData GetCropDetails(CropType cropType)
    {
        return crops.Find(c => c.cropType == cropType);
    }

    public List<CropData> GetAllCrops()
    {
        return crops;
    }
}
