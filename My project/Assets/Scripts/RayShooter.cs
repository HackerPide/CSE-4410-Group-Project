using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    public int damage = 1;
    public const int baseDamage = 1;

    public Transform attackPoint;
    // public ParticleSystem muzzleFlash;
    public GameObject bulletHoleGraphic;

    // Private variable that has a reference to the camera
    private Camera cam;

    private void OnEnable() {
        Messenger<int>.AddListener(GameEvent.PLAYER_DAMAGE_CHANGED, OnDamageChanged);
    }

    private void OnDisable()
    {
        Messenger<int>.RemoveListener(GameEvent.PLAYER_DAMAGE_CHANGED, OnDamageChanged);
    }

    private void OnDamageChanged(int value) {
        damage = baseDamage * value;
    }

    // Start is called before the first frame update
    void Start() {
        // Use GetComponent<Camera> to get a reference to the camera
        // The camera (as is this script) is attached to the player object
        cam = GetComponent<Camera>();

        // Hide the cursor at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {

       
        // Run the following code if the player clicks the left mouse button
        if (Input.GetMouseButtonDown(0)) {
            // Use a Vector3 to store the location of the middle of the screen
            // Divide the width and height by 2 to get the midpoint; these become
            // the x and y values of the vector, with the z value being zero
            Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);

            // Create a ray by calling ScreenPointToRay
            // Pass in the point, as this is used as the origin for the ray
            Ray ray = cam.ScreenPointToRay(point);
            // muzzleFlash.Play();
            // Create a RaycastHit object to figure out where the ray hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                // Get a reference to the object that was hit, then
                // get a reference to that object's ReactiveTarget script,
                // if there is one
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                // If the ray had hit an enemy, (that is, if "target" isn't null),
                // indicate that an enemy was hit.
                // Otherwise, place a sphere.
                if (target != null) {
                    //Debug.Log("Target hit!");
                    target.ReactToHit(damage);
                }
                Instantiate(bulletHoleGraphic, hit.point, Quaternion.Euler(0, 180, 0));
                
            }
        }
    }

    // Coroutine.
    // This places a sphere at a set of coords, then removes the sphere after 1 second
    private IEnumerator SphereIndicator(Vector3 pos) {
        // Create a new game object that's a sphere
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        
        // Then place it at the given position
        sphere.transform.position = pos;
        
        // Then wait one second
        yield return new WaitForSeconds(1);
        
        // Then destroy the sphere
        Destroy(sphere);
    }

    // OnGUI method
    // For drawing crosshairs on the screen
    private void OnGUI() {
        // Font size
        int size = 12;
        
        // Coords at which the crosshairs are drawn
        float posX = cam.pixelWidth/2 - size/4;
        float posY = cam.pixelHeight/2 - size/2;
        
        // Draw the crosshairs as text
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }


    

}