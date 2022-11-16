using OF_Project.Models;

namespace OF_Project.Logic
{
    public class UserManager
    {
       
        public Admin logged(string username, string password)
        {
            using (var context = new OrderFoodContext())
            {
                return context.Admins.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            }
           
        }
       
    }
}


//dotnet ef dbcontext scaffold "server =DESKTOP-211LKEJ; database = Northwind;uid=Hoang;pwd=1234;" Microsoft.EntityFrameworkCore.SqlServer -o Models


//dotnet ef dbcontext scaffold "server =DESKTOP-211LKEJ; database =SE1619_Project_Hotel;uid=Hoang;pwd=1234;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models