using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0540S
{
    public class R0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1 : QueryBasis<R0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_CLIENTE
            INTO :APOLIAUT-COD-CLIENTE
            FROM SEGUROS.APOLICE_AUTO A
            WHERE A.NUM_APOLICE = :APOLIAUT-NUM-APOLICE
            AND A.NUM_ENDOSSO = :APOLIAUT-NUM-ENDOSSO
            AND A.NUM_ITEM =
            ( SELECT MAX(B.NUM_ITEM)
            FROM SEGUROS.APOLICE_AUTO B
            WHERE A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_CLIENTE
											FROM SEGUROS.APOLICE_AUTO A
											WHERE A.NUM_APOLICE = '{this.APOLIAUT_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.APOLIAUT_NUM_ENDOSSO}'
											AND A.NUM_ITEM =
											( SELECT MAX(B.NUM_ITEM)
											FROM SEGUROS.APOLICE_AUTO B
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO )
											WITH UR";

            return query;
        }
        public string APOLIAUT_COD_CLIENTE { get; set; }
        public string APOLIAUT_NUM_APOLICE { get; set; }
        public string APOLIAUT_NUM_ENDOSSO { get; set; }

        public static R0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1 Execute(R0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1 r0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1)
        {
            var ths = r0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLIAUT_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}