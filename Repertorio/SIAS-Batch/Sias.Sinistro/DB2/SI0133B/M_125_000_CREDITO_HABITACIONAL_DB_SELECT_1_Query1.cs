using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1 : QueryBasis<M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPERACAO,
            PONTO_VENDA,
            NUM_CONTRATO,
            CGCCPF,
            NOME_SEGURADO
            INTO :V0HABIT01-OPERACAO,
            :V0HABIT01-PONTO-VENDA,
            :V0HABIT01-NUM-CONTRATO,
            :V0HABIT01-CGCCPF,
            :V0HABIT01-NOME-SEGURADO
            FROM SEGUROS.V0SINISTRO_HABIT01
            WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPERACAO
							,
											PONTO_VENDA
							,
											NUM_CONTRATO
							,
											CGCCPF
							,
											NOME_SEGURADO
											FROM SEGUROS.V0SINISTRO_HABIT01
											WHERE NUM_APOL_SINISTRO = '{this.RELSIN_APOL_SINI}'";

            return query;
        }
        public string V0HABIT01_OPERACAO { get; set; }
        public string V0HABIT01_PONTO_VENDA { get; set; }
        public string V0HABIT01_NUM_CONTRATO { get; set; }
        public string V0HABIT01_CGCCPF { get; set; }
        public string V0HABIT01_NOME_SEGURADO { get; set; }
        public string RELSIN_APOL_SINI { get; set; }

        public static M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1 Execute(M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1 m_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1)
        {
            var ths = m_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HABIT01_OPERACAO = result[i++].Value?.ToString();
            dta.V0HABIT01_PONTO_VENDA = result[i++].Value?.ToString();
            dta.V0HABIT01_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.V0HABIT01_CGCCPF = result[i++].Value?.ToString();
            dta.V0HABIT01_NOME_SEGURADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}