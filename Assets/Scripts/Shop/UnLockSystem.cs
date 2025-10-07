using System.Collections.Generic;
using UnityEngine;

public class UnLockSystem : MonoBehaviour
{
    private HashSet<CropType> unlockedCrops = new HashSet<CropType>();

    public void UnlockCrop(CropType _cropType)
    {
        unlockedCrops.Add(_cropType);
    }

    public bool IsCropUnlocked(CropType _cropType)
    {
        return unlockedCrops.Contains(_cropType);
    }
}
