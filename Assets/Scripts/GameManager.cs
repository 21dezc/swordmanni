using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button tryAgainButton;

    [Header("HealthBar References")]
    [SerializeField] private Image healthBarCurrent;  // HealthBarCurrent
    [SerializeField] private Image healthBarTotal;    // HealthBarTotal

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        tryAgainButton.onClick.AddListener(RestartGame);
    }

    // ฟังก์ชันเรียกจาก heallth
    public void OnPlayerDeath(Animator playerAnimator, float currentHealth)
    {
        // เช็คว่าหัวใจหมดจริงๆ
        if (currentHealth <= 0)
        {
            StartCoroutine(ShowGameOverAfterAnimation(playerAnimator));
        }
    }

    private IEnumerator ShowGameOverAfterAnimation(Animator playerAnimator)
    {
        // รอให้อนิเมชั่น die เล่นจบ
        yield return new WaitUntil(() =>
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f
        );

        gameOverPanel.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
