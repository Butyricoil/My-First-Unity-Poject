using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text scoreText;

    void Update()
    {
        scoreText.text = player.position.z.ToString();
    }
}
