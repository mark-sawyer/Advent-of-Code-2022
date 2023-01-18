using System.Collections.Generic;

namespace advent19 {
    public static class InputInterpreter {
        public static void exe(string[] input) {
            int[] blueprintValues;
            List<MineralCost> mineralCosts;
            List<Blueprint> blueprints = new List<Blueprint>();

            foreach (string s in input) {
                blueprintValues = getBlueprintValues(s);
                mineralCosts = getMineralCosts(blueprintValues);
                blueprints.Add(new Blueprint(blueprintValues[0], mineralCosts));
            }

            BlueprintList.blueprints = blueprints;
            CurrentBlueprint.changeBlueprint(0);
            TurnsToBuyableList.updateTurns();
        }




        private static int lengthOfNum(string temp, char searchingFor) {
            int index = 1;
            bool foundColon = false;
            while (!foundColon) {
                if (temp[index] == searchingFor) foundColon = true;
                else index++;
            }

            return index;
        }
        private static int[] getBlueprintValues(string s) {
            int[] blueprintValues = new int[7];
            int len;
            string temp = s.Substring(10);

            len = lengthOfNum(temp, ':');
            blueprintValues[0] = int.Parse(temp.Substring(0, len));
            temp = temp.Substring(23 + len);

            len = lengthOfNum(temp, ' ');
            blueprintValues[1] = int.Parse(temp.Substring(0, len));
            temp = temp.Substring(28 + len);

            len = lengthOfNum(temp, ' ');
            blueprintValues[2] = int.Parse(temp.Substring(0, len));
            temp = temp.Substring(32 + len);

            len = lengthOfNum(temp, ' ');
            blueprintValues[3] = int.Parse(temp.Substring(0, len));
            temp = temp.Substring(9 + len);

            len = lengthOfNum(temp, ' ');
            blueprintValues[4] = int.Parse(temp.Substring(0, len));
            temp = temp.Substring(30 + len);

            len = lengthOfNum(temp, ' ');
            blueprintValues[5] = int.Parse(temp.Substring(0, len));
            temp = temp.Substring(9 + len);

            len = lengthOfNum(temp, ' ');
            blueprintValues[6] = int.Parse(temp.Substring(0, len));

            return blueprintValues;
        }
        private static List<MineralCost> getMineralCosts(int[] blueprintValues) {
            MineralCost oreRobotCost = new MineralCost(blueprintValues[1], 0, 0);
            MineralCost clayRobotCost = new MineralCost(blueprintValues[2], 0, 0);
            MineralCost obsidianRobotCost = new MineralCost(blueprintValues[3], blueprintValues[4], 0);
            MineralCost geodeRobotCost = new MineralCost(blueprintValues[5], 0, blueprintValues[6]);

            return new List<MineralCost> {
                oreRobotCost,
                clayRobotCost,
                obsidianRobotCost,
                geodeRobotCost
            };
        }
    }
}
