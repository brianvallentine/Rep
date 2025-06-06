using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG013
{
    public class P0540_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0540_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(1),0)
            INTO :WS-COUNT
            FROM SEGUROS.VG_ACOPLADO_TITULO
            WHERE IDE_SISTEMA = :VG136-IDE-SISTEMA
            AND NUM_CERTIFICADO = :VG136-NUM-CERTIFICADO
            AND COD_PRODUTO = :VG136-COD-PRODUTO
            AND COD_PLANO = :VG136-COD-PLANO
            AND STA_TITULO = :VG136-STA-TITULO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(1)
							,0)
											FROM SEGUROS.VG_ACOPLADO_TITULO
											WHERE IDE_SISTEMA = '{this.VG136_IDE_SISTEMA}'
											AND NUM_CERTIFICADO = '{this.VG136_NUM_CERTIFICADO}'
											AND COD_PRODUTO = '{this.VG136_COD_PRODUTO}'
											AND COD_PLANO = '{this.VG136_COD_PLANO}'
											AND STA_TITULO = '{this.VG136_STA_TITULO}'";

            return query;
        }
        public string WS_COUNT { get; set; }
        public string VG136_NUM_CERTIFICADO { get; set; }
        public string VG136_IDE_SISTEMA { get; set; }
        public string VG136_COD_PRODUTO { get; set; }
        public string VG136_STA_TITULO { get; set; }
        public string VG136_COD_PLANO { get; set; }

        public static P0540_05_INICIO_DB_SELECT_1_Query1 Execute(P0540_05_INICIO_DB_SELECT_1_Query1 p0540_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0540_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0540_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0540_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}