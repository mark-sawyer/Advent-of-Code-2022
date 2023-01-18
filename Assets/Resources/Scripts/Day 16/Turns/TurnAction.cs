
namespace advent16 {
    public interface TurnAction {
        public void exe(Valve valve);
        public bool isPossible(Valve valve);
        public int turnsPassed();
    }
}
