using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    public List<PieceBaseSetupSO> levelPieceBaseSetups;
    public float timeToPieces = 0.3f;

    [Header("Animation")]
    public float scaleDur = .2f;
    public float scaleDelay = .2f;
    public Ease scaleEase = Ease.InCirc;

    [SerializeField]
    private int _index = 0;
    private GameObject _curLevel;
    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();

    private PieceBaseSetupSO _curSetup;

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
        _curLevel.transform.localScale = Vector3.one;
        CreateLevelPieces();
    }

    #region 

    private void CreateLevelPieces(){
        CleanSpawnedPieces();

        if(_curSetup != null){
            _index++;
            if(_index >= levelPieceBaseSetups.Count){
                ResetLevelIndex();
            }
        }

        _curSetup = levelPieceBaseSetups[_index];

        for(int i = 0; i < _curSetup.piecesStartNumber; i++){
            CreateLevelPiece(_curSetup.levelPiecesStart);
        }

        for (int i = 0; i < _curSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_curSetup.levelPieces);
        }

        for (int i = 0; i < _curSetup.piecesEndNumber; i++)
        {
            CreateLevelPiece(_curSetup.levelPiecesEnd);
        }

        ColorManager.Instance.ChangeColorByType(_curSetup.artType);

        StartCoroutine(ScalePiecesByTime());

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

    private IEnumerator ScalePiecesByTime(){
        foreach(var p in _spawnedPieces){
            p.transform.localScale = Vector3.zero;
        }

        yield return null;

        for(int i = 0; i < _spawnedPieces.Count; i++){
            _spawnedPieces[i].transform.DOScale(Vector3.one, scaleDur).SetEase(scaleEase);
            yield return new WaitForSeconds(scaleDelay);
        }

        CoinsAnimationManager.Instance.StartAnimations();

    }

    private void CreateLevelPiece(List<LevelPieceBase> list){
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, _curLevel.transform);

        if(_spawnedPieces.Count > 0){
            var lastPiece = _spawnedPieces[_spawnedPieces.Count-1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;

        } else {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        var artPieces = spawnedPiece.GetComponentsInChildren<ArtPiece>();

        foreach (var item in artPieces)
        {
            item.ChangePiece(ArtManager.Instance.GetSetupByType(_curSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    private void CleanSpawnedPieces(){
        foreach(var spawned in _spawnedPieces){
            Destroy(spawned.gameObject);
        }
        _spawnedPieces.Clear();
    }

    private void ResetLevelIndex(){
        _index = 0;
    }

    #endregion

}
