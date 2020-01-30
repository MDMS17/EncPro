using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.NCPDP
{
    public static class DataAccess
    {
        private static NCPDPContext _context;
        public static int SaveHisHeader(HisHeader FH)
        {
            _context = new NCPDPContext(new DbContextOptionsBuilder<NCPDPContext>().Options);
            _context.HisHeaders.Add(FH);
            _context.SaveChanges();
            return FH.FileID;
        }
        public static void UpdateHisHeader(HisHeader hh)
        {
            _context = new NCPDPContext(new DbContextOptionsBuilder<NCPDPContext>().Options);
            HisHeader header = _context.HisHeaders.Find(hh.FileID);
            header.Total_Gross_Amount_Due = hh.Total_Gross_Amount_Due;
            header.Total_Net_Amount_Due = hh.Total_Net_Amount_Due;
            header.Total_Patient_Pay_Amount = hh.Total_Patient_Pay_Amount;
            header.Total_Record_Count = hh.Total_Record_Count;
            _context.SaveChanges();
        }
        public static int SaveHisDetail(ref HisDetail hd)
        {
            _context = new NCPDPContext(new DbContextOptionsBuilder<NCPDPContext>().Options);
            _context.HisDetails.Add(hd);
            _context.SaveChanges();
            return hd.DetailID;
        }
        public static void SaveHisCompound1(ref HisCompound1 hc1)
        {
            _context = new NCPDPContext(new DbContextOptionsBuilder<NCPDPContext>().Options);
            _context.HisCompound1.Add(hc1);
            _context.SaveChanges();
        }
        public static void SaveHisCompound2(ref HisCompound2 hc2)
        {
            _context = new NCPDPContext(new DbContextOptionsBuilder<NCPDPContext>().Options);
            _context.HisCompound2.Add(hc2);
            _context.SaveChanges();
        }
        public static void emptyTables()
        {
            _context = new NCPDPContext(new DbContextOptionsBuilder<NCPDPContext>().Options);
            _context.Database.ExecuteSqlRaw("if object_id('dbo.HisHeaders') is not null begin delete from HisCompound1;dbcc checkident('dbo.HisCompound1',reseed,0);delete from HisCompound2;dbcc checkident('dbo.HisCompound2',reseed,0);delete from HisDetails;dbcc checkident('dbo.HisDetails',reseed,0);delete from HisHeaders;dbcc checkident('dbo.HisHeaders',reseed,0);end");
        }
    }
}
