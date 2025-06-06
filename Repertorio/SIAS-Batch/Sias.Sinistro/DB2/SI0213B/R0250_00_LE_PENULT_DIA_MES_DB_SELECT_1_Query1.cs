using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1 : QueryBasis<R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(A.DATA_CALENDARIO), '0001-01-01' )
            INTO :HOST-DATA-PENULT-DIA-MES
            FROM SEGUROS.CALENDARIO A
            WHERE YEAR(A.DATA_CALENDARIO) = :HOST-ANO-MOV-ABERTO
            AND MONTH(A.DATA_CALENDARIO) = :HOST-MES-MOV-ABERTO
            AND A.DIA_SEMANA NOT IN ( 'S' , 'D' )
            AND A.FERIADO <> 'N'
            AND A.DATA_CALENDARIO <
            (SELECT MAX(B.DATA_CALENDARIO)
            FROM SEGUROS.CALENDARIO B
            WHERE YEAR(B.DATA_CALENDARIO) = :HOST-ANO-MOV-ABERTO
            AND MONTH(B.DATA_CALENDARIO) = :HOST-MES-MOV-ABERTO
            AND B.DIA_SEMANA NOT IN ( 'S' , 'D' )
            AND B.FERIADO <> 'N' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(A.DATA_CALENDARIO)
							, '0001-01-01' )
											FROM SEGUROS.CALENDARIO A
											WHERE YEAR(A.DATA_CALENDARIO) = '{this.HOST_ANO_MOV_ABERTO}'
											AND MONTH(A.DATA_CALENDARIO) = '{this.HOST_MES_MOV_ABERTO}'
											AND A.DIA_SEMANA NOT IN ( 'S' 
							, 'D' )
											AND A.FERIADO <> 'N'
											AND A.DATA_CALENDARIO <
											(SELECT MAX(B.DATA_CALENDARIO)
											FROM SEGUROS.CALENDARIO B
											WHERE YEAR(B.DATA_CALENDARIO) = '{this.HOST_ANO_MOV_ABERTO}'
											AND MONTH(B.DATA_CALENDARIO) = '{this.HOST_MES_MOV_ABERTO}'
											AND B.DIA_SEMANA NOT IN ( 'S' 
							, 'D' )
											AND B.FERIADO <> 'N' )";

            return query;
        }
        public string HOST_DATA_PENULT_DIA_MES { get; set; }
        public string HOST_ANO_MOV_ABERTO { get; set; }
        public string HOST_MES_MOV_ABERTO { get; set; }

        public static R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1 Execute(R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1 r0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_DATA_PENULT_DIA_MES = result[i++].Value?.ToString();
            return dta;
        }

    }
}