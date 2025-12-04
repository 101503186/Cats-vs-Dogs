using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90f || angle < -90f)
        {
            transform.localScale = new Vector3(1, -1, 1);   // flipped
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);    // normal
        }
    }
}
