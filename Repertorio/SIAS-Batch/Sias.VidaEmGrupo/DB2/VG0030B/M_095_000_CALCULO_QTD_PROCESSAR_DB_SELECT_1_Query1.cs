using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1 : QueryBasis<M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-QTD-A-PROCESSAR
            FROM SEGUROS.MOVIMENTO_VGAP A
            ,SEGUROS.APOLICES B
            WHERE A.DATA_INCLUSAO IS NULL
            AND A.COD_OPERACAO BETWEEN 0300 AND 499
            AND A.DATA_AVERBACAO IS NOT NULL
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_APOLICE NOT IN (0109300000635,
            0107700000007 )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.MOVIMENTO_VGAP A
											,SEGUROS.APOLICES B
											WHERE A.DATA_INCLUSAO IS NULL
											AND A.COD_OPERACAO BETWEEN 0300 AND 499
											AND A.DATA_AVERBACAO IS NOT NULL
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_APOLICE NOT IN (0109300000635
							,
											0107700000007 )";

            return query;
        }
        public string WS_QTD_A_PROCESSAR { get; set; }

        public static M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1 Execute(M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1 m_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1)
        {
            var ths = m_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QTD_A_PROCESSAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}