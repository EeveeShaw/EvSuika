using UnityEngine;
using UnityEngine.UI;

public class NextFruits : MonoBehaviour
{
    [SerializeField] private Image nextFruitImage;
    [SerializeField] private FruitManager fruitManager;

    public void UpdateNextFruitUI()
    {
        if (fruitManager.nextFruits.Length > 0)
        {
            Fruit nextFruit = fruitManager.nextFruits[0];
            SpriteRenderer nextFruitRenderer = nextFruit.GetComponent<SpriteRenderer>();
            nextFruitImage.sprite = nextFruitRenderer.sprite;
        }
    }
}
