using Assets._Project.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PointsText : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField; 
    [SerializeField] private PlayerPointsManager _playerPoints;

    private int _points;

    // Start is called before the first frame update
    void Start()
    {
        _playerPoints.OnPointsAdded += PlayerPoints_OnPointsAdded;
        _points = 0;
        _textField.text = _points.ToString();
    }

    private void PlayerPoints_OnPointsAdded(object sender, System.EventArgs e)
    {
        _points++;
        _textField.text = _points.ToString();
    }
}
