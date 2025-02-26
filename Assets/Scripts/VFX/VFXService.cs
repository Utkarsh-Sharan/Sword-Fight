using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXService
{
    public VFXService(EnemyVFXController enemyVFXController, PlayerVFXController playerVFXController, VFXScriptableObject vFXSOList)
    {
        enemyVFXController.Initialize(vFXSOList);
    }
}
