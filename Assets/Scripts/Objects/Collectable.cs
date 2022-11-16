using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;

    public static Action hitCollectable;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Instantiate(dustEffect, transform);
            dustEffect.Play();
            CloseMeshRenderer();
            Invoke(nameof(CloseGameObject), 1f);
            hitCollectable?.Invoke();
        }
    }

    void CloseGameObject()
    {
        gameObject.SetActive(false);
    }

    void CloseMeshRenderer()
    {
        var meshRenderer = GetComponent<SpriteRenderer>().enabled = false;
        
        var rb = GetComponent<Rigidbody2D>();
        Destroy(rb);

        var collider = GetComponent<CircleCollider2D>();
        Destroy(collider);
    }
}
