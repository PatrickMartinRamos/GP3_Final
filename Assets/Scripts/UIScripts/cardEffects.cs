using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardEffects : MonoBehaviour
{
    // Public variables
    public GameObject[] cards;
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float duration = 0.3f;
    public Camera uiCamera; // Reference to the UI camera


    // Private variables
    private Vector3 originalScale;

    void Start()
    {
        originalScale = cards[0].GetComponent<RectTransform>().localScale;
    }

    void Update()
    {
        foreach (GameObject card in cards)
        {
            RectTransform rectTransform = card.GetComponent<RectTransform>();

            // Convert mouse position to canvas space
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, uiCamera, out localPoint);

            if (rectTransform.rect.Contains(localPoint))
            {
                Debug.Log("card");
                rectTransform.DOScale(hoverScale, duration);

                // Activate particle effect and adjust its scale

                //GameObject particleEffect = card.transform.Find("ParticleEffect").gameObject;
                //particleEffect.SetActive(true);
                //particleEffect.transform.localScale = card.transform.localScale;
            }
            else
            {
                rectTransform.DOScale(originalScale, duration);

                // Deactivate particle effect

                //GameObject particleEffect = card.transform.Find("ParticleEffect").gameObject;
                //particleEffect.SetActive(false);
            }
        }
    }
}
