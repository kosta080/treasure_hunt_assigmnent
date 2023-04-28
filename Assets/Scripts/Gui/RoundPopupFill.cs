using UnityEngine;
using UnityEngine.UI;

public class RoundPopupFill : MonoBehaviour
{
    [SerializeField]
    private Text headerText;

    [SerializeField]
    private Text hintText;

    [SerializeField]
    private RoundDataModel roundData;

    [SerializeField]
    private Image hingImageElement;

    [SerializeField]
    private Sprite[] hintImages;

    [SerializeField]
    private Sprite questionmark;


    void Start()
    {
        headerText.text = "Round " + roundData.RoundNumber.ToString();
        if (roundData.ChestIndex > hintImages.Length - 1)
        {
            Debug.Log("There is no hint image for this treasure spawn, a generic hing image will be shown");
            hintText.text = "There is no hint";
            hingImageElement.sprite = questionmark;
            return;
        }
		
        hintText.text = "Hint "+ roundData.ChestIndex.ToString();
        hingImageElement.sprite = hintImages[roundData.ChestIndex];
    }

    
}
