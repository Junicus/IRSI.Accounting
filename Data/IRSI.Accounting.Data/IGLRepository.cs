using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Data
{
  public interface IGLRepository
  {
	void GetData();
	void ClearHeaders();
	void ClearDetails();
	int AddNewHeader(string sourceLedger, string sourceType, string journalDescription, double journalDebit, double journalCredit, DateTime entryDate);
	int AddNewDetail(string journalEntry, string accountId, double transactionAmount, string entryDescription);
	void SaveChanges();
  }
}
