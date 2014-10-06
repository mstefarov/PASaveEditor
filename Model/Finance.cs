using System;

namespace PASaveEditor.Model {
    class Finance : Node {
        public int Balance;
        public int LastDay;
        public int LastHour;
        public int BankLoan;
        public double BankCreditRating;
        public int Ownership;

        public override void ReadKey(string key, string value) {
            switch (key) {
                case "Balance":
                    Balance = (int)Math.Round(Double.Parse(value));
                    break;
                case "LastDay":
                    LastDay = Int32.Parse(value);
                    break;
                case "LastHour":
                    LastHour = Int32.Parse(value);
                    break;
                case "BankLoan":
                    BankLoan = (int)Math.Round(Double.Parse(value));
                    break;
                case "BankCreditRating":
                    BankCreditRating = Double.Parse(value);
                    break;
                case "Ownership":
                    Ownership = Int32.Parse(value);
                    break;
                default:
                    base.ReadKey(key, value);
                    break;
            }
        }
    }
}
