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
    public class P0351_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0351_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VG101.STA_CRITICA
            INTO :VG101-STA-CRITICA
            FROM SEGUROS.VG_RELAC_STATUS_ALCADA VG101
            WHERE VG101.STA_CRITICA = :VG101-STA-CRITICA
            AND VG101.COD_TIPO_FUNCAO = :VG101-COD-TIPO-FUNCAO
            AND VG101.COD_NIVEL_AUTORIZACAO
            = :VG101-COD-NIVEL-AUTORIZACAO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VG101.STA_CRITICA
											FROM SEGUROS.VG_RELAC_STATUS_ALCADA VG101
											WHERE VG101.STA_CRITICA = '{this.VG101_STA_CRITICA}'
											AND VG101.COD_TIPO_FUNCAO = '{this.VG101_COD_TIPO_FUNCAO}'
											AND VG101.COD_NIVEL_AUTORIZACAO
											= '{this.VG101_COD_NIVEL_AUTORIZACAO}'";

            return query;
        }
        public string VG101_STA_CRITICA { get; set; }
        public string VG101_COD_NIVEL_AUTORIZACAO { get; set; }
        public string VG101_COD_TIPO_FUNCAO { get; set; }

        public static P0351_05_INICIO_DB_SELECT_1_Query1 Execute(P0351_05_INICIO_DB_SELECT_1_Query1 p0351_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0351_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0351_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0351_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG101_STA_CRITICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}