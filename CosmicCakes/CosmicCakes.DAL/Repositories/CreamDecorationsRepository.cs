//using CosmicCakes.DAL.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace CosmicCakes.DAL.Repositories
//{
//    public class CreamDecorationsRepository : ContextRepository<CreamDecorarion>, ICreamDecorationsRepository
//    {
//        public IEnumerable<string> GetAll()
//        {
//            using (var context = GetCakeContext())
//            {
//                try
//                {
//                    var query = from dec in context.CreamDecorarions
//                                select dec.DecoreType;
//                    return query.ToList();
//                }
//                catch (Exception)
//                {
//                    throw;
//                }
//            }
//        }
//    }
//}
