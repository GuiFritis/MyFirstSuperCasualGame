using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    [Header("Pieces")]    
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;
    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
    public float timeToPieces = 0.3f;

    [SerializeField]
    private int _index = 0;
    private GameObject _curLevel;
    private List<LevelPieceBase> _spawnedPieces;

    void Awake()
    {
        SpawnNextLevel();
    }

    private void SpawnNextLevel(){
        if(_curLevel != null){
            Destroy(_curLevel);
            _index++;
            if(_index >= levels.Count){
                _index = 0;
            }
        }
        _curLevel = Instantiate(levels[_index], container);
        _curLevel.transform.localScale = Vector3.zero;
    }

    #region 

    private void CreateLevelPieces(){
         _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < piecesStartNumber; i++)
        {
            CreateLevelPiece(levelPiecesStart);
        }
        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(levelPieces);
        }
        for (int i = 0; i < piecesEndNumber; i++)
        {
            CreateLevelPiece(levelPiecesEnd);
        }

        // StartCoroutine(nameof(CreateLevelPiceCoroutine));
    }

    // IEnumerator CreateLevelPiceCoroutine(){
    //     _spawnedPieces = new List<LevelPieceBase>();

    //     for (int i = 0; i < piecesNumber; i++)
    //     {
    //         CreateLevelPiece();
    //     }

    //     yield return new WaitForSeconds(timeToPieces);
    // }

    private void CreateLevelPiece(List<LevelPieceBase> list){
        var piece = levelPieces[Random.Range(0, levelPieces.Count-1)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0){
            var lastPiece = _spawnedPieces[_spawnedPieces.Count-1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;

        }

        _spawnedPieces.Add(spawnedPiece);
    }

    #endregion

}
