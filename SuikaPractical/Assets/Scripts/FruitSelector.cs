using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitSelector : MonoBehaviour
{
    public static FruitSelector instance;

    public GameObject[] Fruits;
    public GameObject[] NoPhysicsFruits;
    public int HighestStartingIndex = 3;

    [SerializeField] private Image _nextFruitImage;
    [SerializeField] private Sprite[] _fruitSprites;

    public GameObject NextFruit { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Initialize the next fruit when the game starts
        PickNextFruit();
    }

    public GameObject PickRandomFruitForThrow()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1);

        if (randomIndex < NoPhysicsFruits.Length)
        {
            GameObject randomFruit = NoPhysicsFruits[randomIndex];
            return randomFruit;
        }

        return null;
    }

    public void PickNextFruit()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1);

        if (randomIndex < Fruits.Length)
        {
            NextFruit = Fruits[randomIndex];
            Debug.Log("NextFruit selected: " + NextFruit.name);

            if (randomIndex < Fruits.Length && _nextFruitImage != null)
            {
                GameObject nextFruit = NoPhysicsFruits[randomIndex];
            }
        }
        else
        {
            Debug.LogError("Random index out of bounds: " + randomIndex);
        }
    } 
}

