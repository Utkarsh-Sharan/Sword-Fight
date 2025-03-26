using System.Collections.Generic;

public class LevelService
{
    private LevelController _levelController;

    public LevelService(LevelController levelController, List<LevelScriptableObject> levelSOList)
    {
        _levelController = levelController;
        _levelController.Initialize(levelSOList);
    }
}
