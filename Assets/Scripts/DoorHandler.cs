using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public Animator anim;
    public float scaleSpeed = 0.5f; // Adjust as needed
    public float moveSpeed = 1.0f; // Speed of moving to the disable point
    public float minScale = 1f; // Minimum scale value before deactivating
    private bool scalingDown = false;
    public Transform disablePoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !scalingDown)
        {
            SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Level_Complete_Sound;
            SoundManager.Instance.SFX_Source.Play();

            other.GetComponent<PlayerMovement>().enabled = false;
            CameraFollow.Instance.player = null;
            // Destroy Rigidbody2D component
            Destroy(other.GetComponent<Rigidbody2D>());
            scalingDown = true;
            StartCoroutine(ScaleDownAndMoveAndDeactivate(other.gameObject));
        }
    }

    IEnumerator ScaleDownAndMoveAndDeactivate(GameObject obj)
    {
        // Gradually scale down the object and move it to the disable point
        while (obj.transform.localScale.x > minScale)
        {
            obj.transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, disablePoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure scale is set to the minimum
        obj.transform.localScale = Vector3.one * minScale;

        // Move the object to the disable point
        obj.transform.position = disablePoint.position;
        // Trigger door closing animation
        DoorCloseAnim();
        // Deactivate the object
        obj.SetActive(false);

        // Call GameManager's LevelComplete method
        yield return new WaitForSeconds(1f);

        GameManager.Instance.LevelComplete();
    }

    private void DoorCloseAnim()
    {
        anim.SetBool("close", true);
    }
}
