using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(ARQ_FDCAP,0),
            VALUE(ESTR_COBR, '         ' ),
            COBERADIC_PREMIO,
            CUSTOCAP_TOTAL
            INTO
            :PRODVG-ARQFDCAP,
            :PRODVG-ESTRCOBR,
            :PRODVG-COBERADIC,
            :PRODVG-CUSTOCAP
            FROM
            SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :RELATO-NUM-APOLICE
            AND CODSUBES = :RELATO-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(ARQ_FDCAP
							,0)
							,
											VALUE(ESTR_COBR
							, '         ' )
							,
											COBERADIC_PREMIO
							,
											CUSTOCAP_TOTAL
											FROM
											SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.RELATO_NUM_APOLICE}'
											AND CODSUBES = '{this.RELATO_CODSUBES}'";

            return query;
        }
        public string PRODVG_ARQFDCAP { get; set; }
        public string PRODVG_ESTRCOBR { get; set; }
        public string PRODVG_COBERADIC { get; set; }
        public string PRODVG_CUSTOCAP { get; set; }
        public string RELATO_NUM_APOLICE { get; set; }
        public string RELATO_CODSUBES { get; set; }

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
            dta.PRODVG_ARQFDCAP = result[i++].Value?.ToString();
            dta.PRODVG_ESTRCOBR = result[i++].Value?.ToString();
            dta.PRODVG_COBERADIC = result[i++].Value?.ToString();
            dta.PRODVG_CUSTOCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}