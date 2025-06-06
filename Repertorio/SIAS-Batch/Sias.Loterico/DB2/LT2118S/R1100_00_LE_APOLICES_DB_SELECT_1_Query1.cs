using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2118S
{
    public class R1100_00_LE_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R1100_00_LE_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_PRODUTO,
            B.SIT_REGISTRO,
            B.DATA_TERVIGENCIA,
            A.PCT_IOCC
            INTO :APOLICES-COD-PRODUTO,
            :ENDOSSOS-SIT-REGISTRO,
            :ENDOSSOS-DATA-TERVIGENCIA,
            :APOLICES-PCT-IOCC
            FROM SEGUROS.APOLICES A,
            SEGUROS.ENDOSSOS B
            WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE
            AND B.NUM_ENDOSSO = 0
            AND A.NUM_APOLICE = B.NUM_APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_PRODUTO
							,
											B.SIT_REGISTRO
							,
											B.DATA_TERVIGENCIA
							,
											A.PCT_IOCC
											FROM SEGUROS.APOLICES A
							,
											SEGUROS.ENDOSSOS B
											WHERE A.NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'
											AND B.NUM_ENDOSSO = 0
											AND A.NUM_APOLICE = B.NUM_APOLICE";

            return query;
        }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string APOLICES_PCT_IOCC { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static R1100_00_LE_APOLICES_DB_SELECT_1_Query1 Execute(R1100_00_LE_APOLICES_DB_SELECT_1_Query1 r1100_00_LE_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_LE_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_LE_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_LE_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICES_PCT_IOCC = result[i++].Value?.ToString();
            return dta;
        }

    }
}