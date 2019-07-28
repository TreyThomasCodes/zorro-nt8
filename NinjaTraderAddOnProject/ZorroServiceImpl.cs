using NinjaTrader.Cbi;
using NinjaTrader.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT8ZorroBridge
{
    public class ZorroServiceImpl : IZorroService
    {
        Account account;

        public string[] GetAccountList()
        {
            return Account.All.Select(x => x.DisplayName).ToArray();
        }

        public string SayHello(string name)
        {
            return string.Format("Hello, {0}.", name);
        }

        public StatusDTO Status()
        {
            if (account is null) throw new InvalidOperationException("There is no valid account yet, call Verify first.");

            int status = 1;
            if (account.ConnectionStatus == ConnectionStatus.ConnectionLost || account.ConnectionStatus == ConnectionStatus.Disconnected) status = 0;

            return new StatusDTO
            {
                Status = status,
                Time = account.FcmDate.ToUniversalTime().ToOADate()
            };
        }

        public bool Verify(string accountName, string accountType)
        {
            if (accountType != "Real" && accountType != "Demo") throw new ArgumentException("Connection type must be either \"Real\" or \"Demo\"");

            var account = Account.All.Where(x => x.DisplayName == accountName).SingleOrDefault();

            if (account is null) return false;
            else if (account.ConnectionStatus != ConnectionStatus.Connected) return false;
            else if (accountType == "Real" && account.Connection.Options.Mode == Mode.Simulation) return false;
            else if (accountType == "Demo" && account.Connection.Options.Mode == Mode.Live) return false;

            this.account = account;

            return true;
        }
    }
}
