using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { if (!gameStart) Init(); return s_instance; } }

    static Object _lock = new Object();
    static bool gameStart = false;

    #region Instances
    DataManager _data = new DataManager();
      private static GameManagerEx s_gameManager = new GameManagerEx();
    
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();

    ResourceManager _resource = new ResourceManager() ; 

    public static DataManager Data { get { return Instance._data; } }
      public static GameManagerEx Game { get { Init(); return s_gameManager; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    #endregion

    private void start()
    {
        Init();
      
    }
    static void Init()
    {
        gameStart = true;
        if(s_instance == null)
        {
            lock (_lock)
            {
                GameObject go = GameObject.Find("@Managers");
                if(go == null)
                {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<Managers>();
                }
                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();
                 s_instance._data.Init();
                   s_instance._sound.Init();

            }
     
        }
    }
}
