using System;
using System.Collections.Generic;
using Apontamento.App.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Apontamento.Tests.Application.Services
{
    [TestFixture]
    public class ApontamentoTests
    {
        [Test]
        public void ShouldReturnGaps()
        {
            var apontamento = new App.Application.Services.Apontamento(
                new List<ApontamentoAggregate>{
                    new ApontamentoAggregate("10575","03/03/2018 11:00:00","04/03/2018 22:00:00","","23","57"),
                    new ApontamentoAggregate("10576","05/03/2018 06:00:00","05/03/2018 06:55:00","","20","57"),
                    new ApontamentoAggregate("10577","05/03/2018 06:55:00","05/03/2018 07:55:00","18020159","1","57"),
                    new ApontamentoAggregate("10578","05/03/2018 08:55:00","05/03/2018 09:55:00","18020159","1","5")
            });

            var list = apontamento.GetGaps();


            list.Quantidade.Should().Be(2);
            list.Periodo.Should().Be(new TimeSpan(9, 0, 0));
        }
    }
}