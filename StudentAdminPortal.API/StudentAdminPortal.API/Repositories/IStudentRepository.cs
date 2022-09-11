using System;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
	public interface IStudentRepository
	{
		// List of all students
		Task<List<Student>> GetStudentsAsync();
	}
}

