using UnityEngine;

public class EnemyMovementPatternScript : MonoBehaviour
{
    /// <summary>
    /// pwede tayo gumawa ng multiple wave pattern function tas i randomize lng naten ung tawag sa mga function para pag na instaciate
    /// ung enemy prefab randomize ung pattern ng movements nya 
    /// </summary>


    //public var
    public float amplitude = 1f; // The height of the wave
    public float frequency = 1f; // The speed of the wave
    public float phaseOffset = 0.25f; // Phase offset between child objects

    private float[] initialYPositions; 

    void Start()
    {
        // Initialize the array to store the initial Y positions of each child object
        initialYPositions = new float[transform.childCount];

        // Store the initial Y position of each child object
        for (int i = 0; i < transform.childCount; i++)
        {
            initialYPositions[i] = transform.GetChild(i).position.y;
        }
    }

    void Update()
    {
        waveMovemnts();
    }
    #region wave movements
    void waveMovemnts()
    {
        // Calculate the vertical movement based on sine wave
        float verticalMovement = Mathf.Sin(Time.time * frequency) * amplitude;

        // Move each child object along the Y-axis with the wave pattern
        for (int i = 0; i < transform.childCount; i++)
        {
            // Calculate the phase shift for each child object
            float phaseShift = (float)i / transform.childCount * Mathf.PI * 2f;

            // Apply the phase offset
            phaseShift += phaseOffset;

            // Set the new position for each child object with the phase shift
            float newY = initialYPositions[i] + Mathf.Sin(Time.time * frequency + phaseShift) * amplitude;
            transform.GetChild(i).position = new Vector3(transform.GetChild(i).position.x, newY, transform.GetChild(i).position.z);
        }
    }
    #endregion
}

