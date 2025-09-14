using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class heallth : MonoBehaviour
{
    [SerializeField] private float _startingHealth; // แก้ชื่อ
    public float _currentHealth { get; private set; }

    private Animator _ani;

    private bool _dead = false;

    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        _currentHealth = _startingHealth;
        _ani = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _damage, 0, _startingHealth);

        if (_currentHealth > 0)
        {
            // player hurt
            _ani.SetTrigger("hurt");
        }
        else
        {
            if (!_dead)
            {
                // player dead
                _ani.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                _dead = true;
            }
            
            // บอก GameManager ว่าผู้เล่นตายและส่งค่า currentHealth
                _gameManager.OnPlayerDeath(_ani, _currentHealth);
        }
    }

 
}
