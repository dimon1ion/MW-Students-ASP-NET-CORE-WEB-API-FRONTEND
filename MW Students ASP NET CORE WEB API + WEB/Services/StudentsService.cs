using MW_Students_ASP_NET_CORE_WEB_API___WEB.Interfaces;
using MW_Students_ASP_NET_CORE_WEB_API___WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MW_Students_ASP_NET_CORE_WEB_API___WEB.Services
{
    public class StudentsService : IStudentsService
    {
        private List<Student> _students;
        public StudentsService()
        {
            _students = new List<Student>();
        }
        public async Task<int> AddStudent(Student student)
        {
            student.Id = _students.Max<Student>(s => s.Id)+1 ?? 0;
            _students.Add(student);

            return student.Id ?? -1;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            int foundId = _students.IndexOf(_students?.Where(s => s.Id == id).FirstOrDefault());
            if (foundId != -1)
            {
                _students.RemoveAt(foundId);
                return true;
            }
            return false;
        }

        public async Task<bool> EditStudent(Student student)
        {
            int foundId = _students.IndexOf(_students?.Where(s => s.Id == student?.Id).FirstOrDefault());
            if (foundId != -1)
            {
                _students[foundId] = student;
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return _students;
        }

        public async Task<Student> GetStudent(int id)
        {
            return _students.Find(x => x.Id == id);
        }
    }
}
