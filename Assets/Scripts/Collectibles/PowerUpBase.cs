using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] ParticleSystem _powerupParticles;
    [SerializeField] AudioClip _powerupSound;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            PowerupFeedback();
            GetComponent<MeshRenderer>().enabled = false;
            PowerupDuration(player);
        }
    }

    protected virtual void PowerupDuration(Player player)
    {
        DelayHelper.DelayAction(this, powerDown, 3.0f);
    }

    public void powerDown()
    {
        gameObject.SetActive(false);
    }

    private void PowerupFeedback()
    {
        // particles
        if (_powerupParticles != null)
        {
            _powerupParticles = Instantiate(_powerupParticles,
                transform.position, Quaternion.identity);
            _powerupParticles.Play();
        }
        // audio. TODO - consider Object Pooling for Performance
        if (_powerupSound != null)
        {
            AudioHelper.PlayClip2D(_powerupSound, 1f);
        }
    }
}
