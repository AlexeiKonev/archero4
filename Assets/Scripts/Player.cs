using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace herogame
{
    public class Player : MonoBehaviour
    {
        private int _health = 1000;

        private int _damage;
        [SerializeField]
        private float _speed = 40f;


        private int _coins;


        private RectTransform _healthBar;

        private CharacterController _characterController;
        float x;
        float y;
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _healthBar = GameObject.Find("healthbar").GetComponent<RectTransform>();
        }

        private void Die()
		{
            Debug.Log("Player is Dead");
		}

        private void MoveHealthBar()
		{
            _healthBar.position = new Vector2(transform.position.x, transform.position.z);

        }

		private void  Move(float xVector , float yVector)
		{
            _characterController.SimpleMove(new Vector3( xVector * _speed*Time.deltaTime,transform.position.y, yVector * _speed * Time.deltaTime));
		}
		// Update is called once per frame
		private void Update()
        {
			if (_health <= 0)
			{
                Die();
			}

              x = Input.GetAxis("Horizontal");
              y = Input.GetAxis("Vertical");

           
        }
		private void FixedUpdate()
		{
            Move(x, y);
        }
		private void LateUpdate()
        {
            MoveHealthBar();
        }
    }
}
