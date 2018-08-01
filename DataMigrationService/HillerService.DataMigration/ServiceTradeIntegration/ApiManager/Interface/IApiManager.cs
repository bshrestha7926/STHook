using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts;

namespace HillerService.DataMigration.ServiceTradeIntegration
{
    public interface IApiManager
    {
        bool AddCompany(Company company);
        bool UpdateCompany(Company company);
        string GetCompanyExternalId(int companyid);
        bool AddLocation(Location location);
        bool UpdateLocation(Location location);
        string GetLocationExternalId(int id);
        List<FSTINV> GetInvoices();
        List<Tag> GetTags(string _invoiceId);
        FSTINV GetInvoice(string invoiceID);
        List<string> GetSalesNumber(FSTINV inv);
        CommentsList GetInvoiceComments(FSTINV inv);
        bool UpdateInvoice(Invoice invoice);
        bool SetInvoiceToPending(string invoice);
        bool SetInvoiceToProcessed(FSTINV invoice);
        User[] GetTechnician(int jobNumber);
        Office GetServicingOffice(int locationId);
        bool GetFPMAR(int jobNumber);
        bool CheckServiceLines(int? svcLineId);
        bool IsRecurringService(FSTINV _invoice, Item _invItem);
    }
}
