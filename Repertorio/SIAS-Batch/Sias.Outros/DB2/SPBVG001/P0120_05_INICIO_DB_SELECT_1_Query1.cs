using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0120_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0120_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VG102.DES_ABREV_MSG_CRITICA
            ,VG102.COD_TP_MSG_CRITICA
            INTO :VG102-DES-ABREV-MSG-CRITICA
            ,:VG102-COD-TP-MSG-CRITICA
            FROM SEGUROS.VG_DM_MSG_CRITICA VG102
            WHERE VG102.COD_MSG_CRITICA = :VG102-COD-MSG-CRITICA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VG102.DES_ABREV_MSG_CRITICA
											,VG102.COD_TP_MSG_CRITICA
											FROM SEGUROS.VG_DM_MSG_CRITICA VG102
											WHERE VG102.COD_MSG_CRITICA = '{this.VG102_COD_MSG_CRITICA}'";

            return query;
        }
        public string VG102_DES_ABREV_MSG_CRITICA { get; set; }
        public string VG102_COD_TP_MSG_CRITICA { get; set; }
        public string VG102_COD_MSG_CRITICA { get; set; }

        public static P0120_05_INICIO_DB_SELECT_1_Query1 Execute(P0120_05_INICIO_DB_SELECT_1_Query1 p0120_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0120_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0120_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0120_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG102_DES_ABREV_MSG_CRITICA = result[i++].Value?.ToString();
            dta.VG102_COD_TP_MSG_CRITICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}