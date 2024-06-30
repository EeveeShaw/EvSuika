using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombinedIn { get; private set; }

    private bool _hasCollided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_hasCollided && !WasCombinedIn)
        {
            Debug.Log("Collision detected with: " + collision.gameObject.name);

            _hasCollided = true;

            if (FruitSelector.instance.NextFruit == null)
            {
                Debug.LogError("NextFruit is null! Cannot spawn a new fruit :(");
                return;
            }

            ThrowFruitController.instance.SetFruitCollisionOccurred(true); // Inform ThrowFruitController about fruit collision
            ThrowFruitController.instance.SpawnAFruit(FruitSelector.instance.NextFruit);
            FruitSelector.instance.PickNextFruit();
            Destroy(this);
        }
    }
}
