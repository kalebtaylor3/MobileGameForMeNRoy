using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShapeExplosion : MonoBehaviour
{

    public GameObject _goodExplosion;
    public GameObject _badExplosion;
    public GameObject _playerExplosion;

    private void OnEnable()
    {
        GoodShape.OnGoodShape += GoodExplosion;
        BadShape.OnBadShape += BadExplosion;
    }

    private void OnDisable()
    {
        GoodShape.OnGoodShape -= GoodExplosion;
        BadShape.OnBadShape -= BadExplosion;
    }

    void GoodExplosion()
    {
        Instantiate(_goodExplosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

    void BadExplosion()
    {
        Instantiate(_badExplosion, transform.position, Quaternion.identity);
        Instantiate(_playerExplosion, transform.position, Quaternion.identity);
    }
}
