using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private heallth _playerHealth;
    [SerializeField] private Image _totalHealthBar;   // แก้ชื่อให้ตรง
    [SerializeField] private Image _currentHealthBar;

    private void Start()
    {
        _totalHealthBar.fillAmount = _playerHealth._currentHealth / 10;
    }

    private void Update()
    {
        // fillAmount = ค่าสุขภาพปัจจุบัน ÷ สุขภาพสูงสุด
        _currentHealthBar.fillAmount = _playerHealth._currentHealth / 10;
    }
    
    
}
