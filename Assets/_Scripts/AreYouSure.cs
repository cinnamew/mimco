using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreYouSure : MonoBehaviour
{
    [SerializeField] private Text _displayText;
    private readonly string[] _prompts =
    {
        "Are you sure?\n\nYour progress will not be saved.",
        "Are you ABSOLUTELY sure?\n\nLike, really think about what I just said. Do you still wanna quit?",
        "\"Your progress will not be saved\"\n\nAre you sure you read that part?",
        "I really don't wanna implement a whole saving system. Feel free to file a complaint with Cinna.\n\nLet the email spam begin >:)"
    };
    private int promptsIndex = 0;

    private void Start()
    {
        _displayText.text = _prompts[promptsIndex];
    }

    public void AdvancePrompt()
    {
        promptsIndex++;
        if (promptsIndex > _prompts.Length - 1) SceneManager.LoadScene(0);
        else _displayText.text = _prompts[promptsIndex];
    }

    public void ResetPromptIndex() 
    {
        promptsIndex = 0;
        _displayText.text = _prompts[promptsIndex];
    }
}
