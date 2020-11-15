using System;
using System.Collections.Generic;
using SportLiveApi.Models.Dtos;

public class TeamDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public List<PlayerDto> Players { get; set; }
}