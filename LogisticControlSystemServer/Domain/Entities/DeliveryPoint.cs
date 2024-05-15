﻿using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class DeliveryPoint
    {
        public int DeliveryPointId { get; set; }

        [IdTargetValue]
        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z0-9]|\s)*$", maxLength: 70)]
        [Description(title: "Наименование", hint: "Введите название точки назначения")]
        public string Name { get; set; }

        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z0-9]|\s|[,.])*$", maxLength: 70)]
        [Description(title: "Адрес", hint: "Введите адрес доставки")]
        public string Address { get; set; }

        [Validate(pattern: @"^(\d+|\d+\,\d+)$", maxLength: 25)]
        [Description(title: "Широта", hint: "Введите широту")]
        public float Latitude { get; set; }

        [Validate(pattern: @"^(\d+|\d+\,\d+)$", maxLength: 25)]
        [Description(title: "Долгота", hint: "Введите долготу")]
        public float Longitude { get; set; }
    }
}
