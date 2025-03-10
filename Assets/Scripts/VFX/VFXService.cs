using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXService
{
    public VFXService(EnemyView enemyVFXController, PlayerView playerVFXController, VFXScriptableObject vFXSOList)
    {
        enemyVFXController.Initialize(vFXSOList);
    }
}
