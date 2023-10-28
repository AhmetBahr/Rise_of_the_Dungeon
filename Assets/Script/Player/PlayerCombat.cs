using Function;
using Combat;
using Data;
using Manager;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
	public class PlayerCombat : MonoBehaviour
	{
			public static PlayerCombat instance;
    
    		private Vector3 mousePos;
    		private Camera mainCam;
            public float rotZ;
            
            [SerializeField] private bool canAttack = true;
            [SerializeField] private float timeBetweenfiring;
            private float timer;
            
            [Header("Range Attack Settigs")]
            [SerializeField] private GameObject bullet;
            [SerializeField] private Transform bulletTransform;


            [Header("Melle Attack Settings")]
            [SerializeField] private Transform mellePoint;
            public MelleAttackData _MelleAttackData;
            

            [Header("Text Setting")] 
            [SerializeField] private GameObject damageTextPrefab;
            [Range(1f,10f)]
            [SerializeField] private float yOffset = 5f;
            [SerializeField] private FloatingHealthBar _rangeAttackBar;

            
            private void Start()
    		{
    			if (instance != null && instance != this)
    			{
    				Destroy(this);
    			}
    			else
    			{
    				instance = this;
    			}
    			
    			mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

                _rangeAttackBar.UpdateHealthBar(timeBetweenfiring,timeBetweenfiring);


    		}
    
    		private void Update()
    		{
    			MouseMove();
                PlayerAttack();
                
 
	                if (Input.GetKeyDown(KeyCode.U))
	                {
		                print("Pressing U");
		                GameEventsManager.instance.PlayerDeath();
	                }
                
              
            }
    
    		void MouseMove()
    		{
    			mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    			Vector3 rotation = mousePos - transform.position;
	            rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    			transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    
                
    		}

            private void PlayerAttack()
            {
	            waitingAttack();
			
	            if (Input.GetMouseButton(0) && canAttack)
	            {
		            canAttack = false;
		            Instantiate(bullet, bulletTransform.position, quaternion.identity);
	            }
	            
	            if (Input.GetMouseButtonDown(1) && canAttack)
	            {
		            StartCoroutine(PlayerMovement.instance.AnimationForMelle());
		            canAttack = false;

		            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(mellePoint.position, new Vector2(_MelleAttackData.attackRangeX, _MelleAttackData.attackRangeY), 0, _MelleAttackData.whatisEnemies);

		            for(int i=0;i< enemiesToDamage.Length;i++)
		            {
			            int DamageInToDice = CombatHelper.RandomDice(_MelleAttackData.minDamage, _MelleAttackData.maxDamage);

			            GameObject DamageTextInstance = Instantiate(damageTextPrefab, enemiesToDamage[0].transform );
			            DamageTextInstance.transform.Translate(new Vector3(0, yOffset, 0));
			            
			            DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(DamageInToDice.ToString());
			            enemiesToDamage[i].GetComponent<Damagable>().Hit(DamageInToDice);
			            


		            }

		            
	            }
            }
            
            private void waitingAttack()
            {
	            if (!canAttack)
	            {
		            timer += Time.deltaTime;
		            _rangeAttackBar.UpdateHealthBar(timer,timeBetweenfiring);
		            if (timer > timeBetweenfiring)
		            {                
			            canAttack = true;
			            timer = 0;
		            }
	            }
            }
            
            private void OnDrawGizmosSelected()
            {
	            Gizmos.color = Color.red;
	            Gizmos.DrawWireCube(mellePoint.position, new Vector3(_MelleAttackData.attackRangeX, _MelleAttackData.attackRangeY));
            }
		
	}
}
