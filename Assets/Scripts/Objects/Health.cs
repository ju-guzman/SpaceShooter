using UnityEngine;

public class Health : MonoBehaviour
{
    private MovementManager movementManager;

    // Start is called before the first frame update
    void Start()
    {
        LoadManagers();
    }

    private void LoadManagers()
    {
        movementManager = GetComponent<MovementManager>();
    }

    void Update()
    {
        if (movementManager)
        {
            movementManager.Move(Vector2.left);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthManager player = collision.gameObject.GetComponent<HealthManager>();
            if (player)
            {
                player.Heal();
                Destroy(gameObject);
            }
        }
    }
}
