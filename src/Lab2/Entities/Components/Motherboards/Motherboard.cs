using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ddrs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PciExpresses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamSlotses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SataPortses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;

public class Motherboard : IComponent<Motherboard>, IMotherboardBuilderDirector
{
    public Motherboard(Socket socket, PciExpress pciExpress, SataPorts sataPorts, Chipset chipset, Ddr possibleDdr, RamSlots ramSlots, FormFactors formFactor, Bios bios)
    {
        Socket = socket;
        PciExpress = pciExpress;
        SataPorts = sataPorts;
        Chipset = chipset;
        PossibleDdr = possibleDdr;
        RamSlots = ramSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public Socket Socket { get; }
    public PciExpress PciExpress { get; }
    public SataPorts SataPorts { get; }
    public Chipset Chipset { get; }
    public Ddr PossibleDdr { get; }
    public RamSlots RamSlots { get; }
    public FormFactors FormFactor { get; }
    public Bios Bios { get; }

    public MotherboardBuilder Direct(MotherboardBuilder builder)
    {
        builder.AddSocket(Socket);
        builder.AddPciExpress(PciExpress);
        builder.AddSataPorts(SataPorts);
        builder.AddChipset(Chipset);
        builder.AddDdr(PossibleDdr);
        builder.AddRamSlots(RamSlots);
        builder.AddFormFactors(FormFactor);
        builder.AddBios(Bios);

        return builder;
    }

    public Motherboard Clone()
    {
        return new Motherboard(Socket, PciExpress, SataPorts, Chipset, PossibleDdr, RamSlots, FormFactor, Bios);
    }
}