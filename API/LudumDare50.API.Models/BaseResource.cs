using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace LudumDare50.API.Models;

public class BaseResource
{
    [BsonId] public string Id { get; set; }

    public string OwnerId { get; set; }

    [ConcurrencyCheck] public int Version { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}