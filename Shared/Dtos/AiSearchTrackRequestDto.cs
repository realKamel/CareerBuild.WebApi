using System;

namespace Shared.Dtos;

public class AiSearchTrackRequestDto
{
	public required string Search_query { get; set; }
	public List<Item> Items { get; set; } = [];
}

public class Item
{
	public int Id { get; set; }
	public required string Name { get; set; }
}

public class AiSearchTrackResponseDto
{
	public int? id { get; set; }
}