using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0720B
{
    public class R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PREMIO_VG,
            PREMIO_AP
            INTO :PARCEVID-PREMIO-VG,
            :PARCEVID-PREMIO-AP
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :PARCEVID-NUM-CERTIFICADO
            AND NUM_PARCELA = :PARCEVID-NUM-PARCELA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PREMIO_VG
							,
											PREMIO_AP
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PARCEVID_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.PARCEVID_NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string PARCEVID_PREMIO_VG { get; set; }
        public string PARCEVID_PREMIO_AP { get; set; }
        public string PARCEVID_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_NUM_PARCELA { get; set; }

        public static R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1 Execute(R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1 r0340_00_OBTER_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r0340_00_OBTER_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEVID_PREMIO_VG = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_AP = result[i++].Value?.ToString();
            return dta;
        }

    }
}