using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI scoreText;
   void Update()
    {
        float zPosition = Mathf.Abs(player.position.z);
        int score = Mathf.FloorToInt(zPosition);
        scoreText.text = score.ToString();
    }
}