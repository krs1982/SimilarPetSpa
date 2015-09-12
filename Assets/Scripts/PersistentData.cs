using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public PersistentData Instance;

    public static int scoreToSave;

    void Start()
    {
        DontDestroyOnLoad(this);
        if (Instance == null) Instance = this;
    }

    public void SaveScore(int score)
    {
        scoreToSave = score;
    }

}
