using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(shopPowerUpCards))]
public class PowerUpCardEditor : Editor
{

    /// <summary>
    /// para lang sa inspector to xD
    /// </summary>

    public override void OnInspectorGUI()
    {
        // Base inspector
        base.OnInspectorGUI();

        showCloneOption();
    }

    void showCloneOption()
    {
        // Cast the target object to the appropriate type
        shopPowerUpCards powerUpCard = (shopPowerUpCards)target;

        // If powerUpType is Clone, show sprite options
        if (powerUpCard.powerUpType == PowerUpType.Clone)
        {
            EditorGUILayout.Space(); // Add some space

            // Display the fields for spiritClone_1 and spiritClone_2 sprites
            powerUpCard.spiritClone_1 = (Sprite)EditorGUILayout.ObjectField("Spirit Clone Sprite 1", powerUpCard.spiritClone_1, typeof(Sprite), false);
            powerUpCard.spiritClone_2 = (Sprite)EditorGUILayout.ObjectField("Spirit Clone Sprite 2", powerUpCard.spiritClone_2, typeof(Sprite), false);
        }
    }
}
