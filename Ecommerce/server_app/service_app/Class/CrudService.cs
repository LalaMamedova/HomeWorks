using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CrudService<T> 
{
    private readonly ICollection<T> _values;
    private readonly DbContext _dbContext;
    public CrudService(ICollection<T> values, DbContext dbContext)
    {
        _values = values;
        _dbContext = dbContext;
    }


    public bool Post(T? value)
    {
        if (value != null)
        {
            _dbContext.Add(value);
            _dbContext.SaveChanges();
            return true;
        }
       return false;
    }

    public T? Put(T value, int id, Func<T, int> idSelector)
    {
        if (idSelector(value) == id)
        {
            return value;
        }
        throw new ArgumentException($"{id} is not valid");
    }

    public bool Delete(int id, Func<T, int> idSelector)
    {
        var removeValue = _values.FirstOrDefault(x => idSelector(x) == id);
        if (removeValue != null)
        {
            _dbContext.Remove(removeValue);
            _dbContext.SaveChanges();
            return true;
        }

        return false;

    }

}