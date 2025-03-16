using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Bioses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class BiosBuilder
{
    private string? _type;
    private string? _version;
    private List<string> _possibleProcessors = new();

    public BiosBuilder AddType(string type)
    {
        _type = type;
        return this;
    }

    public BiosBuilder AddVersion(string version)
    {
        _version = version;
        return this;
    }

    public BiosBuilder AddPossibleProcessor(string possibleProcessor)
    {
        _possibleProcessors.Add(possibleProcessor);
        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _type ?? throw new ArgumentNullException(nameof(_type)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _possibleProcessors);
    }
}