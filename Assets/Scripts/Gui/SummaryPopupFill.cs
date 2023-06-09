using Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gui
{
    public class SummaryPopupFill : MonoBehaviour
    {
        [SerializeField]
        private Text summaryText;

        [SerializeField]
        private RoundDataModel roundData;

        void Start()
        {
            summaryText.text = string.Format("You Have played {0} rounds, for {1} minutees and {2} seconds and you collected {3} treasure chests",
                roundData.RoundNumber,
                Mathf.Floor(roundData.SecondsPlayed / 60),
                roundData.SecondsPlayed % 60,
                roundData.TreasuresFound
                );
        }
    }
}
