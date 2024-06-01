using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static bool hasInstance => instance != null;
    public static T GetInstance() => hasInstance ? instance : null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    var obj = new GameObject(typeof(T).Name + "Auto Generated");
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }

    }

    protected virtual void Awake()
    {
        InitSingleton();
    }

    protected virtual void InitSingleton()
    {
        if (!Application.isPlaying) return;

        instance = this as T;
    
    }
}
