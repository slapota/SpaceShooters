using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static void Bolt(Score score, GameObject go)
    {
        if(score != null)
        {
            score.score++;
        }
        Destroy(go);
    }
    public static void Asteroid(ParticleSystem ps, Collider c, AsteroidsM ast, GameObject go)
    {
        if (c.name == "Bolt(Clone)" || c.name == "Player")
        {
            ParticleSystem instance = Instantiate(ps, go.transform.position, go.transform.rotation);
            instance.Play();
            if (go.name.Contains("Enemy"))
            {
                ast.enemyBoom.Play();
            }
            else
            {
                ast.boom.Play();
            }
            Destroy(go);
        }
    }
    public static void Player(Collider c, ParticleSystem ps, GameObject go, AsteroidsM ast)
    {
        if (c.name != "Bolt(Clone)")
        {
            Instantiate(ps, go.transform.position, go.transform.rotation).Play();
            ast.playerBoom.Play();
            go.SetActive(false);
            Time.timeScale = 0.05f;
        }
    }
    /*public static void Enemy(ParticleSystem ps, Collider c, )
    {
        if (other.name == "Bolt(Clone)" || other.name == "Player")
        {
            ParticleSystem instance = Instantiate(explosion, transform.position, transform.rotation);
            instance.Play();
            ast.enemyBoom.Play();
            Destroy(gameObject);
        }
    }*/
}
