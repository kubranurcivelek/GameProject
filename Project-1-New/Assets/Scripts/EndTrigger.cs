using UnityEngine;
using UnityEngine.SceneManagement;


public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;


    private void OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //gameManager.CompleteLevel();
    }



}
