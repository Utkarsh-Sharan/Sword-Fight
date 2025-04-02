using UnityEngine;

public class PlayerDetectionTrigger : MonoBehaviour
{
    private EnemyView _enemyView;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyView enemyView))
            _enemyView = enemyView;

        if (other.GetComponent<PlayerView>())
            _enemyView.IsPlayerInDetectionZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerView>())
            _enemyView.IsPlayerInDetectionZone = false;
    }
}
