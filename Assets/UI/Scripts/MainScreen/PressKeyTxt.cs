using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressKeyTxt : MonoBehaviour
{
                     private float       flashTime           = 0.5f;
                     private float       flashTimeTransition = 0.15f;
                     private float       switchSceneTime     = 2f;
                     public  int         nextScene           = 1;
                     private AudioSource audioSrc;
    [SerializeField] private AudioClip   keyPressedSFX;
                     private bool        canPressKey         = true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlashText());
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canPressKey == true)
        {
            if (Input.anyKeyDown)   {  StartCoroutine(SwitchScene());  }
        }
    }

    private IEnumerator FlashText()
    {
        yield return new WaitForSeconds(flashTime);
        gameObject.transform.localScale = new Vector3(0, 0);
        yield return new WaitForSeconds(flashTime);
        gameObject.transform.localScale = new Vector3(1, 1);
        StartCoroutine(FlashText());
    }

    private IEnumerator SwitchScene()
    {
        canPressKey = false;
        audioSrc.PlayOneShot(keyPressedSFX);
        flashTime = flashTimeTransition;
        yield return new WaitForSeconds(switchSceneTime);
        SceneManager.LoadScene(nextScene);
    }
}
