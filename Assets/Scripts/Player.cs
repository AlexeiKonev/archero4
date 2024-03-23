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


        private int _coins;


        private RectTransform _healthBar;

        private CharacterController _characterController;
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

		private void  Move()
		{
            _characterController.SimpleMove(new Vector3(Input.GetAxis("Horizontal"),transform.position.y, Input.GetAxis("Vertical")));
		}
		// Update is called once per frame
		private void Update()
        {
			if (_health <= 0)
			{
                Die();
			}

            Move();
        } 
        private void LateUpdate()
        {
            MoveHealthBar();
        }
    }
}
