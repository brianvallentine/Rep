using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0403B
{
    public class R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO,
            NUM_PARCELA
            INTO :DCLRCAPS.RCAPS-SIT-REGISTRO,
            :DCLRCAPS.RCAPS-NUM-PARCELA:VIND-RCAPS-NUM-PARCELA
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :DCLRCAPS.RCAPS-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
							,
											NUM_PARCELA
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.RCAPS_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_NUM_PARCELA { get; set; }
        public string VIND_RCAPS_NUM_PARCELA { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1 r1100_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.VIND_RCAPS_NUM_PARCELA = string.IsNullOrWhiteSpace(dta.RCAPS_NUM_PARCELA) ? "-1" : "0";
            return dta;
        }

    }
}