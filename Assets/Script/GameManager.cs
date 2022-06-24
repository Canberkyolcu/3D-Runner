using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private NewBehaviourScript playerController;
    private bool isGameEnding = false;







    void Start()
    {
        playerController = FindObjectOfType<NewBehaviourScript>();


    }

    void Uptade()
    {

    }



    public void RespawnPlayer()
    {
        if (isGameEnding == false)
        {

            isGameEnding = true;
            StartCoroutine(RespawnDelay());
            StartCoroutine(RespawnCornuTime());


        }


    }




    public IEnumerator RespawnCornuTime()
    {
        playerController.forForce = 0f;
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        playerController.transform.position = playerController.respawnPoint;
        playerController.gameObject.SetActive(true);
        isGameEnding = true;
        SceneManager.LoadScene(4);


    }


    public IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Goldtext.coinAmount = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Goldtext.coinAmount += 1;
            Destroy(gameObject);
        }
    }

    public void level2()
    {
        SceneManager.LoadScene(2);
    }

    public void level3()
    {
        SceneManager.LoadScene(3);
    }

    public void anamenu()
    {
        SceneManager.LoadScene(0);
    }

}
