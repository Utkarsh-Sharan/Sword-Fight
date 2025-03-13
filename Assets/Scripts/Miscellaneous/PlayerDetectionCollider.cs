using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionCollider : MonoBehaviour
{
    private EnemyController _enemyController;

    public void Initialize(EnemyController enemyController)
    {
        this._enemyController = enemyController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>()) { }
            //send info to THIS enemy controller that player entered range
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>()) { }
            //send info to THIS enemy controller that player exited range
    }
}
