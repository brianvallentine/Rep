using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1 : QueryBasis<R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.NUM_PROPOSTA_CONV
            INTO :APOLIAUT-NUM-PROPOSTA-CONV
            FROM SEGUROS.APOLICE_AUTO T1
            WHERE T1.NUM_APOLICE = :V1ENDO-NUMAPOL
            AND T1.NUM_ENDOSSO = 0
            AND T1.NUM_ITEM =
            (SELECT MAX(T2.NUM_ITEM)
            FROM SEGUROS.APOLICE_AUTO T2
            WHERE T2.NUM_APOLICE = T1.NUM_APOLICE
            AND T2.NUM_ENDOSSO = T1.NUM_ENDOSSO)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.NUM_PROPOSTA_CONV
											FROM SEGUROS.APOLICE_AUTO T1
											WHERE T1.NUM_APOLICE = '{this.V1ENDO_NUMAPOL}'
											AND T1.NUM_ENDOSSO = 0
											AND T1.NUM_ITEM =
											(SELECT MAX(T2.NUM_ITEM)
											FROM SEGUROS.APOLICE_AUTO T2
											WHERE T2.NUM_APOLICE = T1.NUM_APOLICE
											AND T2.NUM_ENDOSSO = T1.NUM_ENDOSSO)
											WITH UR";

            return query;
        }
        public string APOLIAUT_NUM_PROPOSTA_CONV { get; set; }
        public string V1ENDO_NUMAPOL { get; set; }

        public static R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1 Execute(R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1 r1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1)
        {
            var ths = r1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLIAUT_NUM_PROPOSTA_CONV = result[i++].Value?.ToString();
            return dta;
        }

    }
}