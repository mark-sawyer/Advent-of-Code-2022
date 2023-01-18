
namespace advent16 {
    public static class TurnProcess {
        public static void exe(TurnAction turn) {
            if (!turn.isPossible(StateInformation.target)) return;
            StateInformation.getPoints(turn.turnsPassed());
            turn.exe(StateInformation.target);
            Events.updateVisuals.Invoke();
        }
    }
}
