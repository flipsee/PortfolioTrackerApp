using Common.Contracts.MarketData;
using Common.Contracts.Repo;
using Common.Models;

namespace Infrastructure.Repo
{
    public class DBInit
    {
        readonly string dbName;
        private readonly IMarketDataProvider marketProvider;
        private readonly ITickerRepo tickerRepo;

        public DBInit(IMarketDataProvider marketProvider, 
            ITickerRepo tickerRepo,
            IBaseRepo<Portfolio> portfolioRepo,
            IBaseRepo<Trade> tradeRepo)
        {
            this.tickerRepo = tickerRepo;
        }

        private void xmlDBInit()
        { 
            ///1. Ticker
            ///
        }


        private void sqliteDBInit()
        {
            //this.dbName = Utils.GetConnectionString("DefaultConnection");

            //using (var conn = new SQLiteConnection(dbName))
            //{
            //    conn.Open();
            //    using (var cmd = new SQLiteCommand(conn))
            //    {
            //        cmd.CommandText = "DROP TABLE IF EXISTS Ticker";
            //        cmd.ExecuteNonQuery();

            //        cmd.CommandText = @"CREATE TABLE Ticker(
            //                            Id int INTEGER PRIMARY KEY AUTOINCREMENT,
            //                            AddDateTime_UTC datetime DEFAULT (datetime('now')),
            //                            AddBy VARCHAR(50),
            //                            ModDateTime_UTC datetime DEFAULT (datetime('now')),
            //                            ModBy VARCHAR(50),
            //                            Disabled BOOLEAN NOT NULL CHECK (mycolumn IN (0, 1)) DEFAULT 0,
            //                            Symbol	VARCHAR(50) NOT NULL,
            //                            Name	VARCHAR(100) NOT NULL,
            //                            Exchange VARCHAR(100) NOT NULL,
            //                            AssetType VARCHAR(100) NOT NULL,
            //                            Status VARCHAR(100) NOT NULL,
            //                            IPODate date,
            //                            DelistingDate date
            //                            );";
            //        cmd.ExecuteNonQuery();
            //    }
            //    conn.Close();
            //}
        }
    }
}
