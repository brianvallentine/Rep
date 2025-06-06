using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1 : QueryBasis<R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_CRITICA
            INTO :V0ERRO-COUNT :VIND-COUNT
            FROM SEGUROS.VG_CRITICA_PROPOSTA
            WHERE NUM_CERTIFICADO = :V0BILH-NUMBIL
            AND COD_MSG_CRITICA = 834
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_CRITICA
											FROM SEGUROS.VG_CRITICA_PROPOSTA
											WHERE NUM_CERTIFICADO = '{this.V0BILH_NUMBIL}'
											AND COD_MSG_CRITICA = 834
											WITH UR";

            return query;
        }
        public string V0ERRO_COUNT { get; set; }
        public string VIND_COUNT { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1 Execute(R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1 r1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1)
        {
            var ths = r1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ERRO_COUNT = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.V0ERRO_COUNT) ? "-1" : "0";
            return dta;
        }

    }
}