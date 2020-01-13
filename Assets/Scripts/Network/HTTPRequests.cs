public struct SignInData
{
    public string username;
    public string password;

    public SignInData(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}

public struct AddScoreData
{
    public int score;

    public AddScoreData(int score)
    {
        this.score = score;
    }
}
