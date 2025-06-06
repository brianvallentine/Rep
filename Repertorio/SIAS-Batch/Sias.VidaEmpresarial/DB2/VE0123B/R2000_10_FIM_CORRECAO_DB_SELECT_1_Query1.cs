using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1 : QueryBasis<R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:PROPOVA-DATA-QUITACAO) + 1 YEAR
            ,DATE(:PROPOVA-DATA-QUITACAO) + 1 YEAR - 1 DAY
            ,DATE(:PROPOVA-DATA-QUITACAO) + 1 YEAR - 2 DAY
            ,DATE(:PROPOVA-DATA-QUITACAO) + 1 YEAR - 3 DAY
            INTO :WS-DTANIVERS
            ,:WS-DTANIVERS-1
            ,:WS-DTANIVERS-2
            ,:WS-DTANIVERS-3
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VE'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.PROPOVA_DATA_QUITACAO}') + 1 YEAR
											,DATE('{this.PROPOVA_DATA_QUITACAO}') + 1 YEAR - 1 DAY
											,DATE('{this.PROPOVA_DATA_QUITACAO}') + 1 YEAR - 2 DAY
											,DATE('{this.PROPOVA_DATA_QUITACAO}') + 1 YEAR - 3 DAY
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VE'
											WITH UR";

            return query;
        }
        public string WS_DTANIVERS { get; set; }
        public string WS_DTANIVERS_1 { get; set; }
        public string WS_DTANIVERS_2 { get; set; }
        public string WS_DTANIVERS_3 { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }

        public static R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1 Execute(R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1 r2000_10_FIM_CORRECAO_DB_SELECT_1_Query1)
        {
            var ths = r2000_10_FIM_CORRECAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DTANIVERS = result[i++].Value?.ToString();
            dta.WS_DTANIVERS_1 = result[i++].Value?.ToString();
            dta.WS_DTANIVERS_2 = result[i++].Value?.ToString();
            dta.WS_DTANIVERS_3 = result[i++].Value?.ToString();
            return dta;
        }

    }
}