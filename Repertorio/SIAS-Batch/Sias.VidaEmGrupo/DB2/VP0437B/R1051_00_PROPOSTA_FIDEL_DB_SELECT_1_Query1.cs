using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1 : QueryBasis<R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPRCTADEB
            INTO :PROPOFID-OPRCTADEB
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPRCTADEB
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1 Execute(R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1 r1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1)
        {
            var ths = r1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1051_00_PROPOSTA_FIDEL_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_OPRCTADEB = result[i++].Value?.ToString();
            return dta;
        }

    }
}