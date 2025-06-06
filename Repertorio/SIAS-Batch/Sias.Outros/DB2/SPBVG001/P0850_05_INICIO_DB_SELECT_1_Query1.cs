using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0850_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0850_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(VG103.SEQ_CRITICA),0) + 1
            INTO :VG103-SEQ-CRITICA
            FROM SEGUROS.VG_CRITICA_PROPOSTA VG103
            WHERE VG103.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(VG103.SEQ_CRITICA)
							,0) + 1
											FROM SEGUROS.VG_CRITICA_PROPOSTA VG103
											WHERE VG103.NUM_CERTIFICADO = '{this.VG103_NUM_CERTIFICADO}'";

            return query;
        }
        public string VG103_SEQ_CRITICA { get; set; }
        public string VG103_NUM_CERTIFICADO { get; set; }

        public static P0850_05_INICIO_DB_SELECT_1_Query1 Execute(P0850_05_INICIO_DB_SELECT_1_Query1 p0850_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0850_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0850_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0850_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG103_SEQ_CRITICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}