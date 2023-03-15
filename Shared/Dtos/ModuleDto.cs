﻿namespace LexiconLMSBlazor.Shared.Dtos
{
    public class ModuleDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CourseId { get; set; }

        public IEnumerable<ActivityDto> Activities { get; set; } = new List<ActivityDto>();
    } 
   
}
