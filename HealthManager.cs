using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public Image[] heartImages; // Tableau des images de cœur
    public Sprite fullHeart; // Sprite pour un cœur plein
    public Sprite emptyHeart; // Sprite pour un cœur vide

    private int health;

    void Awake()
    {
        // Assure que le HealthManager est un singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        health = heartImages.Length; // Initialise la santé à la longueur du tableau des images de cœur
        UpdateHearts();
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
        UpdateHearts();

        if (health == 0)
        {
            GameOver();
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < health)
            {
                heartImages[i].sprite = fullHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // Logique de fin de jeu, comme réinitialiser la scène, afficher un écran de fin de jeu, etc.
        // Exemple:
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
