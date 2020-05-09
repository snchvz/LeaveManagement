using LeaveManagement.Contracts;
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAllocation(int leaveTypeId, string employeeId)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(t => t.EmployeeId == employeeId && t.LeaveTypeId == leaveTypeId && t.Period == period)
                .Any();
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            //include is like implicit inner join
            //query brings over all possible details for anything that  we include
            var leaveAllocations = _db.LeaveAllocations
                .Include(t => t.LeaveType)
                .Include(t => t.Employee)
                .ToList();
            return leaveAllocations;
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations
                .Include(t => t.LeaveType)
                .Include(t => t.Employee)
                .FirstOrDefault(t => t.id == id);
        }

        public LeaveAllocation GetLeaveAllocationByEmployeeAndType(string id, int leaveTypeId)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .FirstOrDefault(t => t.EmployeeId == id && t.Period == period && t.LeaveTypeId == leaveTypeId);
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(t => t.EmployeeId == id && t.Period == period)
                .ToList();
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveAllocations.Any(t => t.id == id);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
