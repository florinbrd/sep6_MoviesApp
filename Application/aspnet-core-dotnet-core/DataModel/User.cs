using System.ComponentModel.DataAnnotations;

public class user {  
    [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]  
    public string Username {  
        get;  
        set;  
    }  
    [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]  
    [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]  
    public string Password {  
        get;  
        set;  
    }  
} 