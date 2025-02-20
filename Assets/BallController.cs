using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    private int score = 0;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject ScoreText;


    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        score = 0;
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            score += 15;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            score += 30;
        }

        this.ScoreText.GetComponent<Text>().text = score + "点";
    }
}