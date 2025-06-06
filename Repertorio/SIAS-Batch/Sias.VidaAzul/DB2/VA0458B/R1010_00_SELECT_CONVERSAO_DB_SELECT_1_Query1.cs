using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 : QueryBasis<R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :CONV-NUM-SICOB
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF = '{this.V0PROP_NRCERTIF}'";

            return query;
        }
        public string CONV_NUM_SICOB { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 Execute(R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1)
        {
            var ths = r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONV_NUM_SICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}