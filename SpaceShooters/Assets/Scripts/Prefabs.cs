using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public Bolt bolt;
    public Score score;
    public AsteroidsM astM;
    public Asteroids[] ast;
    public Enemy enemy;
    public Buttons buttons;
    public Menu menu;

    void Start()
    {
        enemy.ast = astM.GetComponent<AsteroidsM>();
        bolt.score = score.GetComponent<Score>();
        buttons.score = score.GetComponent<Score>();
        enemy.menu = menu.GetComponent<Menu>();
        for (int i = 0; i < ast.Length; i++)
        {
            ast[i].GetComponent<Asteroids>().ast = astM.GetComponent<AsteroidsM>();
        }
    }
}
