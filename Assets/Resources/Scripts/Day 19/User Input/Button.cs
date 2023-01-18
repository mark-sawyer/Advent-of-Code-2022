using UnityEngine;

namespace advent19 {
    public class Button : MonoBehaviour {
        [SerializeField] bool isPass;
        [SerializeField] private Mineral mineral;

        public void pressed() {
            if (Time.timeLeft <= 0) return;

            if (isPass) TurnProcedure.exe(new Pass());
            else if (RobotBuyable.isBuyable(mineral)) TurnProcedure.exe(new Buy(mineral));
        }
    }
}
