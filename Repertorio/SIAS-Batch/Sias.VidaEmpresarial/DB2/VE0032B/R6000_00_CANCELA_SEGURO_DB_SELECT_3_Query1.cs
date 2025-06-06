using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0032B
{
    public class R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1 : QueryBasis<R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1>
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

        public static R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1 Execute(R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1 r6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1)
        {
            var ths = r6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1();
            var i = 0;
            dta.FATURCON_DATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}