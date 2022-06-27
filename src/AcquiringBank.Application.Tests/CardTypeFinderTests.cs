using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcquiringBank.Domain.Models;
using FluentAssertions;

namespace AcquiringBank.Application.Tests
{
    public  class CardTypeFinderTests
    {
        private CardTypeFinder _finder;

        public CardTypeFinderTests()
        {
            _finder = new CardTypeFinder();

        }

        [Theory]
        [InlineData("4169773331987017", CardType.Visa)]
        [InlineData("4658958254583145", CardType.Visa)]
        [InlineData("5410710000901089", CardType.MasterCard)]
        [InlineData("371305972529535", CardType.AmericanExpress)]
        [InlineData("6011683204539909", CardType.Discover)]
        [InlineData("3589295535870728", CardType.JCB)]

        public void Should_return_valid_card_type(string cardNumber, CardType expected)
        {
            _finder.FindType(cardNumber).Should().Be(expected);

        }
        
    }
}
