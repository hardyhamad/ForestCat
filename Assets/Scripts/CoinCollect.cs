using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Lopa");
        if(other.tag =="Player")
        {
            SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Coin_Sound;
            SoundManager.Instance.SFX_Source.Play();

            GameManager.Instance.CoinsUpdate();
            gameObject.SetActive(false);
            Invoke(nameof(DestroyCoin),1f);
        }
    }
    private void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
