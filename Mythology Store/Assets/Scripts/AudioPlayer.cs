using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;

    void Update()
    {
        if(audioSource.isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }

}
