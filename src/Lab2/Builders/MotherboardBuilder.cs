using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ddrs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PciExpresses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamSlotses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SataPortses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class MotherboardBuilder
{
    private Socket? _socket;
    private PciExpress? _pciExpress;
    private SataPorts? _sataPorts;
    private Chipset? _chipset;
    private Ddr? _possibleDdr;
    private RamSlots? _ramSlots;
    private FormFactors? _formFactor;
    private Bios? _bios;

    public MotherboardBuilder AddSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public MotherboardBuilder AddPciExpress(PciExpress pciExpress)
    {
        _pciExpress = pciExpress;
        return this;
    }

    public MotherboardBuilder AddSataPorts(SataPorts sataPorts)
    {
        _sataPorts = sataPorts;
        return this;
    }

    public MotherboardBuilder AddChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder AddDdr(Ddr possibleDdr)
    {
        _possibleDdr = possibleDdr;
        return this;
    }

    public MotherboardBuilder AddRamSlots(RamSlots ramSlots)
    {
        _ramSlots = ramSlots;
        return this;
    }

    public MotherboardBuilder AddFormFactors(FormFactors formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder AddBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _pciExpress ?? throw new ArgumentNullException(nameof(_pciExpress)),
            _sataPorts ?? throw new ArgumentNullException(nameof(_sataPorts)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _possibleDdr ?? throw new ArgumentNullException(nameof(_possibleDdr)),
            _ramSlots ?? throw new ArgumentNullException(nameof(_ramSlots)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)));
    }
}