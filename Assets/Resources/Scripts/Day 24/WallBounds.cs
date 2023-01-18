
namespace advent24 {
    public static class WallBounds {
        public static int rightBound { get; private set; }
        public static int bottomBound { get; private set; }

        public static void setBounds(string[] input) {
            rightBound = input[0].Length - 1;
            bottomBound = -(input.Length - 1);
        }
    }
}
