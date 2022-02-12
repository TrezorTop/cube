using UnityEngine;

namespace Obstacle
{
    public class MaterialColor : MonoBehaviour
    {
        public Gradient hitPointGradient;

        private void Update()
        {
            var maxHp = GetComponent<ObstacleHealth>().maxHp;
            var hp = GetComponent<ObstacleHealth>().GetHitPoints() <= 0 ? 0 : GetComponent<ObstacleHealth>().GetHitPoints();

            var lerp = MapValue(hp, 0, maxHp, 0f, 1f);

            GetComponent<Renderer>().material.color =
                Color.Lerp(GetComponent<Renderer>().material.color, hitPointGradient.Evaluate(lerp), 0.1f);
        }

        private static float MapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
        {
            return 1 - (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
        }
    }
}