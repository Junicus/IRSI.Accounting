using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Data.DataSets;
using IRSI.Accounting.Data.DataSets.GLDataSetTableAdapters;
using IRSI.Accounting.Data.Properties;
using NLog;

namespace IRSI.Accounting.Data.Repositories
{
  public class GLRepository : IGLRepository, IDisposable
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	private const string _batchid = "1";
	private GLDataSet _context;
	private TableAdapterManager _tam;

	public GLRepository()
	{
	  log.Debug("Creating GLDataSet");
	  _context = new GLDataSet();

	  log.Debug("Creating TableAdapterManager");
	  _tam = new TableAdapterManager();
	  _tam.Journal_HeadersTableAdapter = new Journal_HeadersTableAdapter();
	  _tam.Journal_DetailsTableAdapter = new Journal_DetailsTableAdapter();

	  var connString = Settings.Default.GLConnectionString;
	  log.Debug(string.Format("Connection String: {0}", connString));
	  _tam.Journal_DetailsTableAdapter.Connection = new OleDbConnection(connString);
	  _tam.Journal_HeadersTableAdapter.Connection = new OleDbConnection(connString);
	}

	public int AddNewDetail(string journalEntry, string accountId, double transactionAmount, string entryDescription)
	{
	  log.Debug("Add new detail");

	  var transactionEntry = _context.Journal_Details.Count(je => je.JOURNALID == journalEntry) + 1;
	  var row = _context.Journal_Details.NewJournal_DetailsRow();
	  row.BATCHNBR = _batchid;
	  row.JOURNALID = journalEntry;
	  row.TRANSNBR = transactionEntry.ToString();
	  row.ACCTID = accountId;
	  row.TRANSAMT = transactionAmount;
	  row.TRANSDESC = entryDescription;
	  _context.Journal_Details.Rows.Add(row);

	  return transactionEntry;
	}

	public int AddNewHeader(string sourceLedger, string sourceType, string journalDescription, double journalDebit, double journalCredit, DateTime entryDate)
	{
	  log.Debug("Add new header");

	  var batchEntry = _context.Journal_Headers.Count() + 1;
	  var row = _context.Journal_Headers.NewJournal_HeadersRow();
	  row.BATCHID = _batchid;
	  row.BTCHENTRY = batchEntry.ToString();
	  row.JRNLDESC = journalDescription;
	  row.JRNLCR = journalCredit;
	  row.JRNLDR = journalDebit;
	  row.SRCELEDGER = sourceLedger;
	  row.SRCETYPE = sourceType;
	  row.DATEENTRY = entryDate;
	  _context.Journal_Headers.Rows.Add(row);

	  return batchEntry;
	}

	public void ClearDetails()
	{
	  log.Debug("Clear Detail Table");
	  try
	  {
		_tam.Journal_DetailsTableAdapter.DeleteQuery();
	  }
	  catch (Exception e)
	  {
		log.Error(e, "Exception on ClearDetails");
		throw e;
	  }
	}

	public void ClearHeaders()
	{
	  log.Debug("Clear Header Table");
	  try
	  {
		_tam.Journal_HeadersTableAdapter.DeleteQuery();
	  }
	  catch (Exception e)
	  {
		log.Error(e, "Exception on ClearHeaders");
		throw e;
	  }
	}

	public void GetData()
	{
	  log.Debug("Getting Current Data");
	  try
	  {
		_tam.Journal_HeadersTableAdapter.Fill(_context.Journal_Headers);
		_tam.Journal_DetailsTableAdapter.Fill(_context.Journal_Details);
	  }
	  catch (Exception e)
	  {
		log.Error(e, "Exception on GetData");
		throw e;
	  }
	}

	public void SaveChanges()
	{
	  log.Debug("Saving Changes");
	  try
	  {
		_tam.UpdateAll(_context);
	  }
	  catch (Exception e)
	  {
		log.Error(e, "Exception on SaveChanges");
		throw e;
	  }
	}

	public void Dispose()
	{
	  Dispose(true);
	  GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	  if (disposing)
	  {
		if (_context != null)
		{
		  _context.Dispose();
		  _context = null;
		}

		if (_tam != null)
		{
		  _tam.Dispose();
		  _tam = null;
		}
	  }
	}
  }
}
