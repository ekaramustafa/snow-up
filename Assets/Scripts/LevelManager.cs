using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject finishLine;
    [SerializeField] GameObject player;
    Collider2D finishLinecollider;
    Collider2D playerCrashCollider;
    // Start is called before the first frame update
    private void Start()
    {
        finishLinecollider = finishLine.GetComponent<BoxCollider2D>();
        playerCrashCollider = player.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        isFinished();
        IsCrashed();
    }

    void KeyBindings()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //restart the game

        }
    }

    void isFinished()
    {
        if (finishLinecollider.IsTouchingLayers())
        {
            Debug.Log("You finished the level");
            
            //next level
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    void IsCrashed()
    {
        if (playerCrashCollider.IsTouchingLayers(LayerMask.GetMask("Environment")))
        {
            Debug.Log("Bro you crashed");
            //reset the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
