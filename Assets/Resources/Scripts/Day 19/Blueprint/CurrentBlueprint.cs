
namespace advent19 {
    public static class CurrentBlueprint {
        public static int blueprintIndex { get; private set; }
        public static Blueprint currentBlueprint { get; private set; }
        public static void changeBlueprint(int index) {
            blueprintIndex = index;
            currentBlueprint = BlueprintList.blueprints[blueprintIndex];
        }
    }
}
