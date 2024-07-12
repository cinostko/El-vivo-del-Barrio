using System.Collections;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Texture2D _normal;
    [SerializeField] private Texture2D[] _animated;
    [SerializeField] private float _time;
    private WaitForSeconds _delay;
    private int _index;

    private void Awake() => _delay = new WaitForSeconds(_time);
    private IEnumerator Start()
    {
        yield return _delay; _index++;
        StartCoroutine(Start());
    }
    private void Update()
    {
        bool isPressing = Input.GetMouseButton(1);

        int index = _index % _animated.Length;
        Cursor.SetCursor(isPressing ? _animated[index] : _normal, Vector2.zero, CursorMode.ForceSoftware);
    }
}