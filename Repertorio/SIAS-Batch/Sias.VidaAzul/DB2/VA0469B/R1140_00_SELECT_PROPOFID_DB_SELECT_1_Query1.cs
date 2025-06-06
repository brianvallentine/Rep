using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAOPAG
            INTO :PROPOFID-OPCAOPAG
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :RELATORI-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAOPAG
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.RELATORI_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOFID_OPCAOPAG { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_OPCAOPAG = result[i++].Value?.ToString();
            return dta;
        }

    }
}