
namespace advent19 {
    public class TurnsLeftComparer {
        public int reduction { get; private set; }
        public TurnsLeftComparer(Mineral typePurchased, Mineral typeCounted) {
            TurnsToBuyable turnsToBuyable = TurnsToBuyableList.getTurnsToBuyable(typeCounted);
            int currentTurns = turnsToBuyable.willBeBuyable ? turnsToBuyable.turns : Constants.NOT_BUYABLE_FLAG;
            TurnsAfterPurchase turnsAfterPurchase = new TurnsAfterPurchase(typePurchased, typeCounted);
            int afterPurchaseTurns = turnsAfterPurchase.num;
            reduction = currentTurns - afterPurchaseTurns - 1;
        }
    }
}
