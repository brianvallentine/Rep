using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FAIXA,
            TAXAVG,
            TAXAAP
            INTO :MFAIXA,
            :MTXVG,
            :MTXAPMA
            FROM SEGUROS.V0PLANOSVA
            WHERE CODPRODU = :PROPVA-CODPRODU
            AND OPCAO_COBER = :PROPVA-OPCAO-COBER
            AND DTINIVIG <= :PROPVA-DTQITBCO
            AND DTTERVIG >= :PROPVA-DTQITBCO
            AND IDADE_INICIAL <= :PROPVA-IDADE
            AND IDADE_FINAL >= :PROPVA-IDADE
            AND PERIPGTO = :OPCAOP-PERIPGTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FAIXA
							,
											TAXAVG
							,
											TAXAAP
											FROM SEGUROS.V0PLANOSVA
											WHERE CODPRODU = '{this.PROPVA_CODPRODU}'
											AND OPCAO_COBER = '{this.PROPVA_OPCAO_COBER}'
											AND DTINIVIG <= '{this.PROPVA_DTQITBCO}'
											AND DTTERVIG >= '{this.PROPVA_DTQITBCO}'
											AND IDADE_INICIAL <= '{this.PROPVA_IDADE}'
											AND IDADE_FINAL >= '{this.PROPVA_IDADE}'
											AND PERIPGTO = '{this.OPCAOP_PERIPGTO}'";

            return query;
        }
        public string MFAIXA { get; set; }
        public string MTXVG { get; set; }
        public string MTXAPMA { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string PROPVA_CODPRODU { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string PROPVA_IDADE { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1();
            var i = 0;
            dta.MFAIXA = result[i++].Value?.ToString();
            dta.MTXVG = result[i++].Value?.ToString();
            dta.MTXAPMA = result[i++].Value?.ToString();
            return dta;
        }

    }
}