using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ddrs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.JedecStandarts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.XmpProfiles;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class RamBuilder
{
    private int? _memoryVolume;
    private FormFactors? _formFactor;
    private int? _powerConsumption;
    private Ddr? _ddr;
    private JedecStandard? _jedecStandard;
    private XmpProfile? _xmpProfile;

    public RamBuilder AddMemoryVolume(int memoryVolume)
    {
        _memoryVolume = memoryVolume;
        return this;
    }

    public RamBuilder AddFormFactor(FormFactors formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RamBuilder AddPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public RamBuilder AddDdr(Ddr ddr)
    {
        _ddr = ddr;
        return this;
    }

    public RamBuilder AddJedecStandard(JedecStandard jedecStandard)
    {
        _jedecStandard = jedecStandard;
        return this;
    }

    public RamBuilder AddXmpProfile(XmpProfile xmpProfile)
    {
        _xmpProfile = xmpProfile;
        return this;
    }

    public RandomAccessMemory Build()
    {
        return new RandomAccessMemory(
            _memoryVolume ?? throw new ArgumentNullException(nameof(_memoryVolume)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            _jedecStandard ?? throw new ArgumentNullException(nameof(_jedecStandard)),
            _xmpProfile);
    }
}