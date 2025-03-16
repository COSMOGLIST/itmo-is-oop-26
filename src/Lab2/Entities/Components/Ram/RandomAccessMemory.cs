using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ddrs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.JedecStandarts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.XmpProfiles;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ram;

public class RandomAccessMemory : IComponent<RandomAccessMemory>, IRamBuilderDirector
{
    public RandomAccessMemory(int memoryVolume, FormFactors formFactor, int powerConsumption, Ddr ddr, JedecStandard jedecStandard, XmpProfile? xmpProfile)
    {
        MemoryVolume = memoryVolume;
        FormFactor = formFactor;
        PowerConsumption = powerConsumption;
        Ddr = ddr;
        JedecStandard = jedecStandard;
        XmpProfile = xmpProfile;
    }

    public int MemoryVolume { get; }
    public FormFactors FormFactor { get; }
    public int PowerConsumption { get; }
    public Ddr Ddr { get; }
    public JedecStandard JedecStandard { get; }
    public XmpProfile? XmpProfile { get; }

    public RamBuilder Direct(RamBuilder builder)
    {
        builder.AddMemoryVolume(MemoryVolume);
        builder.AddFormFactor(FormFactor);
        builder.AddPowerConsumption(PowerConsumption);
        builder.AddDdr(Ddr);
        builder.AddJedecStandard(JedecStandard);
        if (XmpProfile is not null)
        {
            builder.AddXmpProfile(XmpProfile);
        }

        return builder;
    }

    public RandomAccessMemory Clone()
    {
        return new RandomAccessMemory(MemoryVolume, FormFactor, PowerConsumption, Ddr, JedecStandard, XmpProfile);
    }
}