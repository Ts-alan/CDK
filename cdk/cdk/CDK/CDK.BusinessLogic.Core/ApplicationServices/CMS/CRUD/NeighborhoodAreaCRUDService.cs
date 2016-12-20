using CDK.BusinessLogic.Core.DTO.CMS;
using Repository.Pattern.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using Db = CDK.DataAccess.Models.cdk;

namespace CDK.BusinessLogic.Core.ApplicationServices.CMS.CRUD
{
    internal class NeighborhoodAreaCRUDService : BaseEntityCRUDService<NeighborhoodArea, Db.NeighborhoodArea>
    {
        public NeighborhoodAreaCRUDService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public override IList<NeighborhoodArea> GetAll()
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            this.Mapper.Map<IList<Db.NeighborhoodArea>, IList<NeighborhoodArea>>(
                uow.Repository<Db.NeighborhoodArea>()
                .Query()
                .Include(d => d.MetroArea)
                .Select()
                .ToList()));
        }

        public override NeighborhoodArea GetById(long id)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var model = uow.Repository<Db.NeighborhoodArea>().Query(x => x.Id == id).Include(z => z.MetroArea).Select().FirstOrDefault();

                if (model == null)
                {
                    return null;
                }

                return this.Mapper.Map<NeighborhoodArea>(model);
            });
        }
    }
}