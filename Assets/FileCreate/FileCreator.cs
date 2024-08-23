using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class FolderCreator : MonoBehaviour
{
    // ���� �̸��� ��θ� �����մϴ�.
    [SerializeField] private List<string> _fileNames = new();
    private string folderPath;

    void Start()
    {
        // ���� ��θ� �����մϴ�. (���⼭�� Application.dataPath�� ����Ͽ� Assets ���� ���� ������ �����մϴ�)
        //folderPath = Path.Combine(Application.dataPath, folderName);
    }

    void CreateFolder()
    {
        // ������ �������� ������ �� ������ �����մϴ�.
        if (!Directory.Exists(folderPath))
        {
            // ���� ����
            Directory.CreateDirectory(folderPath);

            Debug.Log("Folder created at: " + folderPath);
        }
        else
        {
            Debug.Log("Folder already exists at: " + folderPath);
        }
    }

    [ContextMenu("���� ����")]
    public void OnCreateFolder()
    {

    }
}
