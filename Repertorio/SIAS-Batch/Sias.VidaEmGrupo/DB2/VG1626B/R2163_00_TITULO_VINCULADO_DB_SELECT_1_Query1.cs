using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1 : QueryBasis<R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO ,
            NUM_SERIE ,
            NUM_PLANO
            INTO :VG098-NUM-TITULO ,
            :VG098-NUM-SERIE ,
            :VG098-NUM-PLANO
            FROM SEGUROS.VG_CERTIFICADO_TITULO
            WHERE NUM_CERTIFICADO = :VG098-NUM-CERTIFICADO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO 
							,
											NUM_SERIE 
							,
											NUM_PLANO
											FROM SEGUROS.VG_CERTIFICADO_TITULO
											WHERE NUM_CERTIFICADO = '{this.VG098_NUM_CERTIFICADO}'";

            return query;
        }
        public string VG098_NUM_TITULO { get; set; }
        public string VG098_NUM_SERIE { get; set; }
        public string VG098_NUM_PLANO { get; set; }
        public string VG098_NUM_CERTIFICADO { get; set; }

        public static R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1 Execute(R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1 r2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1)
        {
            var ths = r2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG098_NUM_TITULO = result[i++].Value?.ToString();
            dta.VG098_NUM_SERIE = result[i++].Value?.ToString();
            dta.VG098_NUM_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}