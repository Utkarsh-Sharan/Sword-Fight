using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionCollider : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>())
            this._enemyController.IsPlayerInDetectionZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerView>())
            this._enemyController.IsPlayerInDetectionZone = false;
    }
}
