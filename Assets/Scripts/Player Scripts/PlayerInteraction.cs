using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody rb;
    private bool playerDied;
    private CameraFollow cameraFollow;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }
    void Update()
    {
        if (!playerDied)
        {
            if (rb.velocity.sqrMagnitude > 60)
            {
                playerDied = true;
                cameraFollow.CanFollow = false;

                //SoundManager.instance.GameEndSound();
                //GameplayController.instance.RestartGame();
            }
        }
    }//update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            other.gameObject.SetActive(false);

            SoundManager.instance.PickedUpCoin();
            //GameplayController.instance.IncrementScore();
        }
        if (other.gameObject.tag == "Spike")
        {
            cameraFollow.CanFollow = false;
            gameObject.SetActive(false);

            SoundManager.instance.GameEndSound();
            //GameplayController.instance.Restart();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EndPlatform")
        {
            SoundManager.instance.GameEndSound();
            //GameplayController.instance.Restart();
        }
    }
}
