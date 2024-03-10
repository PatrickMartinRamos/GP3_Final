using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class cardEffects : MonoBehaviour
{
    //public var
    public GameObject[] _cards;
    public Vector3 _hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float _duration = 0.3f;

    //system var
    private Vector3 originalScale;

    void Start()
    {
        originalScale = _cards[0].GetComponent<RectTransform>().localScale;
    }

    private void Update()
    {
        foreach (GameObject card in _cards)
        {
            RectTransform rectTransform = card.GetComponent<RectTransform>();
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
            {
                //Debug.Log("card");
                rectTransform.DOScale(_hoverScale, _duration);
            }
            else
            {
                rectTransform.DOScale(originalScale, _duration);
            }
        }
    }
}
