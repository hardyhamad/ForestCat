using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Enemy_Fail : MonoBehaviour
{
    private GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.LifeLost_Meow;
            SoundManager.Instance.SFX_Source.Play();
            player = other.gameObject;
            Invoke(nameof(DestroyPlayer), 1f);
        }
    }
    private void DestroyPlayer()
    {

        GameManager.Instance.LivesUpdate();

    }
 
}
