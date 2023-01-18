using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace advent23 {
    public class Space {
        public readonly int row;
        public readonly int col;
        public Elf elf { get; private set; }
        public bool hasElf { get; private set; }
        private List<Elf> elvesConsidering = new List<Elf>();

        public Space(int row, int col) {
            this.row = row;
            this.col = col;
        }

        public void addElf(Elf newElf) {
            elf = newElf;
            hasElf = true;
        }

        public void addElf() {
            elf = new Elf(this);
            hasElf = true;
        }

        public void removeElf() {
            elf = null;
            hasElf = false;
        }

        public void addConsideringElf(Elf newElf) {
            elvesConsidering.Add(newElf);
        }

        public bool onlyOneElfConsidering() {
            return elvesConsidering.Count == 1;
        }

        public void resetConsideringElves() {
            elvesConsidering.Clear();
        }
    }
}
