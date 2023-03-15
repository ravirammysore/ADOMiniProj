using System;
using System.Collections.Generic;
using System.Data;

using CoreLogic.Model;

namespace CoreLogic.Data;

class StudentDAL : BaseDAL
{
    public int Create(Student item)
    {
        string qry = $"INSERT INTO Student VALUES ({item.Id}, '{item.Name}', '{item.Email}', '{item.Mobile}')";

        int rowsAffected = ExecuteNonQuery(qry);

        return rowsAffected;
    }
    public List<Student> Retrieve()
    {
        var qry = "select * from student";

        var dataTable = ExecuteQuery(qry);

        var studentsList = new List<Student>();
        foreach (DataRow dataRow in dataTable.Rows)
        {
            var student = new Student();

            student.Id = (int)dataRow["id"];
            student.Name = (string)dataRow["name"];
            student.Email = (string)dataRow["email"];
            student.Mobile = (string)dataRow["mobile"];

            studentsList.Add(student);
        }
        return studentsList;
    }
    public int Update(Student item)
    {
        var qry = $"UPDATE Student SET Name = '{item.Name}' WHERE id = {item.Id};";

        int rowsAffected = ExecuteNonQuery(qry);

        return rowsAffected;
    }
    public int Delete(int id)
    {
        var qry = $"DELETE FROM Student WHERE id = {id};";

        int rowsAffected = ExecuteNonQuery(qry);

        return rowsAffected;
    }
}
