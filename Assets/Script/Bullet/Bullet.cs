using Combat;
using Function;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;

    public UnityEvent OnHit = new UnityEvent();
    
    [Header("Text Setting")] 
    [SerializeField] private GameObject damageTextPrefab;
    [Range(1f,10f)]
    [SerializeField] private float yOffset = 5f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.velocity = transform.up * this.bulletData.speed;
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= bulletData.maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit?.Invoke();
        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            int DamageInToDice = CombatHelper.RandomDice(bulletData.minDamage, bulletData.maxDamage);

            GameObject DamageTextInstance = Instantiate(damageTextPrefab, damagable.transform );
            DamageTextInstance.transform.Translate(new Vector3(0, yOffset, 0));
			            
            DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(DamageInToDice.ToString());
            
            damagable.Hit(DamageInToDice);
        }

        DisableObject();
    }
}
