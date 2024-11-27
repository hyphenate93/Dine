using System.ComponentModel.DataAnnotations;

namespace Dine.Models;

public class ExternalLoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
