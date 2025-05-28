using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected bool endedMinigame = false;

    [SerializeField] protected AudioClip winSound;
    [SerializeField] protected GameObject clipPlayer;
    [SerializeField] protected GameObject winScreen;

    protected void Start()
    {
        GameManager.Instance.AllowPlayerMovement(false);
    }

    protected void Update()
    {
        if (HasWon() && !endedMinigame)
        {
            endedMinigame = true;
            StartCoroutine("EndMinigame");
        }

    }

    protected abstract bool HasWon();

    protected IEnumerator EndMinigame()
    {
        // Play Audio
        Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(winSound);

        // Show winning screen
        Instantiate(winScreen, this.transform);

        Debug.Log("Show Winning Screen");

        yield return new WaitForSeconds(winSound.length);

        GameManager.Instance.AllowPlayerMovement(true);

        Destroy(this.gameObject);

    }

}
