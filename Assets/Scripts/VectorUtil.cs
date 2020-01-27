using UnityEngine;

namespace DarkestDimension {
    public class VectorUtil {
        public static Vector3 ToIntVector3(Vector3 v) {
            return new Vector3(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
        }
    }

}