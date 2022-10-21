using System.Security.AccessControl;
namespace WebinarUbuntu.Entities;

public class EntityBase
{
    public int Id { get; set; }

    public bool Status { get; set; }

    protected EntityBase()
    {
        Status = true;
    }
}