using Common.Domain;

public class RolePermission : BaseEntity
{
    public long RoldeId { get; set; }

    public Permission Permission { get; set; }

}