//Hopefullythisworks
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] NextFruits nextFruitsUI;
    [SerializeField] Transform heldFruitParent;
    [SerializeField] Transform droppedFruitParent;
    [Space]
    [SerializeField] Fruit[] fruits;
    [SerializeField] Fruit heldFruit;
    [Tooltip("Size in inspector upon starting game will be the size prefilled")]
    [SerializeField] public Fruit[] nextFruits;

    private void Awake()
    {
        heldFruit = GetRandomFruit();
        for (int i = 0; i < nextFruits.Length; i++)
            nextFruits[i] = GetRandomFruit();
        nextFruitsUI.UpdateNextFruitUI();

        StartCoroutine(FruitShooter());
    }

    public Fruit GetRandomFruit()
    {
        return fruits[Random.Range(0, fruits.Length)];
    }
    private IEnumerator FruitShooter()
    {
        while (true)
        {
            heldFruit = Instantiate(heldFruit,
                        transform.position,
                        Quaternion.identity,
                        heldFruitParent);

            yield return new WaitUntil(() => UserInput.IsThrowPressed);
            heldFruit.transform.parent = droppedFruitParent;
            heldFruit.SimulateFruit();
            yield return new WaitUntil(() => heldFruit.DoneDropping);

            if (nextFruits.Length > 0)
            {
                heldFruit = nextFruits[0];
                for (int i = 0; i < nextFruits.Length - 1; i++)
                    nextFruits[i] = nextFruits[i + 1];
                nextFruits[^1] = GetRandomFruit();
            }
            else heldFruit = GetRandomFruit();

            nextFruitsUI.UpdateNextFruitUI();
        }
    }
}