using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{

    [SerializeField] protected AudioClip winSound;
    [SerializeField] protected GameObject clipPlayer;
    [SerializeField] protected GameObject winScreen;

    public void StartEndGame()
    {
        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame()
    {
        GameManager.Instance.StopMovement();
        // Play Audio
        Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(winSound);

        // Show winning screen
        Instantiate(winScreen, GameObject.FindWithTag("MainCanvas").transform).transform.SetAsFirstSibling();

        Debug.Log("Show Winning Screen");

        yield return new WaitForSeconds(winSound.length);

        SceneManager.LoadScene("Win Game");
    }

    public void PlayAgain()
    {
        Destroy(GameManager.Instance);
        SceneManager.LoadScene("Grocery Store");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

}
