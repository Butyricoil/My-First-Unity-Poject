using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            gm.EndGame();
            Debug.Log("End Game");
        }
        else if (collision.collider.CompareTag("Finish"))
        {
            Debug.Log("You Win!");
        }
    }

    private void Update()
    {
        if (transform.position.y < -5f)
        {
            Debug.Log("End Game");
            gm.EndGame();
        }
    }
}