using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region ¼üÖµ
    public static KeyCode Up = KeyCode.W;
    public static KeyCode Down = KeyCode.S;
    public static KeyCode Left = KeyCode.A;
    public static KeyCode Right = KeyCode.D;
    public static KeyCode ManuKey = KeyCode.Escape;
    #endregion
    #region µ¥Àý
    public static GameManager instance;

    public static GameManager Instance
    { 
        get 
        { 
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
                if(instance == null)
                {
                    GameObject gameObject = new GameObject("GameManager");
                    instance = gameObject.AddComponent<GameManager>();
                    DontDestroyOnLoad(gameObject);
                    Debug.Log("GameManager Created!");
                }
            }
            return instance; 
        } 
    }
    #endregion
    [SerializeField] private static int AllLevels = 6;
    [SerializeField] private int CurLevel = 1;
    [SerializeField] private int[] AllLevelsMoveTimes = new int[AllLevels];
    [SerializeField] private CharacterMove WhiteSnake;
    [SerializeField] private CharacterMove BlackSnake;
    private int moveTimes;
    public int MoveTimes
    {
        get { return moveTimes; }
        set
        {
            moveTimes = value;
            if (moveTimes == 0)
            {
                TimeOver();
            }
        }
    }

    void TimeOver()
    {

    }
    void ChangeLevel(int Level)
    {

    }
}
