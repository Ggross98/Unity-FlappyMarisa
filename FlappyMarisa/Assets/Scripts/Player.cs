using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject overPanel;
    public GameObject scorePanel;
    private ShowScore showScore;
    private Animator animator;

    public float speedX = 1f;
    public float speedPerJump = 2f;

    private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        showScore = scorePanel.GetComponent<ShowScore>();
    }

    void Update()
    {
        if(GameStateManager.GameState == GameState.Playing)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            MoveX();
        }
    }

    private void AddOneScore()
    {
        showScore.AddScore();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            if (col.gameObject.tag == "Pipeblank") //通过了一个柱子
            {
                Difficulty.instance.LevelUp();
                AddOneScore();
            }
            else if (col.gameObject.tag == "Pipe")//撞到柱子
            {
                Die();
            }
        }
    }


    /// <summary>
    /// 每次单击向上飞
    /// </summary>
    private void Jump()
    {
        rigidbody.velocity = new Vector2(0,speedPerJump );
    }

    /// <summary>
    /// x轴平移
    /// </summary>
    private void MoveX()
    {
        float rate;
        if (Difficulty.instance == null)
        {
            rate = 1;
        }
        else
        {
            rate = Difficulty.instance.GetRate();
        }
        transform.position += new Vector3(Time.deltaTime*speedX* rate,0,0);
    }

    private void Die()
    {
        gameObject.transform.rotation= Quaternion.Euler(0.0f, 0.0f, 90.0f);
        GameStateManager.GameState = GameState.Over;
        animator.enabled=false;
        overPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Difficulty.instance.SetRate(1);
        GameStateManager.GameState = GameState.Playing;
        overPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
