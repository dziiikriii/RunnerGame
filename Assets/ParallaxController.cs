using UnityEngine;

public class PrallaxController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private float backgroundWidth;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;

        // Hitung lebar background berdasarkan Renderer
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Gerakkan background ke kiri
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Hitung batas kiri kamera (view)
        float leftCamEdge = mainCam.transform.position.x - (mainCam.orthographicSize * mainCam.aspect);

        // Jika background sudah keluar layar di kiri, pindahkan ke kanan
        if (transform.position.x + backgroundWidth / 2 < leftCamEdge)
        {
            float rightCamEdge = mainCam.transform.position.x + (mainCam.orthographicSize * mainCam.aspect);
            Vector3 newPos = transform.position;
            newPos.x = rightCamEdge + backgroundWidth / 2;
            transform.position = newPos;
        }
    }
}