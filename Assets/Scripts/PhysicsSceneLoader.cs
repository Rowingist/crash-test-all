using UnityEngine.SceneManagement;
using UnityEngine;

public class PhysicsSceneLoader : MonoBehaviour
{
    public string physicSceneName;
    public float PhySceneTimeScale = 1;
    private PhysicsScene physicsScene;

    private void Start()
    {
        Scene scene = SceneManager.LoadScene(physicSceneName, new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.Physics3D));
        physicsScene = scene.GetPhysicsScene();
    }   
        

    private void FixedUpdate()
    {
        if (physicsScene == null)
            return;

        physicsScene.Simulate(PhySceneTimeScale);
    }
}
