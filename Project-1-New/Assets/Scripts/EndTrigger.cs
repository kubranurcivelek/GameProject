using UnityEngine;
using UnityEngine.SceneManagement;


public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;


    private void OnTriggerEnter()
    {
       gameManager.CompleteLevel();
    }



}
