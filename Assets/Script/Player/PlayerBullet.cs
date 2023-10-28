using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using Function;
using Data;
using TMPro;
using UnityEngine;

namespace Player.Bullet
{
    public class PlayerBullet : MonoBehaviour
    {
        private Vector3 mousePos;
        private Camera mainCam;
        private Rigidbody2D rb;

        private Vector2 starPosition;
        private float conquaredDistance = 0;
        

        public BulletData bulletData; 
        
        [Header("Text Setting")] 
        [SerializeField] private GameObject damageTextPrefab;
        [Range(1f,10f)]
        [SerializeField] private float yOffset = 5f;
        
        private void Start()
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rb = GetComponent<Rigidbody2D>();
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            Vector3 rotation = transform.position - mousePos;

            rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletData.speed;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
			
            //ToDO In laters time, will be pooling system
            Destroy(gameObject, bulletData.maxDistance); 
        }

        private void Update()
        {

        }

       public void DisableObject()
       {
           rb.velocity = Vector2.zero;
           gameObject.SetActive(false);
       }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var damagable = other.GetComponent<Damagable>();
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
}
