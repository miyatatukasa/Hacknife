using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingBehavior : MonoBehaviour
{
    public event System.Action<GameObject> onFound = (obj) => { };
    public event System.Action<GameObject> onLost = (obj) => { };

    

    [SerializeField, Range(0.0f, 360.0f)]
    private float m_searchAngle = 0.0f;

    private SphereCollider m_sphereCollider = null;

    public float SearchAngle
    {
        get { return m_searchAngle; }
    }

    public float SearchRadius
    {
        get
        {
            if (m_sphereCollider == null)
            {
                m_sphereCollider = GetComponent<SphereCollider>();
            }
            return m_sphereCollider != null ? m_sphereCollider.radius : 0.0f;
        }
    }

    private float m_searchCosTheta = 0.0f;

    private void Awake()
    {
        m_sphereCollider = GetComponent<SphereCollider>();
        ApplySearchAngle();
    }

    // �V���A���C�Y���ꂽ�l���C���X�y�N�^�[��ŕύX���ꂽ��ĂԁB
    private void OnValidate()
    {
        ApplySearchAngle();
    }

    private void ApplySearchAngle()
    {
        float searchRad = m_searchAngle * 0.5f * Mathf.Deg2Rad;
        m_searchCosTheta = Mathf.Cos(searchRad);
    }

    private class FoundData
    {
        public FoundData(GameObject i_object)
        {
            m_obj = i_object;
        }

        private GameObject m_obj = null;
        private bool m_isCurrentFound = false;
        private bool m_isPrevFound = false;

        public GameObject Obj
        {
            get { return m_obj; }
        }

        public Vector3 Position
        {
            get { return Obj != null ? Obj.transform.position : Vector3.zero; }
        }

        public void Update(bool i_isFound)
        {
            m_isPrevFound = m_isCurrentFound;
            m_isCurrentFound = i_isFound;
        }

        public bool IsFound()
        {
            return m_isCurrentFound && !m_isPrevFound;
        }

        public bool IsLost()
        {
            return !m_isCurrentFound && m_isPrevFound;
        }

        public bool IsCurrentFound()
        {
            return m_isCurrentFound;
        }
    }

    private List<FoundData> m_foundList = new List<FoundData>();

    /// <summary>
    /// �n�b�L���O���ɍ��G�������Z�b�g����
    /// </summary>
    public void ResetList()
    {
        m_foundList.Clear();
    }

    private void OnDisable()
    {
        m_foundList.Clear();
    }

    private void OnTriggerEnter(Collider i_other)
    {
        GameObject enterObject = i_other.gameObject;

        // �O�̂��ߑ��d�o�^����Ȃ��悤�ɂ���B
        if (m_foundList.Find(value => value.Obj == enterObject) == null)
        {
            m_foundList.Add(new FoundData(enterObject));
        }
    }

    private void OnTriggerExit(Collider i_other)
    {
        GameObject exitObject = i_other.gameObject;

        var foundData = m_foundList.Find(value => value.Obj == exitObject);
        if (foundData == null)
        {
            return;
        }

        if (foundData.IsCurrentFound())
        {
            onLost(foundData.Obj);
        }

        m_foundList.Remove(foundData);
    }

    private void Update()
    {
        UpdateFoundObject();
    }

    private void UpdateFoundObject()
    {
        foreach (var foundData in m_foundList)
        {
            GameObject targetObject = foundData.Obj;
            if (targetObject == null)
            {
                continue;
            }

            bool isFound = CheckFoundObject(targetObject);
            foundData.Update(isFound);

            if (foundData.IsFound())
            {
                onFound(targetObject);
            }
            else if (foundData.IsLost())
            {
                onLost(targetObject);
            }
        }
    }

    private bool CheckFoundObject(GameObject i_target)
    {
        Vector3 targetPosition = i_target.transform.position;
        Vector3 myPosition = transform.position;

        Vector3 myPositionXZ = Vector3.Scale(myPosition, new Vector3(1.0f, 0.0f, 1.0f));
        Vector3 targetPositionXZ = Vector3.Scale(targetPosition, new Vector3(1.0f, 0.0f, 1.0f));

        Vector3 toTargetFlatDir = (targetPositionXZ - myPositionXZ).normalized;
        Vector3 myForward = transform.forward;
        if (!IsWithinRangeAngle(myForward, toTargetFlatDir, m_searchCosTheta))
        {
            return false;
        }

        return true;
    }

    private bool IsWithinRangeAngle(Vector3 i_forwardDir, Vector3 i_toTargetDir, float i_cosTheta)
    {
        // �����x�N�g���������ꍇ�́A���ʒu�ɂ�����̂��Ɣ��f����B
        if (i_toTargetDir.sqrMagnitude <= Mathf.Epsilon)
        {
            return true;
        }

        float dot = Vector3.Dot(i_forwardDir, i_toTargetDir);
        return dot >= i_cosTheta;
    }

}
