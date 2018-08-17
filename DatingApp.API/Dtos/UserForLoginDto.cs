namespace DatingApp.API.Dtos
{
    public class UserForLoginDto
    {
        //[Required] // validation attribute
        public string Username { get; set; }

        //[Required] // validation attributes
        //[StringLength(8, MinimumLength = 4, ErrorMessage = "You Must specify password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}