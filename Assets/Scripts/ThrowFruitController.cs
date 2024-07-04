using System.Collections;
using UnityEngine;

public class ThrowFruitController : MonoBehaviour
{
    public static ThrowFruitController instance;

    public GameObject CurrentFruit { get; set; }
    [SerializeField] private Transform _fruitTransform;
    [SerializeField] private Transform _parentAfterThrow;
    [SerializeField] private FruitSelector _selector;

    private PlayerController _playerController;
    private CircleCollider2D _circleCollider;

    public Bounds Bounds { get; private set; }

    private const float EXTRA_WIDTH = 0.02f;
    private bool canThrow = true;
    private bool fruitCollisionOccurred = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        if (_selector != null)
            SpawnAFruit(_selector.PickRandomFruitForThrow());
        else
            Debug.LogError("FruitSelector reference is null!");
    }

    private void Update()
    {
        if (UserInput.IsThrowPressed && canThrow)
        {
            if (CurrentFruit != null)
                ThrowFruit();
            else
                Debug.LogError("CurrentFruit reference is null!");
        }
    }

    private void ThrowFruit()
    {
        canThrow = false;
        SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
        Quaternion rot = CurrentFruit.transform.rotation;

        GameObject go = Instantiate(_selector.Fruits[index.Index], CurrentFruit.transform.position, rot);
        go.transform.SetParent(_parentAfterThrow);

        Destroy(CurrentFruit);
        StartCoroutine(WaitForFruitToHit());
    }

    private IEnumerator WaitForFruitToHit()
    {
        yield return new WaitForSeconds(0.1f); // Adjust this delay if needed
        while (CurrentFruit != null && !HasCollided(CurrentFruit))
        {
            yield return null;
        }
        canThrow = true;
        fruitCollisionOccurred = false;
    }

    private bool HasCollided(GameObject fruit)
    {
        // Check if the fruit has collided with something
        // You need to implement this method based on your collision detection logic
        // For example, you can use Physics2D.OverlapCircle to check if the fruit is overlapping with any collider
        return Physics2D.OverlapCircle(fruit.transform.position, _circleCollider.radius) != null;
    }

    public void SpawnAFruit(GameObject fruit)
    {
        GameObject go = Instantiate(fruit, _fruitTransform);
        CurrentFruit = go;
        _circleCollider = CurrentFruit.GetComponent<CircleCollider2D>();
        Bounds = _circleCollider.bounds;

        if (_playerController != null)
            _playerController.ChangeBoundary(EXTRA_WIDTH);
        else
            Debug.LogError("PlayerController reference is null!");
    }

    public void SetFruitCollisionOccurred(bool value)
    {
        fruitCollisionOccurred = value;
    }
}
