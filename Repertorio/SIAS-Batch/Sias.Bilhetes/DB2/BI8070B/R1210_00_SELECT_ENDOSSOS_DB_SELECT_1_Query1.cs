using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA
            INTO :ENDOSSOS-NUM-PROPOSTA
            FROM SEGUROS.ENDOSSOS
            WHERE COD_FONTE = :ENDOSSOS-COD-FONTE
            AND NUM_PROPOSTA = :FONTES-ULT-PROP-AUTOMAT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA
											FROM SEGUROS.ENDOSSOS
											WHERE COD_FONTE = '{this.ENDOSSOS_COD_FONTE}'
											AND NUM_PROPOSTA = '{this.FONTES_ULT_PROP_AUTOMAT}'
											WITH UR";

            return query;
        }
        public string ENDOSSOS_NUM_PROPOSTA { get; set; }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }

        public static R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_NUM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}