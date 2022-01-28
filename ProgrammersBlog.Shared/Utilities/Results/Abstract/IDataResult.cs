using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult // Bizlere bir Data da taşıyabilir. IList veya IEnumarable taşımak için başına out koyuldu.
    {
        public T Data { get; }

        // new DataResult<Category>(Result.success,Category) kategori değeriyle birlikte success mesaj gönderiyoruz.
        // new DataResult<IList<Category>>(Result.success,CategoryList)
    }
}
