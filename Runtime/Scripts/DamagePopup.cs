using DG.Tweening;
using TMPro;
using UnityEngine;
using DG.Tweening.Core; // For DOGetter and DOSetter
using DG.Tweening.Plugins.Options; // For FloatOptions

namespace FGT.Prototypes.DamagePopup
{
    public class DamagePopup : MonoBehaviour
    {
        [SerializeField] RectTransform _rectTransform;
        [SerializeField] TMP_Text _text;

        public static DamagePopup Create(string text, Vector3 position)
        {
            DamagePopup damagePopup = Instantiate(Resources.Load<DamagePopup>("Damage Popup"), null);
            damagePopup.transform.position = position;
            damagePopup.SetText(text);
            return damagePopup;
        }

        public static DamagePopup Create(string text, Transform parent = null)
        {
            DamagePopup damagePopup = Instantiate(Resources.Load<DamagePopup>("Damage Popup"), null);
            if (parent != null)
                damagePopup.transform.position = parent.transform.position;
            damagePopup.SetText(text);
            return damagePopup;
        }

        public static DamagePopup Create(string text, Vector3 offset, Transform parent = null)
        {
            DamagePopup damagePopup = Instantiate(Resources.Load<DamagePopup>("Damage Popup"), null);
            if (parent != null)
                damagePopup.transform.position = parent.transform.position;
            damagePopup.transform.position += offset;
            damagePopup.SetText(text);
            return damagePopup;
        }

        public static DamagePopup Create(string text, Vector3 offset, Transform parent, Color color)
        {
            DamagePopup damagePopup = Instantiate(Resources.Load<DamagePopup>("Damage Popup"), null);
            if (parent != null)
                damagePopup.transform.position = parent.transform.position + offset;
            damagePopup.SetText(text);
            damagePopup.SetColor(color);
            return damagePopup;
        }

        public static DamagePopup Create(string text, Vector3 offset, Transform parent, Color color, int size)
        {
            DamagePopup damagePopup = Instantiate(Resources.Load<DamagePopup>("Damage Popup"), null);
            if (parent != null)
                damagePopup.transform.position = parent.transform.position + offset;
            damagePopup.SetText(text);
            damagePopup.SetColor(color);
            damagePopup.SetSize(size);
            return damagePopup;
        }

        void Start()
        {
            FadeUpEffect();
        }

        void FadeUpEffect()
        {
            Destroy(gameObject, 2f);
            _rectTransform.rotation = Camera.main.transform.rotation;

            _rectTransform.localScale = Vector3.zero;
            _rectTransform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);

            Vector3 randomOffset = new Vector3(
                Random.Range(-0.5f, 0.5f),
                Random.Range(1.5f, 2.5f),
                0.5f
            );

            _rectTransform.DOLocalMove(_rectTransform.localPosition + randomOffset, 1.5f)
        .SetEase(Ease.OutCubic);
            // Fade out
            _text.DOFade(0, 1.5f).SetEase(Ease.InQuad);

            // Slight rotation
            _rectTransform.DOLocalRotate(new Vector3(0, Random.Range(-10f, 10f), Random.Range(-25f, 25f)), 1.5f);

            // Final Shrink
            _rectTransform.DOScale(0.5f, 1.5f).SetEase(Ease.InSine).SetDelay(0.3f);
        }

        void SpreadEffect()
        {
            Destroy(gameObject, 1.5f);

            // Follow camera rotation for better display
            _rectTransform.rotation = Camera.main.transform.rotation;

            // "POP" appear effect
            _rectTransform.localScale = Vector3.zero;
            _rectTransform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);

            // Random direction
            Vector3 randomDirection = Random.onUnitSphere; 
            float distancia = Random.Range(1.5f, 3f);

            Vector3 destination = _rectTransform.localPosition + randomDirection * distancia;
            destination.z = 0.5f;

            _rectTransform.DOLocalMove(destination, 1.5f).SetEase(Ease.OutCubic);

            // Fade out
            _text.DOFade(0, 1.5f).SetEase(Ease.InQuad);

            // Roate Z axis
            float randomZ = Random.Range(-15f, 15f);
            _rectTransform.DOLocalRotate(new Vector3(0, 0, randomZ), 1.5f).SetEase(Ease.OutQuad);

            // Shrink at end
            _rectTransform.DOScale(0.5f, 1.5f).SetEase(Ease.InSine).SetDelay(0.3f);
        }

        void SetText(string newText)
        {
            _text.text = newText;
        }

        void SetColor(Color color)
        {
            _text.color = color;
        }

        void SetSize(int size)
        {
            _text.fontSize = size;
        }
    }
}
