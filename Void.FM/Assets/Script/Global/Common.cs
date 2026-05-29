namespace Script.Global
{
    using UnityEngine;
    
    public class Common
    {
        public static Vector3 ConvertV2ToV3(Vector2 v2, float yPos)
            => new(v2.x, yPos, v2.y);

        public static void ConvertGlobalToLocal(out Vector3 local, Vector3 v3) {
            var cameraRight = Camera.main.transform.right;
            var cameraForward = Camera.main.transform.forward;

            cameraForward.y = 0f;
            cameraRight.y = 0f;

            cameraForward.Normalize();
            cameraRight.Normalize();

            local = cameraForward * v3.z + cameraRight * v3.x;        
        }

        public static Vector3 ConvertGlobalToLocal(Vector3 v3) {
            var cameraRight = Camera.main.transform.right;
            var cameraForward = Camera.main.transform.forward;

            cameraForward.y = 0f;
            cameraRight.y = 0f;

            cameraForward.Normalize();
            cameraRight.Normalize();
                
            return cameraForward * v3.z + cameraRight * v3.x;        
        }
    }
}