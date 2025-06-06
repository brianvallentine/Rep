using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG017
{
    public class P0115_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0115_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            INTO :VG143-NUM-CERTIFICADO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :VG143-NUM-CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.VG143_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string VG143_NUM_CERTIFICADO { get; set; }

        public static P0115_05_INICIO_DB_SELECT_1_Query1 Execute(P0115_05_INICIO_DB_SELECT_1_Query1 p0115_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0115_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0115_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0115_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG143_NUM_CERTIFICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}