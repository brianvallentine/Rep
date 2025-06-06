using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1 : QueryBasis<R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_EVENTO
            INTO :GECARACO-COD-EVENTO
            FROM SEGUROS.GE_CARTA_ACOMP A
            WHERE A.NUM_CARTA = :WS-CARTA-ANT
            AND A.NUM_OCORR_CARTACO =
            (SELECT MAX(B.NUM_OCORR_CARTACO)
            FROM SEGUROS.GE_CARTA_ACOMP B
            WHERE B.NUM_CARTA = :WS-CARTA-ANT)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_EVENTO
											FROM SEGUROS.GE_CARTA_ACOMP A
											WHERE A.NUM_CARTA = '{this.WS_CARTA_ANT}'
											AND A.NUM_OCORR_CARTACO =
											(SELECT MAX(B.NUM_OCORR_CARTACO)
											FROM SEGUROS.GE_CARTA_ACOMP B
											WHERE B.NUM_CARTA = '{this.WS_CARTA_ANT}')";

            return query;
        }
        public string GECARACO_COD_EVENTO { get; set; }
        public string WS_CARTA_ANT { get; set; }

        public static R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1 Execute(R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1 r3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1)
        {
            var ths = r3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.GECARACO_COD_EVENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}