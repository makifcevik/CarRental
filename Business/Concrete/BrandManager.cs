using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : ManagerBase<Brand, IBrandDal>, IBrandService
    {
        public BrandManager(IBrandDal dataDal) : base(dataDal)
        {

        }

        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]   
        public override IResult Add(Brand entity)
        {
            return base.Add(entity);
        }
    }
}
