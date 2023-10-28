using System.Collections;
using Data;
using Script;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	public class PlayerMovement : MonoBehaviour, IDataPersistence
	{
		public static PlayerMovement instance;

		public MovemntData momentData;
		[field: SerializeField] public bool canMove = true;

		private Rigidbody2D _rb2D;
		private Vector2 _movmentInput;
		private Vector2 _smoothedMovementInput;
		private Vector2 _movementInputSmoothVelocity;

		private bool canDash = true;
		private bool isDashing;

		private Animator _animator;
		
		private void Awake()
		{
			_rb2D = GetComponent<Rigidbody2D>();
			_animator = GetComponent<Animator>();
		}

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
		}

		private void Update()
		{			
			if(isDashing)
				return;
			
			MovementManager();
			AnimatorManager();
		}

		private void OnMove(InputValue inputValue)
		{
			_movmentInput = inputValue.Get<Vector2>();
		}

		private void MovementManager()
		{
			if (canMove)
			{
				_smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movmentInput,
					ref _movementInputSmoothVelocity, 0.1f);
				_rb2D.velocity = _smoothedMovementInput * momentData.Speed;
			}
			else
			{
				_rb2D.velocity = _smoothedMovementInput * 0;
			}
			
			if (Input.GetKeyDown(KeyCode.Space) && canDash && canMove)
			{
				StartCoroutine(Dash());
			}
		}
		
		private IEnumerator Dash()
		{
			canDash = false;
			isDashing = true;
			_rb2D.velocity = new Vector2(_movmentInput.x * momentData.DashSpeed, _movmentInput.y * momentData.DashSpeed);
			yield return new WaitForSeconds(momentData.dashDuration);
			isDashing = false;

			yield return new WaitForSeconds(momentData.dashCooldown);
			canDash = true;
		}

		private void AnimatorManager()
		{
			if (_movmentInput.x !=  0 ||_movmentInput.y != 0 )
			{
				_animator.SetFloat(AnimHash.instance.MoveX, _movmentInput.x);
				_animator.SetFloat(AnimHash.instance.MoveY, _movmentInput.y);
				_animator.SetBool(AnimHash.instance.Moving, true);
			}
			else
			{
				_animator.SetBool(AnimHash.instance.Moving, false); 
			}
			
		}
		
		public IEnumerator AnimationForMelle()
		{
			_animator.SetBool(AnimHash.instance.Attacking, true);
			yield return null;
				
				
			if (PlayerCombat.instance.rotZ < 45 && PlayerCombat.instance.rotZ > -45 )
			{
				//  print("Right");
				_animator.SetFloat(AnimHash.instance.RotZ, 0);

			}
			else  if(PlayerCombat.instance.rotZ < 135 && PlayerCombat.instance.rotZ > 45 )
			{
				//   print("Up");
				_animator.SetFloat(AnimHash.instance.RotZ, 1);

			}
			else if(PlayerCombat.instance.rotZ < -45 && PlayerCombat.instance.rotZ > -135 )
			{
				//   print("Down");
				_animator.SetFloat(AnimHash.instance.RotZ, 2);

			}
			else
			{
				//  print("Left");
				_animator.SetFloat(AnimHash.instance.RotZ, 3);

			}
	            
			_animator.SetBool(AnimHash.instance.Attacking, false);
			yield return new WaitForSeconds(0.5f);

		}


		public void LoadData(GameData data)
		{
			this.transform.position = data.PlayerPosition;
		}

		public void SaveData(ref GameData data)
		{
			data.PlayerPosition = this.transform.position;
		}
	}
		
}