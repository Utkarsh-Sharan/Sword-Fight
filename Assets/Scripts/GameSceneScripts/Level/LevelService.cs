using System.Collections.Generic;

public class LevelService
{
    private LevelController _levelController;

    public LevelService(LevelController levelController, LevelScriptableObject levelSO)
    {
        _levelController = levelController;
        _levelController.Initialize(levelSO);
    }
}
