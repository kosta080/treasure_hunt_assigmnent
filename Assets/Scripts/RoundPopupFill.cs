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
    void Start()
    {
		headerText.text = "Round "+roundData.RoundNumber.ToString();
        hintText.text = "Hint "+ roundData.ChestIndex.ToString();
    }

    
}
