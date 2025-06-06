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
    public class P0460_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0460_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(SEQ_ERRO) + 1
            INTO :VG139-SEQ-ERRO:WS-IND-NULL
            FROM SEGUROS.VG_ACOPLADO_ERRO
            WHERE IDE_SISTEMA = :VG139-IDE-SISTEMA
            AND NUM_CERTIFICADO = :VG139-NUM-CERTIFICADO
            AND COD_PRODUTO = :VG139-COD-PRODUTO
            AND COD_PLANO = :VG139-COD-PLANO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MAX(SEQ_ERRO) + 1
											FROM SEGUROS.VG_ACOPLADO_ERRO
											WHERE IDE_SISTEMA = '{this.VG139_IDE_SISTEMA}'
											AND NUM_CERTIFICADO = '{this.VG139_NUM_CERTIFICADO}'
											AND COD_PRODUTO = '{this.VG139_COD_PRODUTO}'
											AND COD_PLANO = '{this.VG139_COD_PLANO}'";

            return query;
        }
        public string VG139_SEQ_ERRO { get; set; }
        public string WS_IND_NULL { get; set; }
        public string VG139_NUM_CERTIFICADO { get; set; }
        public string VG139_IDE_SISTEMA { get; set; }
        public string VG139_COD_PRODUTO { get; set; }
        public string VG139_COD_PLANO { get; set; }

        public static P0460_05_INICIO_DB_SELECT_1_Query1 Execute(P0460_05_INICIO_DB_SELECT_1_Query1 p0460_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0460_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0460_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0460_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG139_SEQ_ERRO = result[i++].Value?.ToString();
            dta.WS_IND_NULL = string.IsNullOrWhiteSpace(dta.VG139_SEQ_ERRO) ? "-1" : "0";
            return dta;
        }

    }
}