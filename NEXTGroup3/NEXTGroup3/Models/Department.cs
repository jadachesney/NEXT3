namespace NEXTGroup3.Models
{
  public class Department
  {
    // DEPARTMENT ID
    private int id;
    public int Id { get { return id; } set { id = value; } }

    // DEPARTMENT NAME
    private string name;
    public string Name { get { return name; } set { name = value; } }

    // DEPARTMENT DESCRIPTION
    private string description;
    public string Description { get { return description; } set { description = value; } }

    // APPLICATION LINK
    private string link;
    public string Link { get { return link; } set { link = value; } }
  }
}
