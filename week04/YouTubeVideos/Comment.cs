class Comment
{
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public string CommenterName { get; set; }
    public string Text { get; set; }
}
