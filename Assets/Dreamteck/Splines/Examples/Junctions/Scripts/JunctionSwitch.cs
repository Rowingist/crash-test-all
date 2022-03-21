namespace Dreamteck.Splines.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class JunctionSwitch : MonoBehaviour
    {
        [System.Serializable]
        public class Bridge
        {
            public enum Direction { Forward = 1, Backward = -1, None = 0 }
            public bool active = true;
            public int a;
            public Direction aDirection = Direction.None;
            public int b;
            public Direction bDirection = Direction.None;
        }

        public Bridge[] bridges;

        private void OnValidate()
        {
            Node node = GetComponent<Node>();
            Node.Connection[] connections = node.GetConnections();
            if (bridges == null) return;
            for (int i = 0; i < bridges.Length; i++)
            {
                if (bridges[i].a < 0) bridges[i].a = 0;
                if (bridges[i].b < 0) bridges[i].b = 0;
                if (bridges[i].a >= connections.Length) bridges[i].a = connections.Length - 1;
                if (bridges[i].b >= connections.Length) bridges[i].b = connections.Length - 1;
            }
        }

        [SerializeField] private TrainHandleButtons _buttons;

        private ForkPoint _forkPoint;
        private Node _node;

        private void Awake()
        {
            _forkPoint = GetComponent<ForkPoint>();
            _node = GetComponent<Node>();
        }
        private void OnEnable()
        {
            _buttons.Left.GetComponent<Button>().onClick.AddListener(SwitchedOnLeft);
            _buttons.Right.GetComponent<Button>().onClick.AddListener(SwitchedOnRight);
        }

        private void OnDisable()
        {
            if (_buttons == null)
                return;

            _buttons.Left.GetComponent<Button>().onClick.RemoveListener(SwitchedOnLeft);
            _buttons.Right.GetComponent<Button>().onClick.RemoveListener(SwitchedOnRight);
        }
        public void SwitchedOnLeft()
        {
            Node.Connection[] connections = _node.GetConnections();
            for (int i = 0; i < connections.Length; i++)
            {
                if(connections[i].spline == _buttons.Left.ButtonLine)
                {
                    bridges[0].aDirection = Bridge.Direction.Forward;
                    bridges[0].bDirection = Bridge.Direction.None;
                }
            }

            bridges[0].active = true;
            _buttons.gameObject.SetActive(false);
            Time.timeScale = 1f;
            //StartCoroutine(ResetDirections());
        }

        public void SwitchedOnRight()
        {
            Node.Connection[] connections = _node.GetConnections();
            for (int i = 0; i < connections.Length; i++)
            {
                if (connections[i].spline == _buttons.Right.ButtonLine)
                {
                    bridges[0].bDirection = Bridge.Direction.Forward;
                    bridges[0].aDirection = Bridge.Direction.None;
                }
            }

            bridges[0].active = true;
            _buttons.gameObject.SetActive(false);
            Time.timeScale = 1f;
            //StartCoroutine(ResetDirections());
        }

        private IEnumerator ResetDirections()
        {
            yield return new WaitForSeconds(1f);
            bridges[0].active = false;
        }
    }
}
