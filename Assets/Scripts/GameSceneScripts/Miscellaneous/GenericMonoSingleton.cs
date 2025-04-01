using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
{
    private static T _instance;
    public static T Instance { get { return _instance; } }

    protected virtual void Awake()
    {
        if(_instance == null)
        {
            _instance = (T)this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
