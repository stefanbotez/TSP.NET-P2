using AutoMapper;
using P1.Data;
using P1.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceMedia : IServiceMedia
    {
        MapperConfiguration config;
        IMapper iMapper;
        IUnitOfWork u;
        public ServiceMedia()
        {
            u = new UnitOfWork();

            config = new MapperConfiguration(
            cfg => {
                cfg.CreateMap<Media, MediaDTO>();
                cfg.CreateMap<Tags, TagDTO>();
            });
            iMapper = config.CreateMapper();
        }
        public List<MediaDTO> GetAllMedia()
        {
            var lm = u.Media.GetAll();
            IEnumerable<MediaDTO> lmDTO = iMapper.Map<IEnumerable<Media>, IEnumerable<MediaDTO>>(lm);
            return lmDTO.ToList<MediaDTO>();
        }
        public MediaDTO GetMediaById(int id)
        {
            Media media = u.Media.Get(id);
            MediaDTO mediaDTO = iMapper.Map<Media, MediaDTO>(media);
            return mediaDTO;
        }
        public MediaDTO GetMediaByPath(string path)
        {
            Media media = u.Media.GetByPath(path);
            return iMapper.Map<Media, MediaDTO>(media);
        }
        public IEnumerable<MediaDTO> MediaQuery(Expression<Func<MediaDTO, bool>> whereExpression)
        {
            Expression<Func<Media, bool>> where = iMapper.Map<Expression<Func<MediaDTO, bool>>, Expression<Func<Media, bool>>>(whereExpression);
            IEnumerable<Media> result = u.Media.Query(where);
            return iMapper.Map<IEnumerable<Media>, IEnumerable<MediaDTO>>(result);
        }
        public MediaDTO AddMedia(MediaDTO mediaDTO)
        {
            Media media = new Media();
            media = iMapper.Map<MediaDTO, Media>(mediaDTO);
            return iMapper.Map<Media, MediaDTO>(u.Media.Add(media));
        }
        public void UpdateMedia(MediaDTO newMedia)
        {
            Media media = iMapper.Map<MediaDTO, Media>(newMedia);
            u.Media.Update(media);
        }
        public void DeleteMedia(MediaDTO mediaDTO)
        {
            Media media = iMapper.Map<MediaDTO, Media>(mediaDTO);
            u.Media.Delete(media);
        }

        public TagDTO GetTagById(int id)
        {
            Tags tag = u.Tags.Get(id);
            TagDTO tagDTO = iMapper.Map<Tags, TagDTO>(tag);
            return tagDTO;
        }
        public TagDTO AddTag(TagDTO tagDTO)
        {
            Tags tag = iMapper.Map<TagDTO, Tags>(tagDTO);
            return iMapper.Map<Tags, TagDTO>(u.Tags.Add(tag));
        }
        public IEnumerable<TagDTO> TagQuery(Expression<Func<TagDTO, bool>> whereExpression)
        {
            Expression<Func<Tags, bool>> where = iMapper.Map<Expression<Func<TagDTO, bool>>, Expression<Func<Tags, bool>>>(whereExpression);
            IEnumerable<Tags> result = u.Tags.Query(where);
            return iMapper.Map<IEnumerable<Tags>, IEnumerable<TagDTO>>(result);
        }
        public void DeleteTag(TagDTO tagDTO)
        {
            Tags tag = iMapper.Map<TagDTO, Tags>(tagDTO);
            u.Tags.Delete(tag);
        }


    }
}
