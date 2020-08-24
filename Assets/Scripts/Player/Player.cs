using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    //TODO offload health into a Health.cs script
    [SerializeField] int _maxHealth = 3;

    int _currentHealth;

    int _currentTreasure;

    Material _materialNew = null;
    Material _materialOld = null;

    BallMotor _ballMotor;

    public TextMeshProUGUI countText;

    private bool isVincible = false;

    int _healthInvincible = 10;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreaseHealth(int amount)
    {
        // Added an line of code to increase health
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Kill();
        }
}

    public void Kill()
    {
        gameObject.SetActive(false);
        // play particles
        // play sounds
    }

    public void IncreaseTreasure(int amount)
    {
        _currentTreasure += amount;
        countText.text = "Treasure: " + _currentTreasure.ToString();
        Debug.Log("Player's treasure: " + _currentTreasure);
    }

    public void changeColor()
    {
        _materialNew = GetComponent<MeshRenderer>().material;
        _materialNew.color = Color.magenta;
    }

    public void returnColor()
    {
        _materialOld = GetComponent<MeshRenderer>().material;
        _materialOld.color = Color.cyan;
    }
}
