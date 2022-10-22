using UnityEngine;

public class Polaroid : MonoBehaviour
{
    public GameObject photoPrefab = null;
    public GameObject main = null;
    public GameObject viewfinder = null;
    public Transform spawnLocation = null;

    // Private variables retrieved on Awake
    private MeshRenderer mainRenderer = null;
    private MeshRenderer viewfinderRenderer = null;
    private Camera mainCamera;
    private Camera viewfinderCamera;

    private void Awake()
    {
        // Retrieve MeshRenderer and Camera from main and viewfinder
        mainRenderer = main.GetComponent<MeshRenderer>();
        viewfinderRenderer = viewfinder.GetComponent<MeshRenderer>();
        mainCamera = main.GetComponentInChildren<Camera>();
        viewfinderCamera = viewfinder.GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        CreateRenderTexture();
        TurnOff();
    }

    // Create textures, set output of cameras to respective new textures and generate material from textures for renderers
    private void CreateRenderTexture()
    {
        // Render Texture for main camera
        RenderTexture mainTexture = new RenderTexture(256, 256, 32, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
        mainTexture.antiAliasing = 4;

        mainCamera.targetTexture = mainTexture;
        mainRenderer.material.mainTexture = mainTexture;

        // Render Texture for viewfinder
        RenderTexture viewfinderTexture = new RenderTexture(256, 256, 32, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
        viewfinderTexture.antiAliasing = 4;

        viewfinderCamera.targetTexture = viewfinderTexture;
        viewfinderRenderer.material.mainTexture = viewfinderTexture;
    }

    public void TakePhoto()
    {
        Photo newPhoto = CreatePhoto();
        SetPhotoImage(newPhoto);
    }

    private Photo CreatePhoto()
    {
        GameObject photoObject = Instantiate(photoPrefab, spawnLocation.position, spawnLocation.rotation, transform);
        return photoObject.GetComponent<Photo>();
    }

    private void SetPhotoImage(Photo photo)
    {
        Texture2D newTexture = RenderCameraToTexture(mainCamera);
        photo.SetImage(newTexture);
    }

    private Texture2D RenderCameraToTexture(Camera camera)
    {
        // Remember currently active render texture
        RenderTexture currentActiveRT = RenderTexture.active;

        camera.Render();
        RenderTexture.active = camera.targetTexture;

        Texture2D photo = new Texture2D(256, 256, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        photo.Apply();

        // Restorie previously active render texture
        RenderTexture.active = currentActiveRT;

        return photo;
    }

    public void TurnOn()
    {
        mainCamera.enabled = true;
        mainRenderer.material.color = Color.white;
        viewfinderCamera.enabled = true;
        viewfinderRenderer.material.color = Color.white;
    }

    public void TurnOff()
    {
        mainCamera.enabled = false;
        mainRenderer.material.color = Color.black;
        viewfinderCamera.enabled = false;
        viewfinderRenderer.material.color = Color.black;
    }
}
