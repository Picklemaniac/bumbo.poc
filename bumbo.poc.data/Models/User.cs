namespace bumbo.poc.data.Models;

public sealed class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DepartmentId { get; set; }
    public int NFCId { get; set; }
    public DateOnly Birthdate { get; set; }
    public string Emailaddress { get; set; }
    public string PhoneNumber { get; set; }
    public string IBAN { get; set; }
    public int RoleId { get; set; }
    public string Zipcode { get; set; }
    public int BranchId { get; set; }
    public int HouseNumber { get; set; }
    public char HouseNumberAddition { get; set; }
    public DateOnly EmployedSince { get; set; }
    public int CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ArchivedAt { get; set; }
}