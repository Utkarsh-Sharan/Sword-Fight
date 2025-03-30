using System.Collections.Generic;

public class EnemyService
{
    private EnemyController _enemyController;
    private Dictionary<EnemyType, EnemyScriptableObject> _enemySODictionary;

    public EnemyService(EnemyController enemyController, List<EnemyScriptableObject> enemySOList)
    {
        _enemyController = enemyController;

        _enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();

        foreach (EnemyScriptableObject enemySO in enemySOList)
            _enemySODictionary[enemySO.EnemyType] = enemySO;

        CreateEnemyControllers();
    }

    private void CreateEnemyControllers()
    {
        TankEnemyController tankEnemyController = new TankEnemyController(_enemySODictionary[EnemyType.Tank]);
    }

    public void Dependency(PlayerService playerService) => _enemyController.InjectDependency(playerService);

    public EnemyType GetEnemyType() => _enemyController.GetEnemyType();
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => _enemyController.GetEnemySO(enemyType);
}
