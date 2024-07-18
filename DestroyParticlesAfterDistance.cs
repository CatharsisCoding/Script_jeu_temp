using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticlesAfterDistance : MonoBehaviour
{
    public float maxDistance = 10f; // Distance maximale avant destruction des particules

    private Transform playerTransform; // Transform du joueur (ou autre référence si nécessaire)
    private Vector3 startPosition; // Position de départ des particules

    void Start()
    {
        // Trouve le transform du joueur au démarrage du script
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Aucun objet avec le tag 'Player' n'a été trouvé.");
        }

        startPosition = transform.position; // Stocke la position de départ des particules
    }

    void Update()
    {
        // Vérifie si playerTransform est null pour éviter les erreurs potentielles
        if (playerTransform == null)
            return;

        // Calcule la distance actuelle des particules par rapport à leur position de départ
        float distance = Vector3.Distance(startPosition, transform.position);

        // Vérifie si la distance maximale est dépassée
        if (distance >= maxDistance)
        {
            Destroy(gameObject); // Détruit les particules lorsque la distance maximale est atteinte
        }
    }
}


