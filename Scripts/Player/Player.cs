using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float speed = 4f;

    private string endSessionText;
    
    private bool isAlive;
    private bool isFinish;

    [SerializeField] private ShootController shootController;

    private void Start()
    {
        isAlive = true;
        isFinish = false;
    }

    private void Update()
    {
        Movement();

        CheckState();

        shootController.Shoot();

        DestroyParticles();
    }

    private void CheckState()
    {
        if (isAlive == false)
        {
            StartCoroutine(EndGame("Lose"));
        }
        else if (isFinish == true)
        {
            StartCoroutine(EndGame("Win"));
        }
    }

    private static void DestroyParticles()
    {
        Destroy(GameObject.Find("Particle System(Clone)"), 0.5f);
    }

    IEnumerator EndGame(string issueGame)
    {
        yield return new WaitForSeconds(2f);

        SaveLog.SaveLine(issueGame);

        SceneLoader.SceneLoad("Main");
    }

    private void OnGUI()
    {   
        GUIStyle style = new GUIStyle();

        style.fontSize = 48;
        style.normal.textColor = Color.yellow;
        style.alignment = TextAnchor.MiddleCenter;

        if (isAlive == false || isFinish == true)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 20, 10), endSessionText, style);
        }
    }

    private void Movement()
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

            endSessionText = "Проиграл";
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            isFinish = true;

            endSessionText = "Выиграл";
        }
    }
}
