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
    public class R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO
            INTO :PROPOFID-NUM-IDENTIFICACAO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :V0RCAP-NRCERTIF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_IDENTIFICACAO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.V0RCAP_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string V0RCAP_NRCERTIF { get; set; }

        public static R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}