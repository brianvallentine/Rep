using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3117S
{
    public class R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1 : QueryBasis<R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.PCT_PRM_ANUAL
            INTO :PRAZOSEG-PCT-PRM-ANUAL
            FROM SEGUROS.PRAZO_SEGURO A
            WHERE A.COD_TABELA = 5
            AND A.INICIO_PRAZO <= :PRAZOSEG-INICIO-PRAZO
            AND A.FIM_PRAZO >= :PRAZOSEG-INICIO-PRAZO
            AND A.DATA_INIVIGENCIA =
            (SELECT MAX(B.DATA_INIVIGENCIA)
            FROM SEGUROS.PRAZO_SEGURO B
            WHERE A.COD_TABELA = B.COD_TABELA
            AND A.INICIO_PRAZO = B.INICIO_PRAZO
            AND A.FIM_PRAZO = B.FIM_PRAZO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.PCT_PRM_ANUAL
											FROM SEGUROS.PRAZO_SEGURO A
											WHERE A.COD_TABELA = 5
											AND A.INICIO_PRAZO <= '{this.PRAZOSEG_INICIO_PRAZO}'
											AND A.FIM_PRAZO >= '{this.PRAZOSEG_INICIO_PRAZO}'
											AND A.DATA_INIVIGENCIA =
											(SELECT MAX(B.DATA_INIVIGENCIA)
											FROM SEGUROS.PRAZO_SEGURO B
											WHERE A.COD_TABELA = B.COD_TABELA
											AND A.INICIO_PRAZO = B.INICIO_PRAZO
											AND A.FIM_PRAZO = B.FIM_PRAZO)";

            return query;
        }
        public string PRAZOSEG_PCT_PRM_ANUAL { get; set; }
        public string PRAZOSEG_INICIO_PRAZO { get; set; }

        public static R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1 Execute(R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1 r1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRAZOSEG_PCT_PRM_ANUAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}