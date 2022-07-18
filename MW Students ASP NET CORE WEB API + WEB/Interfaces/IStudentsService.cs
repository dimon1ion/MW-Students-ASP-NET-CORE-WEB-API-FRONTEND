using MW_Students_ASP_NET_CORE_WEB_API___WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MW_Students_ASP_NET_CORE_WEB_API___WEB.Interfaces
{
    public interface IStudentsService
    {
        Task<Student> GetStudent(int id);
        Task<IEnumerable<Student>> GetAllStudents();
        Task<int> AddStudent(Student student);
        Task<bool> DeleteStudent(int id);
        Task<bool> EditStudent(Student student);
    }
}
