using LogisticControlSystemServer.Domain.Entities.Attributes;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using LogisticControlSystemServer.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Reflection;
using WebApplicationServer.Presentation.Enums;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    public abstract class GenericApiController<TEntity> : ControllerBase
        where TEntity : class
    {
        protected readonly IRepository<TEntity> repository;

        protected GenericApiController(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<TEntity>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.Get();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual ActionResult<TEntity> GetOne(int id)
        {
            var foundEntity = repository.FindById(id);

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }

        [HttpGet("Structure")]
        public virtual ActionResult<List<StructureItemModel>> GetStructure()
        {
            Type type = typeof(TEntity);

            PropertyInfo[] properties = type.GetProperties();

            List<StructureItemModel> results = new List<StructureItemModel>();

            foreach (PropertyInfo property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute;
                var validateAttribute = Attribute.GetCustomAttribute(property, typeof(ValidateAttribute)) as ValidateAttribute;

                if (attribute != null && validateAttribute != null)
                {
                    string title = attribute.Title;
                    string hint = attribute.Hint;
                    int min = validateAttribute.MinLength;
                    int max = validateAttribute.MaxLength;
                    string pattern = validateAttribute.Pattern;

                    results.Add(new StructureItemModel()
                    {
                        Type = property.PropertyType.Name,
                        Name = property.Name,
                        Title = title,
                        Hint = hint,
                        Max = max,
                        Min = min,
                        Pattern = pattern
                    });
                }
            }

            return Ok(results);
        }

        [HttpGet("IdTargetValue")]
        public virtual ActionResult<List<IdTargetValueItemModel>> GetIdTargetValue()
        {
            List<IdTargetValueItemModel> results = new List<IdTargetValueItemModel>();

            var entities = repository.Get();

            foreach (var entity in entities)
            {
                int id = 0;
                string value = "";

                Type type = entity.GetType();

                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    var attribute = Attribute.GetCustomAttribute(property, typeof(IdTargetValueAttribute)) as IdTargetValueAttribute;

                    if (typeof(TEntity).Name + "Id" == property.Name)
                    {
                        id = Convert.ToUInt16(property.GetValue(entity));
                    }

                    if (attribute != null)
                    {
                        value = Convert.ToString(property.GetValue(entity));
                    }
                }

                results.Add(new IdTargetValueItemModel()
                {
                    Id = id,
                    Value = value,
                });
            }

            return Ok(results);
        }


        [HttpPost]
        public virtual ActionResult<TEntity> Create([FromBody] TEntity toCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = repository.Create(toCreate);

            if (created != null)
            {
                return Ok(created);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public virtual ActionResult<TEntity> Update(int id, [FromBody] TEntity toUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = repository.Update(id, toUpdate);

            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }


        [HttpDelete("{id}")]
        public virtual ActionResult<TEntity> Delete(int id)
        {
            var entity = repository.FindById(id);

            if (entity == null)
            {
                return NotFound();
            }
            repository.Remove(entity);

            return Ok(entity);
        }
    }
}
