using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMan : MonoBehaviour
{

    [SerializeField] AudioClip[] playlist;
    AudioSource audioSource;
    public static MusicMan instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = playlist[SceneManager.GetActiveScene().buildIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Singleton

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    #endregion
}
