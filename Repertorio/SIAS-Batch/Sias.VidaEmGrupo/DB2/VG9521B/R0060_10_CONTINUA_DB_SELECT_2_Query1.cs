using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0060_10_CONTINUA_DB_SELECT_2_Query1 : QueryBasis<R0060_10_CONTINUA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :FATURCON-DATA-REFERENCIA
            FROM SEGUROS.FATURAS_CONTROLE
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND COD_SUBGRUPO = 0
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.FATURAS_CONTROLE
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND COD_SUBGRUPO = 0";

            return query;
        }
        public string FATURCON_DATA_REFERENCIA { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }

        public static R0060_10_CONTINUA_DB_SELECT_2_Query1 Execute(R0060_10_CONTINUA_DB_SELECT_2_Query1 r0060_10_CONTINUA_DB_SELECT_2_Query1)
        {
            var ths = r0060_10_CONTINUA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_10_CONTINUA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_10_CONTINUA_DB_SELECT_2_Query1();
            var i = 0;
            dta.FATURCON_DATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}