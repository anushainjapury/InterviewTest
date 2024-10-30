using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InterviewTest.Database;
using InterviewTest.Returns;

namespace InterviewTest.Returns
{
    public class ReturnRepository
    {
        private List<IReturn> returns;
        //private List<Products> ReturnProducts { get; set; }
        public ReturnRepository()
        {
            returns = new List<IReturn>();
        }

        public void Add(IReturn newReturn)
        {
            returns.Add(newReturn);
        }

        public void Remove(IReturn removedReturn)
        {
            returns = returns.Where(o => !string.Equals(removedReturn.ReturnNumber, o.ReturnNumber)).ToList();
        }

        public List<IReturn> Get()
        {
            return returns;
        }
        public float GetTotalReturns()
        {
            return 0;
        }


        //DB Refactoring Attempt

/*
 *      private readonly ApplicationDbContext _context;

        public ReturnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //--------saving return------

        public async Task SaveReturnAsync(Return returnOrder)
        {
            _context.Returns.Add(returnOrder);
            await _context.SaveChangesAsync();
        }

        //-------updating return--------

        public async Task UpdateReturnAsync(Return returnOrder)
        {
            _context.Entry(returnOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //---------pulling return-------

        public async Task<Return> GetReturnByIdAsync(int returnId)
        {
            return await _context.Returns
                .Include(r => r.OriginalOrder)      //original order
                .Include(r => r.ReturnedProducts)   //returned products
                .FirstOrDefaultAsync(r => r.ReturnId == returnId);
        }
        */


}
}
