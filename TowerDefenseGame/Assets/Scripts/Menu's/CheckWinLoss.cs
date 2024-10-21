using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWinLoss : MonoBehaviour
{
    public int WinPoints;
    public int LosePoints;
    void Start()
    {
        WinPoints = 0;
        LosePoints = 0;
    }

    void Update()
    {
        if (LosePoints > 19)
        {
            SceneManager.LoadSceneAsync(3);
        }
        else if (WinPoints > 59)
        {
            SceneManager.LoadSceneAsync(2);
        }
        else 
        {
            Debug.Log("niks");
        }
    }
}
