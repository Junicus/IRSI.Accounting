using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common.Models;

namespace IRSI.Accounting.Data.Repositories
{
  public class InMemoryStoresRepository : IStoresRepository
  {
	private List<Concept> _concepts = new List<Concept>();
	private List<Store> _stores = new List<Store>();

	public InMemoryStoresRepository()
	{
	  _concepts.Add(new Concept { Id = 1, Name = "Chili's Grill & Bar", Number = "100" });
	  _concepts.Add(new Concept { Id = 2, Name = "Romano's Macaroni Grill", Number = "200" });
	  _concepts.Add(new Concept { Id = 3, Name = "On The Border", Number = "300" });
	  _concepts.Add(new Concept { Id = 4, Name = "PF Chang's China Bistro", Number = "400" });

	  _stores.Add(new Store { Id = 1, Name = "101 Chilis Condado", Concept = _concepts[0], Number = "101", InsightName = "01 Chilis Condado" });
	  _stores.Add(new Store { Id = 2, Name = "102 Chilis Hatillo", Concept = _concepts[0], Number = "102", InsightName = "02 Chilis Hatillo" });
	  _stores.Add(new Store { Id = 3, Name = "103 Chilis Plaza las Americas", Concept = _concepts[0], Number = "103", InsightName = "03 Chilis Plaza Americas" });
	  _stores.Add(new Store { Id = 4, Name = "104 Chilis Humacao", Concept = _concepts[0], Number = "104", InsightName = "04 Chilis Humacao" });
	  _stores.Add(new Store { Id = 5, Name = "105 Chilis San Patricio", Concept = _concepts[0], Number = "105", InsightName = "05 Chilis San Patricio" });
	  _stores.Add(new Store { Id = 6, Name = "106 Chilis Colobos", Concept = _concepts[0], Number = "106", InsightName = "06 Chilis Colobos" });
	  _stores.Add(new Store { Id = 7, Name = "107 Chilis Mayaguez", Concept = _concepts[0], Number = "107", InsightName = "07 Chilis Mayaguez" });
	  _stores.Add(new Store { Id = 8, Name = "108 Chilis Plaza del Sol", Concept = _concepts[0], Number = "108", InsightName = "08 Chilis Bayamon" });
	  _stores.Add(new Store { Id = 9, Name = "109 Chilis Plaza Carolina", Concept = _concepts[0], Number = "109", InsightName = "09 Chilis Plaza Carolina" });
	  _stores.Add(new Store { Id = 10, Name = "110 Chilis Ponce", Concept = _concepts[0], Number = "110", InsightName = "10 Chilis Ponce" });
	  _stores.Add(new Store { Id = 11, Name = "111 Chilis Caguas", Concept = _concepts[0], Number = "111", InsightName = "11 Chilis Caguas" });
	  _stores.Add(new Store { Id = 12, Name = "112 Chilis Cayey", Concept = _concepts[0], Number = "112", InsightName = "12 Chilis Cayey" });
	  _stores.Add(new Store { Id = 13, Name = "114 Chilis Rexville", Concept = _concepts[0], Number = "114", InsightName = "14 Chilis Rexville" });
	  _stores.Add(new Store { Id = 14, Name = "115 Chilis Montehiedra", Concept = _concepts[0], Number = "115", InsightName = "15 Chilis Montehiedra" });
	  _stores.Add(new Store { Id = 15, Name = "116 Chilis Barceloneta", Concept = _concepts[0], Number = "116", InsightName = "16 Chilis Barceloneta" });
	  _stores.Add(new Store { Id = 16, Name = "117 Chilis Isla Verde", Concept = _concepts[0], Number = "117", InsightName = "17 Chilis Isla Verde" });
	  _stores.Add(new Store { Id = 17, Name = "118 Chilis Dorado", Concept = _concepts[0], Number = "118", InsightName = "18 Chilis Dorado" });
	  _stores.Add(new Store { Id = 18, Name = "119 Chilis Trujillo Alto", Concept = _concepts[0], Number = "119", InsightName = "19 Chilis Trujillo Alto" });
	  _stores.Add(new Store { Id = 19, Name = "120 Chilis Rio Hondo", Concept = _concepts[0], Number = "120", InsightName = "20 Chilis Rio Hondo" });
	  _stores.Add(new Store { Id = 20, Name = "121 Chilis Caguas Centro", Concept = _concepts[0], Number = "121", InsightName = "21 Chilis Caguas 2" });
	  _stores.Add(new Store { Id = 21, Name = "122 Chilis Aguadilla", Concept = _concepts[0], Number = "122", InsightName = "22 Chilis Aguadilla" });
	  _stores.Add(new Store { Id = 22, Name = "123 Chilis Escorial", Concept = _concepts[0], Number = "123", InsightName = "23 Chilis Escorial" });
	  _stores.Add(new Store { Id = 35, Name = "124 Chilis Presby", Concept = _concepts[0], Number = "124", InsightName = "24 Chilis Presby" });
	  _stores.Add(new Store { Id = 23, Name = "201 Romanos San Patricio", Concept = _concepts[1], Number = "201", InsightName = "01 Macaroni San Patricio" });
	  _stores.Add(new Store { Id = 24, Name = "202 Romanos Caguas", Concept = _concepts[1], Number = "202", InsightName = "02 Macaroni Caguas" });
	  _stores.Add(new Store { Id = 25, Name = "203 Romanos Plaza las Americas", Concept = _concepts[1], Number = "203", InsightName = "03 Macaroni Plaza" });
	  _stores.Add(new Store { Id = 26, Name = "204 Romanos Montehiedra", Concept = _concepts[1], Number = "204", InsightName = "04 Macaroni Montehiedra" });
	  _stores.Add(new Store { Id = 27, Name = "205 Romanos Ponce", Concept = _concepts[1], Number = "205", InsightName = "05 Macaroni Ponce" });
	  _stores.Add(new Store { Id = 28, Name = "206 Romanos Plaza del Sol", Concept = _concepts[1], Number = "206", InsightName = "06 Romanos Plaza del Sol" });
	  _stores.Add(new Store { Id = 29, Name = "207 Romanos Mayaguez", Concept = _concepts[1], Number = "207", InsightName = "07 Romanos Mayaguez" });
	  _stores.Add(new Store { Id = 30, Name = "301 OTB Guaynabo", Concept = _concepts[2], Number = "301", InsightName = "01 OTB Plaza Guaynabo" });
	  _stores.Add(new Store { Id = 31, Name = "302 OTB Escorial", Concept = _concepts[2], Number = "302", InsightName = "02 OTB Plaza Escorial" });
	  _stores.Add(new Store { Id = 32, Name = "401 PFC Plaza las Americas", Concept = _concepts[3], Number = "401", InsightName = "01 PFC Plaza Las Americas" });
	  _stores.Add(new Store { Id = 33, Name = "402 PFC Ponce", Concept = _concepts[3], Number = "402", InsightName = "02 PFC Ponce" });
	  _stores.Add(new Store { Id = 34, Name = "403 PFC Caguas", Concept = _concepts[3], Number = "403", InsightName = "03 PFC Caguas" });
	}

	public Store GetStoreByInsightName(string insightName)
	{
	  return _stores.SingleOrDefault(s => s.InsightName == insightName);
	}

	public IEnumerable<Store> GetStores()
	{
	  return _stores;
	}
  }
}
