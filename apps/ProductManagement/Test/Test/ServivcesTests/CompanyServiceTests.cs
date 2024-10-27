using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services;
using DB;
using Moq;

namespace Test.ServivcesTests;

[TestFixture]
public class CompanyServiceTests
{
    private Mock<ICompanyDAO> _companyDaoMock;
        private Mock<IMapper> _mapperMock;
        private CompanyService _companyService;

        [SetUp]
        public void SetUp()
        {
            _companyDaoMock = new Mock<ICompanyDAO>();
            _mapperMock = new Mock<IMapper>();
            _companyService = new CompanyService(_companyDaoMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetCompanies_ReturnsMappedCompanyDTOList()
        {
            // Arrange
            var companies = new List<Company> { new Company { CompanyId = Guid.NewGuid(), Name = "Test Company" } };
            var companyDTOs = new List<CompanyDTO> { new CompanyDTO { CompanyId = companies[0].CompanyId, Name = "Test Company" } };
            _companyDaoMock.Setup(dao => dao.ReadAll()).Returns(companies);
            _mapperMock.Setup(m => m.Map<CompanyDTO>(It.IsAny<Company>())).Returns((Company source) => new CompanyDTO { CompanyId = source.CompanyId, Name = source.Name });

            // Act
            var result = await _companyService.GetCompanies();

            // Assert
            Assert.AreEqual(companyDTOs.Count, result.Count);
            Assert.AreEqual(companyDTOs[0].Name, result[0].Name);
        }

        [Test]
        public async Task GetCompanyById_ReturnsMappedCompanyDTO()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            var company = new Company { CompanyId = companyId, Name = "Test Company" };
            var companyDTO = new CompanyDTO { CompanyId = companyId, Name = "Test Company" };
            _companyDaoMock.Setup(dao => dao.Read(companyId)).Returns(company);
            _mapperMock.Setup(m => m.Map<CompanyDTO>(company)).Returns(companyDTO);

            // Act
            var result = await _companyService.GetCompanyById(companyId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(companyDTO.CompanyId, result?.CompanyId);
            Assert.AreEqual(companyDTO.Name, result?.Name);
        }

        [Test]
        public async Task CreateCompany_AddsCompanyAndReturnsMappedDTO()
        {
            // Arrange
            var companyWithoutIdDto = new CompanyWithoutIDDTO { Name = "New Company" };
            var companyId = Guid.NewGuid();
            var company = new Company { CompanyId = companyId, Name = "New Company" };
            var createdCompanyDTO = new CompanyDTO { CompanyId = companyId, Name = "New Company" };

            _mapperMock.Setup(m => m.Map<Company>(It.IsAny<(CategoryWithoutIDDTO, Guid)>())).Returns(company);
            _companyDaoMock.Setup(dao => dao.Create(company));
            _companyDaoMock.Setup(dao => dao.Read(It.IsAny<Guid>())).Returns(company);
            _mapperMock.Setup(m => m.Map<CompanyDTO>(company)).Returns(createdCompanyDTO);

            // Act
            var result = await _companyService.CreateCompany(companyWithoutIdDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(createdCompanyDTO.CompanyId, result?.CompanyId);
            Assert.AreEqual(createdCompanyDTO.Name, result?.Name);
        }

        [Test]
        public async Task UpdateCompany_UpdatesCompanyAndReturnsMappedDTO()
        {
            // Arrange
            var companyDto = new CompanyDTO { CompanyId = Guid.NewGuid(), Name = "Updated Company" };
            var company = new Company { CompanyId = companyDto.CompanyId, Name = "Updated Company" };

            _mapperMock.Setup(m => m.Map<Company>(companyDto)).Returns(company);
            _companyDaoMock.Setup(dao => dao.Update(company));
            _companyDaoMock.Setup(dao => dao.Read(companyDto.CompanyId)).Returns(company);
            _mapperMock.Setup(m => m.Map<CompanyDTO>(company)).Returns(companyDto);

            // Act
            var result = await _companyService.UpdateCompany(companyDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(companyDto.CompanyId, result?.CompanyId);
            Assert.AreEqual(companyDto.Name, result?.Name);
        }
    
}