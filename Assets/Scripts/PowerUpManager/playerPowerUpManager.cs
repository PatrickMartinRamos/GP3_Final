using UnityEngine;

public class playerPowerUpManager : MonoBehaviour
{
    //clone(wisp) Var
    public GameObject spiritClone_1;
    public GameObject spiritClone_2;
    public int cloneLevel;

    //Shield Var

    //Scatter Var

    //Bullet Buff Var

    #region activate clone(wisp)
    public void ActivateClonePowerUp(Sprite sprite1, Sprite sprite2)
    {
        IncreaseCloneLevel();
        // Activate the appropriate number of clones based on the level
        switch (cloneLevel)
        {
            case 1:
                spiritClone_1.SetActive(true); 
                spiritClone_2.SetActive(false);
                break;
            case 2:
                spiritClone_1.SetActive(true);
                spiritClone_2.SetActive(true);
                break;
                // Add more cases for higher levels 
        }

        // Assign sprites
        SpriteRenderer spriteRenderer1 = spiritClone_1.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = spiritClone_2.GetComponent<SpriteRenderer>();

        if (spriteRenderer1 != null && spriteRenderer2 != null)
        {
            spriteRenderer1.sprite = sprite1;
            spriteRenderer2.sprite = sprite2;
        }
    }

    // Method to increase the clone level
    public void IncreaseCloneLevel()
    {
        cloneLevel++;
    }
    #endregion
}
