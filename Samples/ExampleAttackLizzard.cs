using DG.Tweening;
using UnityEngine;

namespace FGT.Prototypes.DamagePopup.Demo
{
    public class ExampleAttackLizzard : MonoBehaviour
    {
        [SerializeField] Transform _lizzardTransform;

        void Start()
        {
            _lizzardTransform.DOMoveX(4f, 3f).SetLoops(-1, LoopType.Yoyo);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float random = Random.Range(0f, 1f);
                if (random > 0.9f)
                {
                    string damage = Random.Range(101, 200).ToString();
                    DamagePopup.Create($"{damage}", 2.5f * Vector3.up, _lizzardTransform, Color.red, 25);
                    DamagePopup.Create("critical!", 3.7f * Vector3.up, _lizzardTransform, Color.red, 10);
                }
                else if (random < 0.1)
                {
                    DamagePopup.Create("miss", 2.5f * Vector3.up, _lizzardTransform, Color.gray, 10);
                }
                else
                {
                    string damage = Random.Range(1, 100).ToString();
                    DamagePopup.Create(damage, 2.5f * Vector3.up, _lizzardTransform, Color.white, 17);
                }
            }
        }
    }
}
