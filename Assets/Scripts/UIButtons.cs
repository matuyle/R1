using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIButtons : MonoBehaviour
{
    public GameObject panel;
    public GameObject midPart;
    public Button restart;
    public Button quit;
    public Image doubleJumpImage;
    Image bg;

    bool isBgShowing;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.onGameEndE += OnGameEnd;
        EventManager.onShowDoubleJumpE += OnShowDoubleJumpIcon;
        bg = panel.GetComponent<Image>();
        restart.onClick.AddListener(Restart);
        quit.onClick.AddListener(Quit);
    }

    private void OnDestroy() {
        EventManager.onGameEndE -= OnGameEnd;
        EventManager.onShowDoubleJumpE -= OnShowDoubleJumpIcon;
    }

    // Update is called once per frame
    void Update()
    {
        isBgShowing = bg.color.a > 0;
        
        if (Input.GetKeyDown(KeyCode.Escape) || gameOver) {
            Color color = bg.color;
            color.a = isBgShowing ? 0 : 0.8f;
            if (gameOver) color.a = 0.8f;
            bg.color = color;
            isBgShowing = bg.color.a > 0;
            midPart.gameObject.SetActive(isBgShowing);
            restart.gameObject.SetActive(isBgShowing);
            quit.gameObject.SetActive(isBgShowing);
            EventManager.OnPause(isBgShowing);
        }
        Time.timeScale = isBgShowing ? 0 : 1;
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Quit() {
        Application.Quit();
    }

    void OnGameEnd() {
        StartCoroutine(WaitAndThenEndGame());
    }

    void OnShowDoubleJumpIcon() {
        doubleJumpImage.gameObject.SetActive(true);
    }

    IEnumerator WaitAndThenEndGame() {
        yield return new WaitForSeconds(2);
        gameOver = true;
    }
}
