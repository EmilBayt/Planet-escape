using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;

    AudioSource audioSource;

    bool isTransitioning = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (!isTransitioning)
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("You are launching");
                    break;
                case "Finish":
                    StartSuccesSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        crashParticle.Play();
        GetComponent<Mover>().enabled = false;
        Invoke("ReloadLevel", delayTime);
    }

    void StartSuccesSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        successParticle.Play();
        GetComponent<Mover>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }

    void ReloadLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = sceneIndex + 1;
        //int amountOfScenes = SceneManager.GetAllScenes().Length;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        /*if (sceneIndex + 1 != amountOfScenes)
            SceneManager.LoadScene(sceneIndex + 1);
        else SceneManager.LoadScene(0);*/
    }
}
