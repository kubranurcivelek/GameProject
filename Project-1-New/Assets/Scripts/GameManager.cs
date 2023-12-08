using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool isLevelComplete = false;
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public GameObject complateLevel;

    public void CompleteLevel()
    {
        this.isLevelComplete = true;
        complateLevel.SetActive(true);
    }


    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
        }
        Invoke("Restart", restartDelay);



    }

    public void Restart()
    {
        if (!isLevelComplete)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }




}
