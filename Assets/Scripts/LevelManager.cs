using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject finishLine;
    [SerializeField] GameObject player;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] ParticleSystem crashEffect;

    Collider2D finishLinecollider;
    Collider2D playerCrashCollider;

    [SerializeField, Range (0f,2f)] float loadDelay = 0.25f;
    // Start is called before the first frame update
    private void Start()
    {
        finishLinecollider = finishLine.GetComponent<BoxCollider2D>();
        playerCrashCollider = player.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        IsFinished();
        IsCrashed();
        KeyBindings();
    }

    void KeyBindings()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Invoke("ReloadScene",loadDelay);

        }
    }

    void IsFinished()
    {
        if (finishLinecollider.IsTouchingLayers())
        {
            //next level
            finishEffect.Play();
            Invoke("NextLevel", loadDelay);
        }
    }

    void IsCrashed()
    {
        if (playerCrashCollider.IsTouchingLayers(LayerMask.GetMask("Environment")))
        {
            player.GetComponent<Rigidbody2D>().simulated = false;
            crashEffect.Play();
            //reset the game
            Invoke("ReloadScene", loadDelay);
            }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.GetComponent<Rigidbody2D>().simulated = true;
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
}
