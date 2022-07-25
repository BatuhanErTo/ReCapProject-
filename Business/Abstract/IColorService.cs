using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IColorService
    {
        //GetAll, GetById, Insert, Update, Delete.

        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);

        IResult Insert(Color color);

        IResult Update(Color color);

        IResult Delete(Color color);
    }
}
