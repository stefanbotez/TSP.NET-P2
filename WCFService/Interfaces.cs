using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFService
{
    [ServiceContract]
    public interface IMedia
    {
        [OperationContract]
        MediaDTO GetMediaById(int id);
        [OperationContract]
        MediaDTO GetMediaByPath(string path);
        [OperationContract]
        IEnumerable<MediaDTO> MediaQuery(Expression<Func<MediaDTO, bool>> whereExpression);
        [OperationContract]
        MediaDTO AddMedia(MediaDTO media);
        [OperationContract]
        void UpdateMedia(MediaDTO newMedia);
        [OperationContract]
        void DeleteMedia(MediaDTO media);
        [OperationContract]
        List<MediaDTO> GetAllMedia();
    }
    [ServiceContract]
    public interface ITag
    {
        [OperationContract]
        TagDTO GetTagById(int id);
        [OperationContract]
        TagDTO AddTag(TagDTO tag);
        [OperationContract]
        IEnumerable<TagDTO> TagQuery(Expression<Func<TagDTO, bool>> whereExpression);
        [OperationContract]
        void DeleteTag(TagDTO tag);
    }
    [ServiceContract]
    public interface IServiceMedia : IMedia, ITag
    { }
}
