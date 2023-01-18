using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace advent16 {
    public class NodeGenerator : MonoBehaviour {
        [SerializeField] private GameObject node;
        private void setNodePosition(GameObject node) {
            float x = Random.Range(-3f, 3f);
            float y = Random.Range(-3f, 3f);
            node.transform.localPosition = new Vector3(x, y);
        }
        private void adjustNodeAppearance(GameObject node, Valve valve) {
            node.transform.GetChild(0).GetComponent<TextMeshPro>().text = valve.name;
            float scale = valve.name != Constants.STARTING_NAME ? Mathf.Sqrt(valve.flowRate) : 1f;
            node.transform.localScale = new Vector3(scale, scale) * Constants.NODE_SCALAR;
        }
        private void setupNodes(List<Valve> valves) {
            List<Transform> transforms = new List<Transform>();
            int children = transform.childCount;
            for (int i = 0; i < children; i++) transforms.Add(transform.GetChild(i));

            int childIndex = 0;
            foreach (Valve valve in valves) {
                if (valve.flowRate == 0 && valve.name != Constants.STARTING_NAME) continue;
                transform.GetChild(childIndex).GetComponent<Node>().setup(transforms, valve);
                childIndex++;
            }
        }




        private void Start() {
            List<Valve> valves = StateInformation.getValves();
            GameObject newNode;
            foreach (Valve valve in valves) {
                if (valve.flowRate == 0 && valve.name != Constants.STARTING_NAME) continue;

                newNode = Instantiate(node, new Vector3(), Quaternion.identity, transform);
                setNodePosition(newNode);
                adjustNodeAppearance(newNode, valve);
            }
            setupNodes(valves);
        }
    }
}
