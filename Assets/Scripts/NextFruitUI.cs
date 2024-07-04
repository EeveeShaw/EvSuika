using UnityEngine;
using UnityEngine.UI;

public class NextFruitUI : MonoBehaviour
{
    [SerializeField] private Image nextFruitImage;
    [SerializeField] private FruitManager fruitManager;

    private void Start()
    {
        if (nextFruitImage == null)
        {
            Debug.LogError("NextFruitUI: nextFruitImage is not assigned!");
        }

        if (fruitManager == null)
        {
            Debug.LogError("NextFruitUI: fruitManager is not assigned!");
        }

        UpdateNextFruitImage();
    }

    public void UpdateNextFruitImage()
    {
        if (fruitManager.nextFruits.Length > 0)
        {
            Fruit nextFruit = fruitManager.nextFruits[0];
            nextFruitImage.sprite = GetFruitSprite(nextFruit);
        }
    }

    private Sprite GetFruitSprite(Fruit fruit)
    {
        //fruit prefab has a SpriteRenderer component
        SpriteRenderer spriteRenderer = fruit.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            return spriteRenderer.sprite;
        }

        // if there's no SpriteRenderer than there ya go
        return null;
    }
}
