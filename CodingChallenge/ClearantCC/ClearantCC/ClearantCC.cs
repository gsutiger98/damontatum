using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearantCC
{
    [TestFixture]
    public class ClearentCC
    {
        float mcInt = 0f;
        float visaInt = 0f;
        float discInt = 0f;
        float mcInt2 = 0f;
        float visaInt2 = 0f;
        float discInt2 = 0f;

        public float calcCardInterest(string cardType, float bal)
        {
            const float interestVisa = 0.10f;
            const float interestMC = 0.05f;
            const float interestDiscover = 0.01f;

            float intForMC = 0f;
            float intForVisa = 0f;
            float intForDC = 0f;

            if (cardType == "MC") { intForMC = interestMC * bal; return intForMC; }
            else if (cardType == "Visa") { intForVisa = interestVisa * bal; return intForVisa; }
            else { intForDC = interestDiscover * bal; return intForDC; }
        }

        [Test]
        public void TestCase1()
        {
            //Add credit card information to the wallet object
            Person tc1_p1 = new Person();
            tc1_p1.wallet.card.CardDetails.Add("MC", 100);
            tc1_p1.wallet.card.CardDetails.Add("Visa", 100);
            tc1_p1.wallet.card.CardDetails.Add("Discover", 100);

            //Calculate interest for each card based on card type
            if (tc1_p1.wallet.card.CardDetails.ContainsKey("MC")) { mcInt = calcCardInterest("MC", tc1_p1.wallet.card.CardDetails["MC"]); }
            if (tc1_p1.wallet.card.CardDetails.ContainsKey("Visa")) { visaInt = calcCardInterest("Visa", tc1_p1.wallet.card.CardDetails["Visa"]); }
            if (tc1_p1.wallet.card.CardDetails.ContainsKey("Discover")) { discInt = calcCardInterest("Discover", tc1_p1.wallet.card.CardDetails["Discover"]); }

            //Calculate interest for the wallet
            tc1_p1.wallet.totalWalInt = mcInt + visaInt + discInt;

            //calculate total interest for all wallets
            tc1_p1.totalInt = tc1_p1.wallet.totalWalInt;

            //Test to make sure that the total interest for the person is correct.
            Assert.AreEqual(16.0, tc1_p1.totalInt);

            //Test to make sure the interest is correct for each card type
            Assert.AreEqual(1.0, discInt);
            Assert.AreEqual(5.0, mcInt);
            Assert.AreEqual(10.0, visaInt);
        }

        public void TestCase2()
        {
            //Create person object
            Person tc2_p1 = new Person();

            //add cards to person1's 1st wallet
            tc2_p1.wallet.card.CardDetails.Add("Visa", 100);
            tc2_p1.wallet.card.CardDetails.Add("Discover", 100);

            //add cards to person1's 1st second wallet
            tc2_p1.wallet2.card.CardDetails.Add("MC", 100);

            //Calculate interest for each card, for each wallet, based on card type
            if (tc2_p1.wallet.card.CardDetails.ContainsKey("MC")) { mcInt = calcCardInterest("MC", tc2_p1.wallet.card.CardDetails["MC"]); }
            if (tc2_p1.wallet.card.CardDetails.ContainsKey("Visa")) { visaInt = calcCardInterest("Visa", tc2_p1.wallet.card.CardDetails["Visa"]); }
            if (tc2_p1.wallet.card.CardDetails.ContainsKey("Discover")) { discInt = calcCardInterest("Discover", tc2_p1.wallet.card.CardDetails["Discover"]); }
            if (tc2_p1.wallet2.card.CardDetails.ContainsKey("MC")) { mcInt2 = calcCardInterest("MC", tc2_p1.wallet2.card.CardDetails["MC"]); }
            if (tc2_p1.wallet2.card.CardDetails.ContainsKey("Visa")) { visaInt2 = calcCardInterest("Visa", tc2_p1.wallet2.card.CardDetails["Visa"]); }
            if (tc2_p1.wallet2.card.CardDetails.ContainsKey("Discover")) { discInt2 = calcCardInterest("Discover", tc2_p1.wallet2.card.CardDetails["Discover"]); }

            //calculate total interest for all wallets
            tc2_p1.wallet.totalWalInt = mcInt + visaInt + discInt;
            tc2_p1.wallet2.totalWalInt = mcInt2 + visaInt2 + discInt2;

            //calculate total interest per person
            tc2_p1.totalInt = tc2_p1.wallet.totalWalInt + tc2_p1.wallet2.totalWalInt;

            //Test to make sure that the total interest for the person is correct.
            Assert.AreEqual(16.0, tc2_p1.totalInt);

            //Test to make sure the interest is correct for each card type
            Assert.AreEqual(11.0, tc2_p1.wallet.totalWalInt);
            Assert.AreEqual(5.0, tc2_p1.wallet2.totalWalInt);

        }

        public void TestCase3()
        {
            Person tc3_p1 = new Person();
            Person tc3_p2 = new Person();

            //add cards to person1's wallet
            tc3_p1.wallet.card.CardDetails.Add("MC", 100);
            tc3_p1.wallet.card.CardDetails.Add("Visa", 100);

            //add cards to person2's wallet
            tc3_p2.wallet.card.CardDetails.Add("Visa", 100);
            tc3_p2.wallet.card.CardDetails.Add("MC", 100);

            //Calculate interest for each card, for each wallet, based on card type
            if (tc3_p1.wallet.card.CardDetails.ContainsKey("MC")) { mcInt = calcCardInterest("MC", tc3_p1.wallet.card.CardDetails["MC"]); }
            if (tc3_p1.wallet.card.CardDetails.ContainsKey("Visa")) { visaInt = calcCardInterest("Visa", tc3_p1.wallet.card.CardDetails["Visa"]); }
            if (tc3_p1.wallet.card.CardDetails.ContainsKey("Discover")) { discInt = calcCardInterest("Discover", tc3_p1.wallet.card.CardDetails["Discover"]); }
            if (tc3_p2.wallet.card.CardDetails.ContainsKey("MC")) { mcInt2 = calcCardInterest("MC", tc3_p2.wallet2.card.CardDetails["MC"]); }
            if (tc3_p2.wallet.card.CardDetails.ContainsKey("Visa")) { visaInt2 = calcCardInterest("Visa", tc3_p2.wallet2.card.CardDetails["Visa"]); }
            if (tc3_p2.wallet.card.CardDetails.ContainsKey("Discover")) { discInt2 = calcCardInterest("Discover", tc3_p2.wallet2.card.CardDetails["Discover"]); }

            //calculate total interest for all wallets
            tc3_p1.wallet.totalWalInt = mcInt + visaInt + discInt;
            tc3_p2.wallet.totalWalInt = mcInt2 + visaInt2 + discInt2;

            //calculate total interest per person
            tc3_p1.totalInt = tc3_p1.wallet.totalWalInt;
            tc3_p2.totalInt = tc3_p1.wallet.totalWalInt;

            //Test to make sure that the total interest per person is correct.
            Assert.AreEqual(15.0, tc3_p1.totalInt);
            Assert.AreEqual(15.0, tc3_p2.totalInt);

            //Test to make sure the interest is correct for each wallet
            Assert.AreEqual(15.0, tc3_p1.wallet.totalWalInt);
            Assert.AreEqual(15.0, tc3_p2.wallet.totalWalInt);
        }
    }

    public class Wallet
    {
        private Dictionary<string, int> _wallet;
        public Dictionary<string, int> WalletDetails { get { return _wallet; } set { } }
        public Wallet() { _wallet = new Dictionary<string, int>(); }
        public CreditCard card { get; set; }
        public float balance { get; set; }
        public float totalWalInt { get; set; }
    }

    public class Person
    {
        public Wallet wallet { get; set; }
        public Wallet wallet2 { get; set; }
        public float totalInt { get; set; }
    }

    public class CreditCard
    {
        private Dictionary<string, int> _creditCard;
        public Dictionary<string, int> CardDetails { get { return _creditCard; } set { } }
        public CreditCard() { _creditCard = new Dictionary<string, int>(); }
    }
}
