using UnityEngine;

namespace Objects
{
  public class Player : Character
  {
    [SerializeField] public float speed = 15f;
    [SerializeField] public float speedUp = 20f;
    private float horizontal;
    private float vertical;

    private Rigidbody2D body;

    private void Start()
    {
      body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      horizontal = Input.GetAxisRaw("Horizontal");
      vertical = Input.GetAxisRaw("Vertical");

      if (Input.GetKeyDown(KeyCode.Space))
      {
        body.velocity += Vector2.up * speedUp;
      }

      Brake();
    }

    private void FixedUpdate()
    {
      float deltaTime = Time.deltaTime;
      var xVelocity = horizontal * speed * deltaTime;
      var yVelocity = vertical * speed * deltaTime;
      body.velocity += new Vector2(xVelocity, yVelocity);
    }

    private void Brake()
    {
      body.AddRelativeForce(-body.velocity);
    }
  }
}