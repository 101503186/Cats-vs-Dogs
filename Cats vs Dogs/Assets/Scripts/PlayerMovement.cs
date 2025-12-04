using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    Vector2 movement;
    public Rigidbody2D rb;

    Experience experienceManager;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    private void Start()
    {
        experienceManager = FindFirstObjectByType<Experience>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetKeyDown(KeyCode.E))
        {
            GiveExperience();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void GiveExperience()
    {
        int xpNeeded = experienceManager.ExperienceToNextLevel();
        experienceManager.AddExperience(xpNeeded);
    }
}
