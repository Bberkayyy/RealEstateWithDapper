﻿namespace RealEstate_Api_Dapper.Dtos.SubFeatureDtos.Responses;

public class GetAllSubFeatureResponseDto
{
    public int Id { get; set; }
    public string Icon { get; set; }
    public string TopTitle { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string SubTitle { get; set; }
}
