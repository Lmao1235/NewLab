using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int Playerscore { get { return playerScore; } set { playerScore = value; } }
    [SerializeField]

    private GameObject ballPrefab;
    [SerializeField]

    private GameObject[] ballPosition;
    [SerializeField]

    private GameObject cueBall;
    [SerializeField]

    private GameObject ballLine;
    [SerializeField]

    private float xInput;
    [SerializeField]

    private GameObject camera;
    [SerializeField]

    private TMP_Text scoreText;
    public static GameManager Instance;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        UpdateScoreText();
        camera = Camera.main.gameObject;
        CameraBehindCueBall();

        SetBall(BallColor.White, 0);
        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Brown, 4);
        SetBall(BallColor.Blue, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();
        if (Input.GetKeyDown(KeyCode.W))
            ShootBall();
        if (Input.GetKeyDown(KeyCode.S))
            StopBall();

    }
    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab, ballPosition[i].transform.position, Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }
    private void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f, xInput / 5f, 0f));
    }

    private void ShootBall()
    {
        camera.transform.parent = null;
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);

        ballLine.SetActive(false);
    }

    private void CameraBehindCueBall()
    {
        camera.transform.parent = cueBall.transform;
        camera.transform.position = cueBall.transform.position
            + new Vector3(0f, 7f, -10f);
    }

    private void StopBall()
    {
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;

        CameraBehindCueBall();
        camera.transform.eulerAngles = new Vector3(30f, 0f, 0f);
        ballLine.SetActive(true);
    }

    public void UpdateScoreText()
    {
        scoreText.text = $"Player score :{playerScore}";
    }
}