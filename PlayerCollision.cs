using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float invincibilityDuration = 2.0f; // Durée de l'invincibilité en secondes
    public float blinkInterval = 0.2f; // Intervalle de clignotement en secondes
    public List<SpriteRenderer> spritesToBlink; // Liste des SpriteRenderer à faire clignoter

    private float invincibilityTimer = 0.0f; // Minuteur pour l'invincibilité
    private bool isInvincible = false; // Indicateur d'invincibilité
    private ParticleSystem currentJumpParticles; // Référence aux particules actuellement actives

    void Start()
    {
        // Optionnel : Ajouter les SpriteRenderer manuellement dans l'inspecteur
    }

    void Update()
    {
        // Réduire le minuteur d'invincibilité au fil du temps
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            // Clignotement des sprites à intervalles réguliers
            if (invincibilityTimer > 0.0f)
            {
                float remainder = invincibilityTimer % blinkInterval;
                if (remainder < blinkInterval / 2)
                {
                    // Activer les SpriteRenderer
                    foreach (var sprite in spritesToBlink)
                    {
                        sprite.enabled = true;
                    }
                }
                else
                {
                    // Désactiver les SpriteRenderer
                    foreach (var sprite in spritesToBlink)
                    {
                        sprite.enabled = false;
                    }
                }
            }
            else
            {
                // Fin de l'invincibilité : réactiver tous les SpriteRenderer
                isInvincible = false;
                foreach (var sprite in spritesToBlink)
                {
                    sprite.enabled = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!isInvincible)
            {
                // Logique à exécuter lors d'une collision avec un obstacle
                Debug.Log("Collision avec un obstacle !");
                HealthManager.instance.DecreaseHealth(1); // Diminue la santé du joueur

                // Activer l'invincibilité
                isInvincible = true;
                invincibilityTimer = invincibilityDuration;

                // Détruire l'obstacle après la collision
                Destroy(collision.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Token"))
        {
            // Logique à exécuter lors de la collecte d'un token
            Debug.Log("Token collecté !");
            GameManager.instance.AddScore(10); // Ajoute des points au score
            Destroy(collider.gameObject); // Détruire le token après la collecte
        }
        else if (collider.gameObject.CompareTag("Token2"))
        {
            // Logique pour la collecte de Token2
            Debug.Log("Token2 collecté !");
            GameManager.instance.AddScore(20); // Ajoute plus de points pour Token2
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("Flower"))
        {
            // Logique pour la collecte d'une Fleur
            Debug.Log("Fleur collectée !");
            GameManager.instance.AddScore(50); // Ajoute encore plus de points pour Fleur
            Destroy(collider.gameObject);
        }
    }
}
