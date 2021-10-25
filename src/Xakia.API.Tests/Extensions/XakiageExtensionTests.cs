using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xakia.API.Client.Helpers;
using Xakia.API.Client.Services.Admin.Contracts;
using Xakia.API.Client.Services.Matters.Contracts;
using Xunit;

namespace Xakia.API.Tests.Extensions
{
    public class XakiageExtensionTests
    {
        [Fact]
        public void ValidateLegalRequestTypeSet_ThrowsArgumentNull()
        {
            var legalRequestType = new XakiageRequestTypeDetailResponse();
            var legalRequest = new XakiageLegalRequest();

            Assert.Throws<ArgumentException>(() => legalRequest.Validate());
        }


        [Fact]
        public void ValidateLegalRequestTypeSet()
        {
            var legalRequestType = new XakiageRequestTypeDetailResponse();
            var legalRequest = new XakiageLegalRequest(legalRequestType);
            var sut = legalRequest.Validate();
            Assert.Contains(sut, e => e.Property == nameof(XakiageLegalRequest.ContactName));
            Assert.Contains(sut, e => e.Property == nameof(XakiageLegalRequest.ContactEmail));
            Assert.Contains(sut, e => e.Property == nameof(XakiageLegalRequest.Name));
            Assert.Contains(sut, e => e.Property == nameof(XakiageLegalRequest.RequestName));
            Assert.Contains(sut, e => e.Property == nameof(XakiageLegalRequest.Required));
            Assert.Contains(sut, e => e.Property == nameof(XakiageLegalRequest.Required));

        }


        [Fact]
        public void ValidateLegalRequestRequiredFields()
        {
            var legalRequestType = new XakiageRequestTypeDetailResponse { XakiageRequestTypeId = Guid.NewGuid() };
            var legalRequest = GetXakiageLegal(legalRequestType);

            var sut = legalRequest.Validate();
            Assert.False(sut.Any());
        }



        [Fact]
        public void ValidateLegalRequestDocuments()
        {
            var legalRequestType = new XakiageRequestTypeDetailResponse { XakiageRequestTypeId = Guid.NewGuid() };
            legalRequestType.DocumentFields.Add(new XakiageDocumentResponse {  IsActive = true, Mandatory = true ,  TypeId = DocumentFieldType.Links });
            var legalRequest = GetXakiageLegal(legalRequestType);
            legalRequest.DocumentLinks.Add("https://testlink.com");

            var sut = legalRequest.Validate();
            Assert.False(sut.Any());
        }


        [Fact]
        public void ValidateLegalRequestDocuments_Invalid()
        {
            var legalRequestType = new XakiageRequestTypeDetailResponse { XakiageRequestTypeId = Guid.NewGuid() };
            legalRequestType.DocumentFields.Add(new XakiageDocumentResponse { IsActive = true, Mandatory = true, TypeId = DocumentFieldType.Links });
            var legalRequest = GetXakiageLegal(legalRequestType);

            var sut = legalRequest.Validate();
            Assert.Contains(sut, e => e.Property == nameof(XakiageLegalRequest.DocumentLinks));
        }



        [Fact]
        public void ValidateLegalRequestOptionalRequiredFields()
        {
            var legalRequestType = new XakiageRequestTypeDetailResponse { XakiageRequestTypeId = Guid.NewGuid() };
            legalRequestType.Fields.Add(new FieldResponse { Display = true, Mandatory = true, Name = "Category" });
            legalRequestType.Fields.Add(new FieldResponse { Display = true, Mandatory = true, Name = "DateRequired" });
            var legalRequest = GetXakiageLegal(legalRequestType);
            legalRequest.CategoryId = Guid.NewGuid();

            var sut = legalRequest.Validate();
            Assert.False(sut.Any());
        }


        [Fact]
        public void ValidateLegalRequestOptionalRequiredFields_Invalid()
        {
            var legalRequestType = new XakiageRequestTypeDetailResponse { XakiageRequestTypeId = Guid.NewGuid() };
            legalRequestType.Fields.Add(new FieldResponse { Display = true, Mandatory = true, Name = nameof(XakiageLegalRequest.CategoryId) });
            var legalRequest = GetXakiageLegal(legalRequestType);
            legalRequest.CategoryId = Guid.Empty;

            var sut = legalRequest.Validate();
            Assert.Contains(sut, e => e.Property == nameof(XakiageLegalRequest.CategoryId));
        }

        private XakiageLegalRequest GetXakiageLegal(XakiageRequestTypeDetailResponse legalRequestType)
        {
            var legalRequest = new XakiageLegalRequest(legalRequestType);
            legalRequest.RequestName = "Request name";
            legalRequest.Name = "Name";
            legalRequest.ContactName = "Contact name";
            legalRequest.Required = NodaTime.LocalDate.FromDateTime(DateTime.Now);
            legalRequest.ContactEmail = "Contact email";
            return legalRequest;
        }
    }
}
