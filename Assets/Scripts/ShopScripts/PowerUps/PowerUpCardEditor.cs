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
        showAddMaxHealthOption();
        showAddDamageBuffOption();
        showAddshieldBuffOption();
    }

    #region show clone option inspector
    void showCloneOption()
    {
        // Cast the target object to the appropriate type
        shopPowerUpCards powerUpCard = (shopPowerUpCards)target;

        // If powerUpType is Clone, show sprite options
        if (powerUpCard.powerUpType == PowerUpType.spiritClone)
        {
            EditorGUILayout.Space(); // Add some space

            // Display the fields for spiritClone_1 and spiritClone_2 sprites
            powerUpCard.spiritClone_1 = (Sprite)EditorGUILayout.ObjectField("Spirit Clone Sprite 1", powerUpCard.spiritClone_1, typeof(Sprite), false);
            powerUpCard.spiritClone_2 = (Sprite)EditorGUILayout.ObjectField("Spirit Clone Sprite 2", powerUpCard.spiritClone_2, typeof(Sprite), false);

            powerUpCard._wispBullet = (GameObject)EditorGUILayout.ObjectField("Spirit Clone Bullet ", powerUpCard._wispBullet, typeof(GameObject), false);
        }
    }
    #endregion

    #region  show add maxHealth option inspector
    void showAddMaxHealthOption()
    {
        shopPowerUpCards powerUpCard = (shopPowerUpCards)target;

        if (powerUpCard.powerUpType == PowerUpType.addMaxHealth)
        {
            EditorGUILayout.Space(); // Add some space

            powerUpCard.healthToAdd = EditorGUILayout.IntField("Health to Add", powerUpCard.healthToAdd);
        }
    }
    #endregion

    #region show damage buff option inspector
    void showAddDamageBuffOption()
    {
        shopPowerUpCards powerUpCard = (shopPowerUpCards)target;

        if (powerUpCard.powerUpType == PowerUpType.damageBuff)
        {
            EditorGUILayout.Space(); // Add some space

            powerUpCard.damageBuff = EditorGUILayout.IntField("Damage to Add", powerUpCard.damageBuff);
        }
    }
    #endregion

    #region show shield buff option inspector
    void showAddshieldBuffOption()
    {
        shopPowerUpCards powerUpCard = (shopPowerUpCards)target;

        if (powerUpCard.powerUpType == PowerUpType.shield)
        {
            EditorGUILayout.Space(); // Add some space

            powerUpCard.addShield = EditorGUILayout.IntField("Shield to add", powerUpCard.addShield);
        }
    }
    #endregion

}
