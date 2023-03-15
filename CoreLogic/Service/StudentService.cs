using System;
using System.Collections.Generic;
using System.Linq;

using CoreLogic.Data;
using CoreLogic.Model;

namespace CoreLogic.Service;

public class StudentService
{
    private readonly StudentDAL dal;
    public StudentService()
    {
        dal = new StudentDAL();
    }
    public int Create(Student item)
    {
        int rowsAffedted = dal.Create(item);
        return rowsAffedted;
    }

    public List<Student> RetrieveAll()
    {
        return dal.Retrieve();
    }

    public int Update(Student item)
    {
        return dal.Update(item);
    }
    public int Delete(int id)
    {
        return dal.Delete(id);
    }
}
