using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCoolings;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoreProcessors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ddrs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GraphicCards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.IntegratedGraphicsProcessors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.JedecStandarts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PciExpresses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerSupplyUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamSlotses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SataPortses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiModiles;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.XmpProfiles;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

[SuppressMessage("Test", "CA1707", Justification = "Test method naming convention")]
public class Test
{
    private ComponentRepository<Socket> _socketRepository;
    private ComponentRepository<SataPorts> _sataRepository;
    private ComponentRepository<PciExpress> _pciExpressRepository;
    private ComponentRepository<ISolidStateDrive> _ssdRepository;
    private ComponentRepository<XmpProfile> _xmpRepository;
    private ComponentRepository<WiFiAdapter> _wiFiAdapterRepository;
    private ComponentRepository<RamSlots> _ramSlotsRepository;
    private ComponentRepository<PowerSupplyUnit> _powerSupplyUnitRepository;
    private ComponentRepository<JedecStandard> _jedecRepository;
    private ComponentRepository<IntegratedWiFiModule> _integratedWiFiModuleRepository;
    private ComponentRepository<IntegratedGraphicsProcessor> _integratedGraphicsProcessorRepository;
    private ComponentRepository<HardDiskDrive> _hddRepository;
    private ComponentRepository<Ddr> _ddrRepository;
    private ComponentRepository<GraphicsCard> _graphicsCardRepository;
    private ComponentRepository<CoreProcessor> _coreProcessorRepository;
    private ComponentRepository<Bios> _biosRepository;
    private ComponentRepository<ComputerCooling> _computerCoolingRepository;
    private ComponentRepository<Corpus> _corpusRepository;
    private ComponentRepository<Chipset> _chipsetRepository;
    private ComponentRepository<CentralProcessingUnit> _cpuRepository;
    private ComponentRepository<RandomAccessMemory> _ramRepository;
    private ComponentRepository<Motherboard> _motherboardRepository;

    public Test()
    {
        _socketRepository = new();
        _socketRepository.Add(new Socket("LGA 1150"));
        _socketRepository.Add(new Socket("LGA 1700"));
        _socketRepository.Add(new Socket("Socket G2"));
        _sataRepository = new ComponentRepository<SataPorts>();
        _sataRepository.Add(new SataBuilder().AddVersion("ver1").AddNumberOfPorts(3).Build());
        _sataRepository.Add(new SataBuilder().AddVersion("ver2").AddNumberOfPorts(2).Build());
        _sataRepository.Add(new SataBuilder().AddVersion("ver3").AddNumberOfPorts(6).Build());
        _sataRepository.Add(new SataBuilder().AddVersion("ver4").AddNumberOfPorts(1).Build());
        _ssdRepository = new ComponentRepository<ISolidStateDrive>();
        _ssdRepository.Add(new SsdBuilder().AddPowerConsumption(25).AddMemoryVolume(30).AddMaximumWorkSpeed(30).IsSataPort("ver1").Build());
        _ssdRepository.Add(new SsdBuilder().AddPowerConsumption(30).AddMemoryVolume(15).AddMaximumWorkSpeed(60).IsPciExpressPort("ver1").Build());
        _ssdRepository.Add(new SsdBuilder().AddPowerConsumption(15).AddMemoryVolume(10).AddMaximumWorkSpeed(65).IsPciExpressPort("ver3").Build());
        _xmpRepository = new ComponentRepository<XmpProfile>();
        _xmpRepository.Add(new XmpBuilder().AddTiming("01-01-01").AddVoltage(20).AddPossibleMemoryFrequency("100").AddPossibleMemoryFrequency("200").AddPossibleMemoryFrequency("300").Build());
        _xmpRepository.Add(new XmpBuilder().AddTiming("01-01-04").AddVoltage(30).AddPossibleMemoryFrequency("200").AddPossibleMemoryFrequency("300").AddPossibleMemoryFrequency("400").Build());
        _xmpRepository.Add(new XmpBuilder().AddTiming("07-02-01").AddVoltage(25).AddPossibleMemoryFrequency("400").AddPossibleMemoryFrequency("500").Build());
        _wiFiAdapterRepository = new ComponentRepository<WiFiAdapter>();
        _wiFiAdapterRepository.Add(new WiFiAdapterBuilder().AddPowerConsumption(10).AddPciExpressVersion("ver1").HasBluetoothModule().AddWiFiVersion("802.11aq").Build());
        _wiFiAdapterRepository.Add(new WiFiAdapterBuilder().AddPowerConsumption(15).AddPciExpressVersion("ver3").AddWiFiVersion("802.11n").Build());
        _wiFiAdapterRepository.Add(new WiFiAdapterBuilder().AddPowerConsumption(20).AddPciExpressVersion("ver2").HasBluetoothModule().AddWiFiVersion("802.11aq").Build());
        _ramSlotsRepository = new ComponentRepository<RamSlots>();
        _ramSlotsRepository.Add(new RamSlots(5));
        _ramSlotsRepository.Add(new RamSlots(10));
        _ramSlotsRepository.Add(new RamSlots(20));
        _ramSlotsRepository.Add(new RamSlots(25));
        _powerSupplyUnitRepository = new ComponentRepository<PowerSupplyUnit>();
        _powerSupplyUnitRepository.Add(new PowerSupplyUnitBuilder().AddMaximumPowerConsumption(500).AddRecommendedPowerConsumption(150).Build());
        _powerSupplyUnitRepository.Add(new PowerSupplyUnitBuilder().AddMaximumPowerConsumption(600).AddRecommendedPowerConsumption(350).Build());
        _powerSupplyUnitRepository.Add(new PowerSupplyUnitBuilder().AddMaximumPowerConsumption(700).AddRecommendedPowerConsumption(500).Build());
        _pciExpressRepository = new ComponentRepository<PciExpress>();
        _pciExpressRepository.Add(new PciExpressBuilder().AddVersion("ver1").AddNumberOfPorts(5).Build());
        _pciExpressRepository.Add(new PciExpressBuilder().AddVersion("ver2").AddNumberOfPorts(10).Build());
        _pciExpressRepository.Add(new PciExpressBuilder().AddVersion("ver3").AddNumberOfPorts(16).Build());
        _pciExpressRepository.Add(new PciExpressBuilder().AddVersion("ver4").AddNumberOfPorts(20).Build());
        _jedecRepository = new ComponentRepository<JedecStandard>();
        _jedecRepository.Add(new JedecStandard(new string[] { "100", "200", "300" }));
        _jedecRepository.Add(new JedecStandard(new string[] { "200", "300", "400" }));
        _jedecRepository.Add(new JedecStandard(new string[] { "100", "200", "300", "400" }));
        _jedecRepository.Add(new JedecStandard(new string[] { "400", "500" }));
        _integratedWiFiModuleRepository = new ComponentRepository<IntegratedWiFiModule>();
        _integratedWiFiModuleRepository.Add(new IntegratedWiFiModuleBuilder().AddPowerConsumption(10).HasBluetoothModule().AddWiFiVersion("802.11aq").Build());
        _integratedWiFiModuleRepository.Add(new IntegratedWiFiModuleBuilder().AddPowerConsumption(15).AddWiFiVersion("802.11n").Build());
        _integratedWiFiModuleRepository.Add(new IntegratedWiFiModuleBuilder().AddPowerConsumption(20).HasBluetoothModule().AddWiFiVersion("802.11aq").Build());
        _integratedWiFiModuleRepository.Add(new IntegratedWiFiModuleBuilder().AddPowerConsumption(100).HasBluetoothModule().AddWiFiVersion("802.11n").Build());
        _integratedWiFiModuleRepository.Add(new IntegratedWiFiModuleBuilder().AddPowerConsumption(100).AddWiFiVersion("802.11aq").Build());
        _integratedGraphicsProcessorRepository = new ComponentRepository<IntegratedGraphicsProcessor>();
        _integratedGraphicsProcessorRepository.Add(new IntegratedGraphicsProcessor("i752"));
        _integratedGraphicsProcessorRepository.Add(new IntegratedGraphicsProcessor("Intel Graphics Technology"));
        _integratedGraphicsProcessorRepository.Add(new IntegratedGraphicsProcessor("Mirage 1"));
        _integratedGraphicsProcessorRepository.Add(new IntegratedGraphicsProcessor("Intel Extreme Graphics"));
        _hddRepository = new ComponentRepository<HardDiskDrive>();
        _hddRepository.Add(new HddBuilder().AddPowerConsumption(25).AddMemoryVolume(30).AddMaximumWorkSpeed(30).Build());
        _hddRepository.Add(new HddBuilder().AddPowerConsumption(30).AddMemoryVolume(15).AddMaximumWorkSpeed(60).Build());
        _hddRepository.Add(new HddBuilder().AddPowerConsumption(15).AddMemoryVolume(10).AddMaximumWorkSpeed(65).Build());
        _ddrRepository = new ComponentRepository<Ddr>();
        _ddrRepository.Add(new Ddr("DDR200"));
        _ddrRepository.Add(new Ddr("DDR266"));
        _ddrRepository.Add(new Ddr("DDR333"));
        _ddrRepository.Add(new Ddr("DDR400"));
        _graphicsCardRepository = new ComponentRepository<GraphicsCard>();
        _graphicsCardRepository.Add(new GraphicsCardBuilder().AddLength(10).AddWidth(10).AddPowerConsumption(100).AddAmountOfMemory(30).AddChipFrequency(20).AddPciExpressVersion("ver1").AddAmountOfOccupiedPciPorts(3).Build());
        _graphicsCardRepository.Add(new GraphicsCardBuilder().AddLength(15).AddWidth(15).AddPowerConsumption(200).AddAmountOfMemory(35).AddChipFrequency(15).AddPciExpressVersion("ver2").AddAmountOfOccupiedPciPorts(6).Build());
        _graphicsCardRepository.Add(new GraphicsCardBuilder().AddLength(25).AddWidth(25).AddPowerConsumption(150).AddAmountOfMemory(50).AddChipFrequency(25).AddPciExpressVersion("ver4").AddAmountOfOccupiedPciPorts(10).Build());
        _coreProcessorRepository = new ComponentRepository<CoreProcessor>();
        _coreProcessorRepository.Add(new CoreProcessorBuilder().AddFrequency(1).AddCoreNumber(16).Build());
        _coreProcessorRepository.Add(new CoreProcessorBuilder().AddFrequency(5).AddCoreNumber(8).Build());
        _coreProcessorRepository.Add(new CoreProcessorBuilder().AddFrequency(15).AddCoreNumber(2).Build());
        _biosRepository = new ComponentRepository<Bios>();
        _biosRepository.Add(new BiosBuilder().AddType("AMI").AddVersion("1.0").AddPossibleProcessor("CISC").AddPossibleProcessor("RISC").Build());
        _biosRepository.Add(new BiosBuilder().AddType("AMI").AddVersion("1.2").AddPossibleProcessor("CISC").AddPossibleProcessor("RISC").Build());
        _biosRepository.Add(new BiosBuilder().AddType("AMI").AddVersion("2.0").AddPossibleProcessor("CISC").AddPossibleProcessor("RISC").Build());
        _biosRepository.Add(new BiosBuilder().AddType("Phoenix").AddVersion("20.1").AddPossibleProcessor("RISC").Build());
        _biosRepository.Add(new BiosBuilder().AddType("Phoenix").AddVersion("20.5").AddPossibleProcessor("RISC").AddPossibleProcessor("CISC").Build());
        _biosRepository.Add(new BiosBuilder().AddType("Intel").AddVersion("2.1").AddPossibleProcessor("CISC").Build());
        _biosRepository.Add(new BiosBuilder().AddType("Intel").AddVersion("2.2").AddPossibleProcessor("RISC").AddPossibleProcessor("CISC").Build());
        _computerCoolingRepository = new ComponentRepository<ComputerCooling>();
        _computerCoolingRepository.Add(new ComputerCoolingBuilder().SetDiameter(10).SetMaximumTdp(30).AddPossibleSocketType("LGA 1150").AddPossibleSocketType("LGA 1700").Build());
        _computerCoolingRepository.Add(new ComputerCoolingBuilder().SetDiameter(20).SetMaximumTdp(35).AddPossibleSocketType("LGA 1700").Build());
        _computerCoolingRepository.Add(new ComputerCoolingBuilder().SetDiameter(11).SetMaximumTdp(30).AddPossibleSocketType("Socket G2").AddPossibleSocketType("LGA 1150").Build());
        _computerCoolingRepository.Add(new ComputerCoolingBuilder().SetDiameter(11).SetMaximumTdp(100).AddPossibleSocketType("Socket G2").Build());
        _corpusRepository = new ComponentRepository<Corpus>();
        _corpusRepository.Add(new CorpusBuilder()
            .AddNewFormFactor(FormFactors.MicroAtx)
            .AddNewFormFactor(FormFactors.MiniItx)
            .AddNewFormFactor(FormFactors.NanoItx)
            .AddNewFormFactor(FormFactors.StandartAtx)
            .SetMaximumComputerCoolingDiameter(15)
            .SetMaximumGraphicsCardLength(10)
            .SetMaximumGraphicsCardWidth(10)
            .Build());
        _corpusRepository.Add(new CorpusBuilder()
            .AddNewFormFactor(FormFactors.MicroAtx)
            .AddNewFormFactor(FormFactors.MiniItx)
            .AddNewFormFactor(FormFactors.NanoItx)
            .AddNewFormFactor(FormFactors.PicoItx)
            .SetMaximumComputerCoolingDiameter(20)
            .SetMaximumGraphicsCardLength(15)
            .SetMaximumGraphicsCardWidth(8)
            .Build());
        _corpusRepository.Add(new CorpusBuilder()
            .AddNewFormFactor(FormFactors.MicroAtx)
            .AddNewFormFactor(FormFactors.MiniItx)
            .AddNewFormFactor(FormFactors.NanoItx)
            .SetMaximumComputerCoolingDiameter(15)
            .SetMaximumGraphicsCardLength(20)
            .SetMaximumGraphicsCardWidth(25)
            .Build());
        _chipsetRepository = new ComponentRepository<Chipset>();
        _chipsetRepository.Add(new ChipsetBuilder()
            .HasXmpCompatibility()
            .AddPossibleMemoryFrequency("200")
            .AddPossibleMemoryFrequency("300")
            .AddPossibleMemoryFrequency("400")
            .AddiIntegratedWiFiModule(_integratedWiFiModuleRepository.GetComponentById(3))
            .Build());
        _chipsetRepository.Add(new ChipsetBuilder()
            .HasXmpCompatibility()
            .AddPossibleMemoryFrequency("200")
            .AddPossibleMemoryFrequency("300")
            .AddPossibleMemoryFrequency("400")
            .AddPossibleMemoryFrequency("500")
            .AddiIntegratedWiFiModule(_integratedWiFiModuleRepository.GetComponentById(4))
            .Build());
        _chipsetRepository.Add(new ChipsetBuilder()
            .AddPossibleMemoryFrequency("200")
            .AddPossibleMemoryFrequency("300")
            .Build());
        _cpuRepository = new ComponentRepository<CentralProcessingUnit>();
        _cpuRepository.Add(new CentralProcessingUnitBuilder()
            .AddName("CISC")
            .AddSocket(_socketRepository.GetComponentById(0))
            .AddCoreProcessor(_coreProcessorRepository.GetComponentById(1))
            .AddPowerConsumption(50)
            .AddIntegratedGraphicsProcessor(_integratedGraphicsProcessorRepository.GetComponentById(2))
            .AddPossibleMemoryFrequency("100")
            .AddPossibleMemoryFrequency("200")
            .AddPossibleMemoryFrequency("300")
            .AddThermalDesignPower(30)
            .Build());
        _cpuRepository.Add(new CentralProcessingUnitBuilder()
            .AddName("CISC")
            .AddSocket(_socketRepository.GetComponentById(1))
            .AddCoreProcessor(_coreProcessorRepository.GetComponentById(2))
            .AddPowerConsumption(50)
            .AddIntegratedGraphicsProcessor(_integratedGraphicsProcessorRepository.GetComponentById(0))
            .AddPossibleMemoryFrequency("400")
            .AddPossibleMemoryFrequency("200")
            .AddPossibleMemoryFrequency("300")
            .AddThermalDesignPower(32)
            .Build());
        _cpuRepository.Add(new CentralProcessingUnitBuilder()
            .AddName("RISC")
            .AddSocket(_socketRepository.GetComponentById(2))
            .AddCoreProcessor(_coreProcessorRepository.GetComponentById(2))
            .AddPowerConsumption(100)
            .AddPossibleMemoryFrequency("100")
            .AddPossibleMemoryFrequency("200")
            .AddPossibleMemoryFrequency("300")
            .AddPossibleMemoryFrequency("400")
            .AddPossibleMemoryFrequency("500")
            .AddThermalDesignPower(40)
            .Build());
        _ramRepository = new ComponentRepository<RandomAccessMemory>();
        _ramRepository.Add(new RamBuilder()
            .AddPowerConsumption(50)
            .AddMemoryVolume(100)
            .AddDdr(_ddrRepository.GetComponentById(1))
            .AddFormFactor(FormFactors.StandartAtx)
            .AddJedecStandard(_jedecRepository.GetComponentById(2))
            .AddXmpProfile(_xmpRepository.GetComponentById(2))
            .Build());
        _ramRepository.Add(new RamBuilder()
                .AddPowerConsumption(60)
                .AddMemoryVolume(150)
                .AddDdr(_ddrRepository.GetComponentById(2))
                .AddFormFactor(FormFactors.MiniItx)
                .AddJedecStandard(_jedecRepository.GetComponentById(1))
                .AddXmpProfile(_xmpRepository.GetComponentById(1))
                .Build());
        _ramRepository.Add(new RamBuilder()
                    .AddPowerConsumption(25)
                    .AddMemoryVolume(50)
                    .AddDdr(_ddrRepository.GetComponentById(2))
                    .AddFormFactor(FormFactors.MicroAtx)
                    .AddJedecStandard(_jedecRepository.GetComponentById(3))
                    .Build());
        _motherboardRepository = new ComponentRepository<Motherboard>();
        _motherboardRepository.Add(new MotherboardBuilder()
            .AddSocket(_socketRepository.GetComponentById(1))
            .AddBios(_biosRepository.GetComponentById(1))
            .AddChipset(_chipsetRepository.GetComponentById(1))
            .AddFormFactors(FormFactors.PicoItx)
            .AddDdr(_ddrRepository.GetComponentById(2))
            .AddPciExpress(_pciExpressRepository.GetComponentById(1))
            .AddRamSlots(_ramSlotsRepository.GetComponentById(2))
            .AddSataPorts(_sataRepository.GetComponentById(1))
            .Build());
        _motherboardRepository.Add(new MotherboardBuilder()
            .AddSocket(_socketRepository.GetComponentById(2))
            .AddBios(_biosRepository.GetComponentById(3))
            .AddChipset(_chipsetRepository.GetComponentById(1))
            .AddFormFactors(FormFactors.MiniItx)
            .AddDdr(_ddrRepository.GetComponentById(2))
            .AddPciExpress(_pciExpressRepository.GetComponentById(0))
            .AddRamSlots(_ramSlotsRepository.GetComponentById(1))
            .AddSataPorts(_sataRepository.GetComponentById(1))
            .Build());
    }

    [Fact]
    public void Сomponents_Should_Fit_Together()
    {
        ComputerBuildResult computerBuildResult = new ComputerBuilder(new Validator())
            .AddMotherboard(_motherboardRepository.GetComponentById(1))
            .AddRandomAccessMemory(_ramRepository.GetComponentById(1))
            .AddCentralProcessingUnit(_cpuRepository.GetComponentById(2))
            .AddComputerCooling(_computerCoolingRepository.GetComponentById(3))
            .AddGraphicsCard(_graphicsCardRepository.GetComponentById(0))
            .AddSolidStateDrive(_ssdRepository.GetComponentById(1))
            .AddHardDiskDrive(_hddRepository.GetComponentById(1))
            .AddCorpus(_corpusRepository.GetComponentById(2))
            .AddPowerSupplyUnit(_powerSupplyUnitRepository.GetComponentById(2))
            .Build();
        Assert.Equal(typeof(ComputerBuildResult.SuccessfulBuild), computerBuildResult.GetType());
    }

    [Fact]
    public void Сomponents_Should_Fit_Together_And_Warning_About_Power_Consumption()
    {
        ComputerBuildResult computerBuildResult = new ComputerBuilder(new Validator())
            .AddMotherboard(_motherboardRepository.GetComponentById(1))
            .AddRandomAccessMemory(_ramRepository.GetComponentById(1))
            .AddCentralProcessingUnit(_cpuRepository.GetComponentById(2))
            .AddComputerCooling(_computerCoolingRepository.GetComponentById(3))
            .AddGraphicsCard(_graphicsCardRepository.GetComponentById(0))
            .AddSolidStateDrive(_ssdRepository.GetComponentById(1))
            .AddHardDiskDrive(_hddRepository.GetComponentById(1))
            .AddCorpus(_corpusRepository.GetComponentById(2))
            .AddPowerSupplyUnit(_powerSupplyUnitRepository.GetComponentById(1))
            .Build();
        Assert.Equal(typeof(ComputerBuildResult.SuccessfulBuildWithWarning), computerBuildResult.GetType());
        if (computerBuildResult is ComputerBuildResult.SuccessfulBuildWithWarning successWithWarning)
        {
            var warning = new List<string> { "Power consumption is more than recommended" };
            Assert.Equal(successWithWarning.Warnings.ToList(), warning);
        }
    }

    [Fact]
    public void Сomponents_Should_Fit_Together_And_Warning_About_Cooling()
    {
        ComputerBuildResult computerBuildResult = new ComputerBuilder(new Validator())
            .AddMotherboard(_motherboardRepository.GetComponentById(1))
            .AddRandomAccessMemory(_ramRepository.GetComponentById(1))
            .AddCentralProcessingUnit(_cpuRepository.GetComponentById(2))
            .AddComputerCooling(_computerCoolingRepository.GetComponentById(2))
            .AddGraphicsCard(_graphicsCardRepository.GetComponentById(0))
            .AddSolidStateDrive(_ssdRepository.GetComponentById(1))
            .AddHardDiskDrive(_hddRepository.GetComponentById(1))
            .AddCorpus(_corpusRepository.GetComponentById(2))
            .AddPowerSupplyUnit(_powerSupplyUnitRepository.GetComponentById(2))
            .Build();

        Assert.Equal(typeof(ComputerBuildResult.SuccessfulBuildWithWarning), computerBuildResult.GetType());
        if (computerBuildResult is ComputerBuildResult.SuccessfulBuildWithWarning successWithWarning)
        {
            var warning = new List<string> { "Disclaimer of warranty obligations: not enough cooling" };
            Assert.Equal(successWithWarning.Warnings.ToList(), warning);
        }
    }

    [Fact]
    public void Сomponents_Should_Not_Fit_Together_Due_To_The_Network_Equipment_Conflict()
    {
        ComputerBuildResult computerBuildResult = new ComputerBuilder(new Validator())
            .AddMotherboard(_motherboardRepository.GetComponentById(1))
            .AddRandomAccessMemory(_ramRepository.GetComponentById(1))
            .AddCentralProcessingUnit(_cpuRepository.GetComponentById(2))
            .AddComputerCooling(_computerCoolingRepository.GetComponentById(3))
            .AddGraphicsCard(_graphicsCardRepository.GetComponentById(0))
            .AddSolidStateDrive(_ssdRepository.GetComponentById(1))
            .AddHardDiskDrive(_hddRepository.GetComponentById(1))
            .AddCorpus(_corpusRepository.GetComponentById(2))
            .AddPowerSupplyUnit(_powerSupplyUnitRepository.GetComponentById(2))
            .AddWiFiAdapter(_wiFiAdapterRepository.GetComponentById(0))
            .Build();

        Assert.Equal(typeof(ComputerBuildResult.NotSuccessfulBuild), computerBuildResult.GetType());
        if (computerBuildResult is ComputerBuildResult.NotSuccessfulBuild notSuccess)
        {
            var warning = new List<string> { "ERROR! Wi-Fi adapter is not comparable with motherboard: network equipment conflict" };
            Assert.Equal(notSuccess.Errors.ToList(), warning);
        }
    }

    [Fact]
    public void Сomponents_Should_Not_Fit_Together_Due_To_The_Network_Equipment()
    {
        ComputerBuildResult computerBuildResult = new ComputerBuilder(new Validator())
            .AddMotherboard(_motherboardRepository.GetComponentById(1))
            .AddRandomAccessMemory(_ramRepository.GetComponentById(1))
            .AddCentralProcessingUnit(_cpuRepository.GetComponentById(2))
            .AddComputerCooling(_computerCoolingRepository.GetComponentById(3))
            .AddGraphicsCard(_graphicsCardRepository.GetComponentById(2))
            .AddSolidStateDrive(_ssdRepository.GetComponentById(1))
            .AddHardDiskDrive(_hddRepository.GetComponentById(1))
            .AddCorpus(_corpusRepository.GetComponentById(0))
            .AddPowerSupplyUnit(_powerSupplyUnitRepository.GetComponentById(2))
            .Build();

        Assert.Equal(typeof(ComputerBuildResult.NotSuccessfulBuild), computerBuildResult.GetType());
        if (computerBuildResult is ComputerBuildResult.NotSuccessfulBuild notSuccess)
        {
            var warning = new List<string>
            {
                "ERROR! Too big graphics card for corpus",
                "ERROR! Graphics card is not comparable with motherboard: inappropriate PCI-Express version",
                "ERROR! Too many components for PCI-Express ports",
            };
            Assert.Equal(notSuccess.Errors.ToList(), warning);
        }
    }
}