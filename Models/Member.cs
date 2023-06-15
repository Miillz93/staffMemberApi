using System.ComponentModel.DataAnnotations;

namespace FollowUpApi.Models;


public class Member
{
    public int Id {get; set;}

    [StringLength(50)]
    public string JobTitle {get; set;}
    [StringLength(50)]
    public string EmailAddress {get; set;}
    [StringLength(50)]
    public string FirstName {get; set;}
    [StringLength(50)]
    public string LastName {get; set;}
    [StringLength(15)]
    public string Gender {get; set;}
    [StringLength(15)]
    public string Phone {get; set;}
    [StringLength(50)]
    public string Country {get; set;}
    
}