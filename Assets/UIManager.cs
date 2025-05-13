using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    [SerializeField] private GameObject gameOverUI;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler() {
        gm.StartGame();
    }

    public void ActivateGameOverUI() {
        gameOverUI.SetActive(true);
        finalScoreText.text = "Final Score: " + gm.PrettyScore();
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
