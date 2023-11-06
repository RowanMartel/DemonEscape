using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    [SerializeField] TMP_Text credits;
    [SerializeField] TMP_Text continueText;

    [SerializeField] float creditsSpeed;
    [SerializeField] float alphaSpeed;

    GameManager gameManager;

    private void Start()
    {
        gameManager = Singleton.Instance.GetComponentInChildren<GameManager>();
    }

    void Update()
    {
        credits.transform.position += new Vector3(0, creditsSpeed * Time.deltaTime);
        if (credits.transform.position.y >= 1700)
        {
            continueText.alpha += alphaSpeed * Time.deltaTime;
        }

        if (Input.anyKeyDown)
        {
            gameManager.LoadScene(Constants.titleScreenSceneIndex);
        }
    }
}