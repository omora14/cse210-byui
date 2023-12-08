using System.Data.SqlTypes;

public class Video
{


    public string _title;
    public string _author;
    public int _length;
    public List<Comment> comments;


    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string username, string text)
    {
        Comment comment = new Comment(username, text);
        comments.Add(comment);
    }

    public int numberOfComments()
    {
        return comments.Count;
    }
    public List<Comment> sendComments()
    {
        return comments;
    }




}