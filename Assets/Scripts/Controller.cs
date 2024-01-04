using UnityEngine;

namespace SampleClient
{
    public class Controller : MonoBehaviour
    {
        public float moveSpeed = 5.0f; // 移動速度

        void Update()
        {
            // 前後の移動
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));
            }

            // 左右の移動
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
            }

            // 上下の移動
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
            }
        }
    }
}