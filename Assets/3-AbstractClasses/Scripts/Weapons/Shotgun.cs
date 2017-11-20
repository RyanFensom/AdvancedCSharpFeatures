
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Preprocessor Directives
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AbstractClasses
{
    public class Shotgun : Weapon
    {
        public int shells = 5;
        public float shootAngle = 45f;
        public float shootRadius = 5f;

        public Vector2 GetDir(float angleD)
        {
            float angleR = angleD * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angleR), 
                                      Mathf.Sin(angleR));
            return transform.rotation * dir;
        }

        public override void Fire()
        {
            // Loop through shells
            for (int i = 0; i < shells; i++)
            {
                // SET b to SpawnBullet()
                Bullets b = SpawnBullet(transform.position, transform.rotation);
                // SET randomAngle to random range between -shootAngle to shootAngle
                float randomAngle = Random.Range(-shootAngle, shootAngle);
                // SET direction to GetDir() and pass randomAngle
                Vector2 dir = GetDir(randomAngle);
                // SET b's aliveDistance to shootRadius
                b.aliveDistance = shootRadius;
                // CALL b's Fire() and pass direction
                b.Fire(dir);
            }
            
            
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Shotgun))]
    public class ShotgunEditor : Editor
    {
        void OnSceneGUI()
        {
            Shotgun shotgun = (Shotgun)target;

            Transform transform = shotgun.transform;
            Vector2 pos = transform.position;

            float angle = shotgun.shootAngle;
            float radius = shotgun.shootRadius;

            Vector2 leftDir = shotgun.GetDir(angle);
            Vector2 rightDir = shotgun.GetDir(-angle);

            Handles.color = Color.red;
            Handles.DrawLine(pos, pos + leftDir * radius);
            Handles.DrawLine(pos, pos + rightDir * radius);

            Handles.color = Color.blue;
            Handles.DrawWireArc(pos, Vector3.forward, rightDir, angle * 2, radius);
        }
    }
#endif
}