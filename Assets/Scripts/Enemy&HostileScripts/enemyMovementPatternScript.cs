using UnityEngine;

public class EnemyMovementPatternScript : MonoBehaviour
{
    public GameObject[] enemies;
    public float speed = 2.0f;
    public float amplitude = 1.0f; // Adjust this to control the height of the wave
    public float frequency = 1.0f; // Adjust this to control the speed of the wave

    private void Update()
    {
        WaveMovements();
    }

    void WaveMovements()
    {
        // Loop through each enemy in the array
        for (int i = 0; i < enemies.Length; i++)
        {
            // Calculate the vertical position of the enemy using a sine wave
            float yPos = Mathf.Sin(Time.time * frequency + i) * amplitude;

            // Move the enemy
            Vector2 newPosition = enemies[i].transform.position;
            newPosition.y = yPos;
            enemies[i].transform.position = newPosition;

            // Optionally, you can add horizontal movement as well
            // For example, to move the enemies horizontally, you could do:
            // float xPos = newPosition.x + Time.deltaTime * speed;
            // newPosition.x = xPos;
            // enemies[i].transform.position = newPosition;
        }
    }
}
