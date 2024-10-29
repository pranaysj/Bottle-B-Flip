using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Level level;
    [Header("Canvas Panels")]
    public CanvasButtons panels;

    public int coinCollected;

    //private void Start()
    //{
    //    level = GetComponent<Level>();
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("frame"))
        {
            var frame = collision.gameObject;

            Animator animator = frame.GetComponentInParent<Animator>();

            animator.SetBool("frameslide", true);
        }

        if (collision.gameObject.CompareTag("finishPoint"))
        {
            var frame = collision.gameObject;

            level.levelNumber = level.levelNumber + 1;

            coinCollected = coinCollected + 100;
            Coins.instance.coins += coinCollected;

            panels.levelPanel.SetActive(false);
            panels.finishPanel.SetActive(true);
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            Invoke("InvokeRestart", 0.55f);
        }
    }


    public void InvokeRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
