using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace advent24 {
    public static class AdventEvents {
        public static readonly UnityEvent blizzardMoves = new UnityEvent();
        public static readonly UnityEvent tokenMoves = new UnityEvent();
        public static readonly UnityEvent invalidPositionCheck = new UnityEvent();
        public static readonly UnityEvent destroyExceptEnd = new UnityEvent();
        public static readonly UnityEvent destroyExceptStart = new UnityEvent();
    }
}
