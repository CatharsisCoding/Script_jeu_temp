using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Tableau des prefabs d'obstacles
    public float spawnRate = 2.0f; // Intervalle de génération des obstacles
    public float minY = -3.0f; // Position Y minimale pour les obstacles
    public float maxY = 3.0f; // Position Y maximale pour les obstacles
    public float spawnXPosition = 10.0f; // Position X pour générer les obstacles
    public float obstacleSpeed = 5.0f; // Vitesse de déplacement des obstacles
    public float obstacleZPosition = -3.0f; // Position Z des obstacles

    private float nextSpawn = 0.0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        // Sélectionne un prefab d'obstacle au hasard
        GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Détermine une position Y aléatoire dans les limites définies
        float spawnYPosition = Random.Range(minY, maxY);

        // Instancie l'obstacle à la position déterminée avec Z spécifique
        Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, obstacleZPosition);
        GameObject newObstacle = Instantiate(obstacle, spawnPosition, Quaternion.identity);

        // Ajouter le script ObstacleMover au nouvel obstacle
        ObstacleMover mover = newObstacle.AddComponent<ObstacleMover>();
        mover.speed = obstacleSpeed;
    }

    // Classe interne pour gérer le déplacement et la destruction des obstacles
    private class ObstacleMover : MonoBehaviour
    {
        public float speed;

        void Start()
        {
            Destroy(gameObject, 10f); // Détruire l'obstacle après 10 secondes
        }

        void Update()
        {
            // Déplacement de l'obstacle vers la gauche
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
