using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class FolderCreator : MonoBehaviour
{
    // 폴더 이름과 경로를 설정합니다.
    [SerializeField] private List<string> _fileNames = new();
    private string folderPath;

    void Start()
    {
        // 폴더 경로를 설정합니다. (여기서는 Application.dataPath를 사용하여 Assets 폴더 내에 폴더를 생성합니다)
        //folderPath = Path.Combine(Application.dataPath, folderName);
    }

    void CreateFolder()
    {
        // 폴더가 존재하지 않으면 새 폴더를 생성합니다.
        if (!Directory.Exists(folderPath))
        {
            // 폴더 생성
            Directory.CreateDirectory(folderPath);

            Debug.Log("Folder created at: " + folderPath);
        }
        else
        {
            Debug.Log("Folder already exists at: " + folderPath);
        }
    }

    [ContextMenu("폴더 생성")]
    public void OnCreateFolder()
    {

    }
}
