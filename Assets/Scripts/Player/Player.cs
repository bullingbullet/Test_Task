using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    private float timer;
    
    private bool isAlive = true;
    private bool isFinish = false;

    public ShootController shootController;

    private void Start()
    {
        timer = 2.0f;

        isAlive = true;
        isFinish = false;
    }

    private void Update()
    {
        if (timer <= 0 && isAlive == false)
        {
            SaveLog.sw.WriteLine("Lose", true);
            SaveLog.sw.Close();

            SceneManager.LoadScene("Main");
        }
        else if (timer <= 0 && isFinish == true)
        {
            SaveLog.sw.WriteLine("Win", true);
            SaveLog.sw.Close();

            SceneManager.LoadScene("Main");
        }

        if (Input.GetMouseButtonDown(0))
        {
            shootController.Shoot();
        }

        if (GameObject.Find("Particle System(Clone)"))
        {
            Destroy(GameObject.Find("Particle System(Clone)"), 0.5f);
        }
    }

    private void OnGUI()
    {   
        GUIStyle style = new GUIStyle();

        style.fontSize = 48;
        style.normal.textColor = Color.yellow;
        style.alignment = TextAnchor.MiddleCenter;

        if (isAlive == false || isFinish == true)
        {
            string txt;
            if (isAlive == false) { txt = "Проиграл"; }
            else { txt = "Выиграл"; }
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 20, 10), txt, style);

            timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isAlive == true && isFinish == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.localPosition += speed * Time.deltaTime * transform.forward;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.localPosition += speed * Time.deltaTime * -transform.forward;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.localPosition += speed * Time.deltaTime * -transform.right;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.localPosition += speed * Time.deltaTime * transform.right;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("deadZone"))
        {
            isAlive = false;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            isFinish = true;
        }
    }
}
